using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using SMS.Data.Services;
using SMS.Web.ViewModels;
using SMS.Data.Models;
using SMS.Data.Security;

namespace SMS.Web.Controllers
{
    [Authorize]
    public class RecipeController : BaseController
    {
        private readonly IFoodService svc;

        public RecipeController(IFoodService ss)
        {
            svc = ss;
        } 


        // GET /recipe/index - 
        public IActionResult Index(RecipeSearchViewModel rm) //indivdual user recipe index
        {
            var userId = User.GetSignedInUserId();

            rm.Recipes = svc.SearchMyRecipes(rm.Range, userId, rm.Query);
            return View(rm);
        }

        // // GET /recipe/index - 
        
        public IActionResult RecipeIndex(RecipeSearchViewModel rm, string sortOrder) //recipe list - recipeindex - all users recipes 
        {
                 
            rm.Recipes = svc.SearchAllRecipes(rm.Range, rm.Query);
            return View(rm);  

            
    
        }    

       

        // GET/recipe/{id}
        public IActionResult Details(int id)
        {
            var recipe = svc.GetRecipeById(id);
            if (recipe == null)
            {
                Alert("Recipe Not Found", AlertType.warning);  
                return RedirectToAction(nameof(Index));             
            }

            return View(recipe);
        }

        
        // GET /recipe/create
        [Authorize(Roles="member")]
        public IActionResult Create()
        {
            var userId = User.GetSignedInUserId();
            var recipe = new RecipeCreateViewModel {
                UserId = userId };

            return View(recipe);
        }
                
       
        // POST /recipe/create
        [HttpPost]
        [Authorize(Roles="member")]
        public IActionResult Create(RecipeCreateViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                svc.CreateRecipe(rvm.UserId, rvm.Name, rvm.Diet, rvm.MealType, rvm.RecipeIngredients, rvm.Method, rvm.PrepTime, rvm.CookTime, rvm.Cuisine, rvm.Region, rvm.Translator, rvm.Calories, rvm.Servings, rvm.Price, rvm.PhotoUrl);// fix
     
                Alert($"Recipe created successfully for user {rvm.UserId}", AlertType.success); 
                return RedirectToAction(nameof(Index));
            }
            
            // redisplay the form for editing
            return View(rvm);
        }

        
        public IActionResult Edit(int id)
        {        
            // load the recipe using the service
            var r = svc.GetRecipeById(id);

            // check if r is null and if so alert
            if (r == null)
            {
                Alert($"Recipe {id} not found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }   

            // pass recipe to view for editing
            return View(r);
        }

        // POST /recipe/edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="admin, member")]
        public IActionResult Edit(Recipe r)
        {
            var recipe = svc.GetRecipeById(r.Id);
            
            // check if form is invalid and redisplay
            if (!ModelState.IsValid || recipe == null)
            {
                return View(r);
            } 

            // update user details and call service
            recipe.Name = r.Name;
            recipe.Diet = r.Diet;
            recipe.MealType = r.MealType;
            recipe.RecipeIngredients = r.RecipeIngredients;
            recipe.Method = r.Method;
            recipe.PrepTime = r.PrepTime;
            recipe.CookTime = r.CookTime;
            recipe.Cuisine = r.Cuisine;
            recipe.Region = r.Region;
            recipe.Translator = r.Translator;
            recipe.Calories = r.Calories;
            recipe.Servings = r.Servings;
            recipe.Price = r.Price;
            recipe.PhotoUrl = r.PhotoUrl;
       
            var updated = svc.UpdateRecipe(recipe);

            // check if error updating service
            if (updated == null) {
                Alert("There was a problem Updating. Please try again", AlertType.warning);
                return View(r);
            }

            
            Alert("Successfully Updated Recipe Details", AlertType.info);
            
            if (User.IsInRole("admin"))
                {
                    return RedirectToAction("RecipeIndex");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            
        }

        public IActionResult RecipeOwnerUserProfile(int id)
        {
            // retrieve the user with specifed id from the service
            var u = svc.GetUser(id);

            // Alert and redirection
            if (u == null)
            {
                Alert($"User not found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            // pass user as parameter to the view
            return View(u);
        }

        // GET / recipe/delete/{id}
        [Authorize(Roles="admin, member")]      
        public IActionResult Delete(int id)
        {       
            // load the recipe using the service
            var r = svc.GetRecipeById(id);
            // check the returned recipe is not null and if so return NotFound()
            if (r == null)
            {
                // warning alert and redirect
                Alert($"Recipe {id} not found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }     
            
            // pass recipe to view for deletion confirmation
            return View(r);
        }

        // POST /recipe/delete/{id}
        [HttpPost]
        [Authorize(Roles="admin, member")]
        [ValidateAntiForgeryToken]              
        public IActionResult DeleteConfirm(int id)
        {
            // delete recipe via service
            svc.DeleteRecipe(id);

            Alert("Recipe deleted successfully", AlertType.info);
            // redirect to the index view
            return RedirectToAction(nameof(Index));
        }


        
        // GET
        public IActionResult AddReview(int id)
        {
            var r = svc.GetRecipeById(id);  
            if (r == null)                  
            {
                Alert($"Recipe not found", AlertType.warning);  
                return RedirectToAction(nameof(Index));
            }

            //Otherwise, a new review is created 
            var re = new ReviewViewModel 
            {      

                RecipeId = id,
                Name = r.Name,
                
            };
            //render form
            return View("AddReview", re);  

        }

        // POST 
        [HttpPost]
        public IActionResult AddReview(Review r)
        {         
            var re = svc.GetRecipeById(r.RecipeId);        

            if (re == null)                             
            {   
                Alert($"Recipe not found", AlertType.warning);  
                return RedirectToAction(nameof(Index));
            }

            svc.AddReview(r);      
               
            Alert("Review added successfully", AlertType.success); 
            return RedirectToAction("Details", new { Id = r.RecipeId });
                     
        }//AddReview
       
        // GET 
        public IActionResult DeleteReview(int id)
        {
            var r = svc.GetReviewById(id);      

            if (r == null)     
            {  
               Alert($"Review not found", AlertType.warning);   
               return RedirectToAction(nameof(Index));
            }     

            return View(r);     
        }

        //POST 
        [HttpPost]
        public IActionResult DeleteConfirmReview(int id)   
        {
            svc.DeleteReview(id);                          
         
            Alert($"Review deleted successfully", AlertType.warning); 
  
            return RedirectToAction("Index");
        }

        


    }
}
