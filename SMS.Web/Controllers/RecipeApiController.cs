// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.AspNetCore.Authorization;

// using SMS.Data.Models;
// using SMS.Data.Services;
// using SMS.Web.ViewModels;

// namespace SMS.Web.Controllers
// {
//     [ApiController]  
//     [Route("api/recipe")]
//     public class RecipeApiController : BaseController
//     {
//         private readonly IFoodService svc;

//         public RecipeApiController(IFoodService ss)
//         {
//             svc = ss; // initialise via dependency injection
//         } 

//         // GET /api/Recipe
//         [HttpGet]
//         public IActionResult GetAll()
//         {
//             // get all recipes via service
//             var recipes = svc.GetAllRecipes();

//             // convert each recipe into a custom Dto to be sent in response using a local private method
//             var response = recipes.Select(r => ConvertToCustomRecipeObject(r)).ToList(); 
            
//             // OR optionally use an extension method defined in Models/Mapper.cs to do conversion
//             //var response = tickets.Select(t => t.ToDto() ).ToList(); 

//             return Ok(response); 
//         }

             
//         [HttpGet("search")]
//         public IActionResult Search(string query = "", recipeSearch range = recipeSearch.ALL)
//         {                             
//             var recipes = svc.SearchAllRecipes(range, query);
//             var results = recipes.Select( r => ConvertToCustomRecipeObject(r) ).ToList();
            
//             // return custom results list
//             return Ok(results);
//         }        
             
//         // // GET /api/ticket/{id}
//         // [HttpGet("{id}")]
//         // public IActionResult GetOne(int id)
//         // {
//         //     var ticket = svc.GetRecipe(id);
//         //     if (ticket == null)
//         //     {
//         //         return NotFound();             
//         //     }
//         //     // return custom ticket object
//         //     return Ok(ConvertToCustomTicketObject(ticket));
//         // }

               
//         // POST /api/ticket
//         [HttpPost]
//         public IActionResult Create(RecipeCreateViewModel tvm)
//         {
//             if (ModelState.IsValid)
//             {
//                 var recipe = svc.CreateRecipe(tvm.UserId, tvm.Name, tvm.Diet, tvm.MealType, tvm.RecipeIngredients, tvm.Method, tvm.PrepTime, tvm.CookTime, tvm.Cuisine, tvm.Region, tvm.Translator, tvm.Calories, tvm.Servings, tvm.PhotoUrl);
//                 return Ok(recipe);
//             }
            
//             // 
//             return NotFound();
//         }


//         // private method to convert a ticket into a custom object for json response
//         private object ConvertToCustomRecipeObject(Recipe r)
//         {
//             return new {   
//                 Id = r.Id,
//                 Name = r.Name,
//                 Diet = r.Diet,
//                 MealType = r.MealType,
//                 RecipeIngredients = r.RecipeIngredients,
//                 Method = r.Method,
//                 PrepTime = r.PrepTime,
//                 CookTime = r.CookTime,
//                 Cuisine = r.Cuisine,
//                 Region = r.Region,
//                 Translator = r.Translator,
//                 Calories = r.Calories,
//                 Servings = r.Servings,
//                 PhotoUrl = r.PhotoUrl, 
//                 Rating = r.Rating           
//             };
//         }

//     }
// }
