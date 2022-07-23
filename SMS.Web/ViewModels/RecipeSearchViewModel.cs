using SMS.Data.Models;

namespace SMS.Web.ViewModels
{   
    public class RecipeSearchViewModel
    {
        // result set
        

        // public int Id {get; set;}
        public IList<Recipe> Recipes { get; set;} = new List<Recipe>();

        // public IList<Review> Reviews {get; set;} = new List<Review>();

        // public string PhotoUrl {get; set;}

        // search options        
        public string Query { get; set; } = "";
        
        public AllRecipes Range { get; set; } = AllRecipes.ALL;
        


    }
}
