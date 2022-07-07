using SMS.Data.Models;

namespace SMS.Web.ViewModels
{   
    public class RecipeSearchViewModel
    {
        // result set
        public IList<Recipe> Recipes { get; set;} = new List<Recipe>();

        public string PhotoUrl {get; set;}

        // search options        
        public string Query { get; set; } = "";
        
        public recipeSearch Range { get; set; } = recipeSearch.ALL;
    }
}
