using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using SMS.Data.Services;
using SMS.Web.ViewModels;
using SMS.Data.Models;


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
        public IActionResult Index(RecipeSearchViewModel rm)
        {
            rm.Recipes = svc.SearchRecipes(rm.Range, rm.Query);
            return View(rm);  
        }

        // GET /recipe/index - 
        public IActionResult RecipeIndex(RecipeSearchViewModel rm) //needs change to get one particular users recipes.
        {
            
            rm.Recipes = svc.SearchRecipes(rm.Range, rm.Query);
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
        [Authorize(Roles="admin")]
        public IActionResult Create()
        {
            var users = svc.GetUsers();
            // populate viewmodel select list property
            var tvm = new RecipeCreateViewModel {
                Users = new SelectList(users,"Id","Name") 
            };
            
            // render blank form
            return View( tvm );
        }
       
        // POST /recipe/create
        [HttpPost]
        [Authorize(Roles="admin")]
        public IActionResult Create(RecipeCreateViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                svc.CreateRecipe(rvm.UserId, rvm.Name, rvm.Diet, rvm.MealType, rvm.RecipeIngredients, rvm.Method, rvm.PrepTime, rvm.CookTime, rvm.Cuisine, rvm.Region, rvm.Translator, rvm.Calories, rvm.Servings, rvm.PhotoUrl);// fix
     
                Alert($"Recipe Created", AlertType.info);  
                return RedirectToAction(nameof(Index));
            }
            
            // redisplay the form for editing
            return View(rvm);
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
                
            }; //do i need more here
            //render form
            return View("AddReview", r);  

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
