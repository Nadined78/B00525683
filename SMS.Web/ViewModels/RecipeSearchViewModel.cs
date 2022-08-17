using SMS.Data.Models;

namespace SMS.Web.ViewModels
{   
    public class RecipeSearchViewModel
    {
       
        public IList<Recipe> Recipes { get; set;} = new List<Recipe>(); //List of Recipes

        // search options        
        public string Query { get; set; } = ""; //string query
        
        public AllRecipes Range { get; set; } = AllRecipes.ALL; //defaults to all
        
    }
}
