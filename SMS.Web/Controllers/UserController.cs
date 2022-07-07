using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.Data.Security;
using SMS.Data.Models;
using SMS.Web.ViewModels;
using SMS.Data.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace SMS.Web.Controllers
{
    
    public class UserController : BaseController
    {
        private readonly IConfiguration _config;
        private readonly IFoodService _svc;

        public UserController(IFoodService svc, IConfiguration config)
        {
            _svc = new FoodServiceDb();
            _config = config;  
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost] [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Login([Bind("Email,Password")] UserLoginViewModel m)
        {        
            // call service to Authenticate User
            var user = _svc.Authenticate(m.Email, m.Password);
            // user not authenticated so manually add validation errors for email and password
            if (user == null)
            {
                ModelState.AddModelError("Email", "Invalid Login Credentials");
                ModelState.AddModelError("Password", "Invalid Login Credentials");
                return View(m);
            }
           
             // Login Successful, so sign user in using cookie authentication
            await SignInCookie(user);

            Alert("Successfully Logged in", AlertType.info);

            return Redirect("/");
        }

        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost] [ValidateAntiForgeryToken]
        public IActionResult Register([Bind("Name,Email,Password,PasswordConfirm,Role")] UserRegisterViewModel m)
        {
            // check if email address is already in use - replaced by use of remote validator in UserRegisterViewModel
            if (_svc.GetUserByEmailAddress(m.Email) != null) {
                ModelState.AddModelError(nameof(m.Email),"This email address is already in use. Choose another");
            }

            // check validation
            if (!ModelState.IsValid)
            {
                return View(m);
            }

            // register user
            var user = _svc.Register(m.Name, m.Email, m.Password, m.Role, m.CreatedOn, m.PhotoUrl);               
           
            // registration successful now redirect to login page
            Alert("Registration Successful - Now Login", AlertType.info);          
            return RedirectToAction(nameof(Login));
        }

        [Authorize]
        public IActionResult UpdateProfile()
        {
           // use BaseClass helper method to retrieve Id of signed in user 
            var user = _svc.GetUser(User.GetSignedInUserId());
            var userViewModel = new UserProfileViewModel { 
                Id = user.UserId, 
                Name = user.Name, 
                Email = user.Email,                 
                Role = user.Role
            };
            return View(userViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile([Bind("Id,Name,Email,Role")] UserProfileViewModel m)       
        {
            var user = _svc.GetUser(m.Id);
            // check if form is invalid and redisplay
            if (!ModelState.IsValid || user == null)
            {
                return View(m);
            } 

            // update user details and call service
            user.Name = m.Name;
            user.Email = m.Email;
            user.Role = m.Role;        
            var updated = _svc.UpdateUser(user);

            // check if error updating service
            if (updated == null) {
                Alert("There was a problem Updating. Please try again", AlertType.warning);
                return View(m);
            }

            Alert("Successfully Updated Account Details", AlertType.info);
            
            // sign the user in with updated details)
            await SignInCookie(user);

            return RedirectToAction("Index","Home");
        }

        // Change Password
        [Authorize]
        public IActionResult UpdatePassword()
        {
            // use BaseClass helper method to retrieve Id of signed in user 
            var user = _svc.GetUser(User.GetSignedInUserId());
            var passwordViewModel = new UserPasswordViewModel { 
                Id = user.UserId, 
                Password = user.Password, 
                PasswordConfirm = user.Password, 
            };
            return View(passwordViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword([Bind("Id,OldPassword,Password,PasswordConfirm")] UserPasswordViewModel m)       
        {
            var user = _svc.GetUser(m.Id);
            if (!ModelState.IsValid || user == null)
            {
                return View(m);
            }  
            // update the password
            user.Password = m.Password; 
            // save changes      
            var updated = _svc.UpdateUser(user);
            if (updated == null) {
                Alert("There was a problem Updating the password. Please try again", AlertType.warning);
                return View(m);
            }

            Alert("Successfully Updated Password", AlertType.info);
            // sign the user in with updated details
            await SignInCookie(user);

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        public IActionResult ErrorNotAuthorised()
        {   
            Alert("Not Authorized", AlertType.warning);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ErrorNotAuthenticated()
        {
            Alert("Not Authenticated", AlertType.warning);
            return RedirectToAction("Login", "User"); 
        }        

        // GET /user
        public IActionResult Index()
        {
            var users = _svc.GetUsers();
            
            return View(users);
        }

        // GET /users/details/{id}
        public IActionResult Details(int id)
        {  
            // retrieve the user with specifed id from the service
            var u = _svc.GetUser(id);

            // Alert and redirection
            if (u == null)
            {
                Alert($"User {id} not found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            // pass user as parameter to the view
            return View(u);
        }

        // GET: /user/create
        [Authorize(Roles="admin")]
        public IActionResult Create()
        {   
            // display blank form to create a user
            return View();
        }

        // POST /user/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="admin")]
        public IActionResult Create([Bind("Name, Email, Password, PhotoUrl")]  User u) //if admin only wants to add an admin/member
        {
            // check email is unique for this user
            if (_svc.IsDuplicateUserEmail(u.Email, u.UserId))
            {
                // add manual validation error
                ModelState.AddModelError(nameof(u.Email),"The email address is already in use");
            }

            // complete POST action to add user
            if (ModelState.IsValid)
            {
                // pass data to service to store 
                u = _svc.Register(u.Name, u.Email, u.Password, u.Role, u.CreatedOn, u.PhotoUrl);
                Alert($"User created successfully", AlertType.success);

                return RedirectToAction(nameof(Details), new { Id = u.UserId});
            }
            
            // redisplay the form for editing as there are validation errors
            return View(u);
        }

        // GET /User/edit/{id}
        [Authorize(Roles="admin")]
        public IActionResult Edit(int id)
        {        
            // load the user using the service
            var u = _svc.GetUser(id);

            // check if u is null and if so alert
            if (u == null)
            {
                Alert($"User {id} not found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }   

            // pass user to view for editing
            return View(u);
        }

        // POST /user/edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="admin")]
        public IActionResult Edit(int id, [Bind("Name, Email, Password, PhotoUrl")] User u)
        {
            // check email is unique for this user  
            if (_svc.IsDuplicateUserEmail(u.Email,u.UserId)) 
            {
                // add manual validation error
                ModelState.AddModelError("Email", "This email is already registered");
            }

            // validate and complete POST action to save user changes
            if (ModelState.IsValid)
            {
                // pass data to service to update
                _svc.UpdateUser(u);      
                Alert("User updated successfully", AlertType.info);

                return RedirectToAction(nameof(Details), new { Id = u.UserId });
            }

            // redisplay the form for editing as validation errors
            return View(u);
        }

        // GET / user/delete/{id}
        [Authorize(Roles="admin")]      
        public IActionResult Delete(int id)
        {       
            // load the user using the service
            var u = _svc.GetUser(id);

            // check the returned user is not null and if so return NotFound()
            if (u == null)
            {
                //warning alert and redirect
                Alert($"User {id} not found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }     
            
            // pass user to view for deletion confirmation
            return View(u);
        }

        // POST /user/delete/{id}
        [HttpPost]
        [Authorize(Roles="admin")]
        [ValidateAntiForgeryToken]              
        public IActionResult DeleteConfirm(int id)
        {
            //delete user via service
            _svc.DeleteUser(id);

            Alert("User deleted successfully", AlertType.info);
            // redirect to the index view
            return RedirectToAction(nameof(Index));
        }


        // ============== User Recipe management ==============

        // GET /user/createrecipe/{id}
        public IActionResult RecipeCreate(int id)
        {     
            var u = _svc.GetUser(id);
            // check the returned user is not null and if so alert
            if (u == null)
            {
                Alert($"User {id} not found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            // create a recipe view model and set StudentId (foreign key) - to doooo
            var recipe = new Recipe { UserId = id }; 

            return View(recipe);
        }

        // POST /user/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RecipeCreate([Bind("UserId, Name, RecipeIngredients, PhotoUrl")] Recipe r)
        {
            if (ModelState.IsValid)
            {                
                var recipe = _svc.CreateRecipe(r.UserId, r.Name, r.Diet, r.MealType, r.RecipeIngredients, r.Method, r.PrepTime, r.CookTime, r.Cuisine, r.Region, r.Translator, r.Calories, r.Servings, r.PhotoUrl);
                Alert($"Recipe created successfully for user {r.UserId}", AlertType.info);
                return RedirectToAction(nameof(Details), new { Id = recipe.UserId });
            }
            // redisplay the form for editing
            return View(r);
        }

        // GET /user/recipedelete/{id}
        public IActionResult RecipeDelete(int id)
        {
            // load the recipe using the service
            var recipe = _svc.GetRecipe(id);
            // check the returned recipeis not null and if so return NotFound()
            if (recipe == null)
            {
                Alert($"Recipe {id} not found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }     
            
            // pass recipe to view for deletion confirmation
            return View(recipe);
        }

        // POST /user/recipedeleteconfirm/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RecipeDeleteConfirm(int id, int userId)
        {
            // delete recipe via service
            _svc.DeleteRecipe(id);
            Alert($"Recipe deleted successfully for user {userId}", AlertType.info);
            
            // redirect to the user index view
            return RedirectToAction(nameof(Details), new { Id = userId });
        }

        public IActionResult UserProfile(int userId)
        {
            
        }

        // -------------------------- Helper Methods ------------------------------

        // Called by Remote Validation attribute on RegisterViewModel to verify email address is available
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmailAvailable(string email, int id)
        {
            // check if email is available, or owned by user with id 
            if (!_svc.IsDuplicateUserEmail(email,id))
            {
                return Json($"A user with this email address {email} already exists.");
            }
            return Json(true);                  
        }

        // Called by Remote Validation attribute on ChangePassword to verify old password
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPassword(string oldPassword)
        {
            // use BaseClass helper method to retrieve Id of signed in user 
            var id = User.GetSignedInUserId();            
            // check if email is available, unless already owned by user with id
            var user = _svc.GetUser(id);
            if (user == null || !Hasher.ValidateHash(user.Password, oldPassword))
            {
                return Json($"Please enter current password.");
            }
            return Json(true);                  
        }

        // Sign user in using Cookie authentication scheme
        private async Task SignInCookie(User user)
        {
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                AuthBuilder.BuildClaimsPrincipal(user)
            );
        }

         // ==================================== Build Claims Principle =================================
        // https://docs.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-5.0
        // https://andrewlock.net/introduction-to-authentication-with-asp-net-core/
        
        // // return claims principal based on authenticated user
        // private  ClaimsPrincipal BuildClaimsPrincipal(User user)
        // { 
        //     // define user claims - you can add as many as required
        //     var claims = new ClaimsIdentity(new[]
        //     {
        //         new Claim(ClaimTypes.Email, user.Email),
        //         new Claim(ClaimTypes.Name, user.Name),
        //         new Claim(ClaimTypes.Role, user.Role.ToString())                              
        //     }, CookieAuthenticationDefaults.AuthenticationScheme);

        //     // build principal using claims
        //     return  new ClaimsPrincipal(claims);
        // }

    }
}


        
