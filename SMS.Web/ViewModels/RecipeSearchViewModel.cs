using SMS.Data.Models;

namespace SMS.Web.ViewModels
{   
    public class RecipeSearchViewModel
    {
       
        public IList<Recipe> Recipes { get; set;} = new List<Recipe>();

        // search options        
        public string Query { get; set; } = "";
        
        public AllRecipes Range { get; set; } = AllRecipes.ALL;
        


    }
}
