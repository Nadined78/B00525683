using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using SMS.Data.Services;
using SMS.Web.ViewModels;


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
        public IActionResult RecipeIndex(RecipeSearchViewModel rm)
        {
            
            rm.Recipes = svc.SearchRecipes(rm.Range, rm.Query);
            return View(rm);  
        }
               
        // GET/recipe/{id}
        public IActionResult Details(int id)
        {
            var recipe = svc.GetRecipe(id);
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

    }
}
