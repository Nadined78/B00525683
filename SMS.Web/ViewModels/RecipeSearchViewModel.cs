using SMS.Data.Models;

namespace SMS.Web.ViewModels
{   
    public class RecipeSearchViewModel
    {
       
        public IList<Recipe> Recipes { get; set;} = new List<Recipe>(); //List of Recipes

        // search options        
        public string Query { get; set; } = ""; //string query

        // enum from recipe model
        public Diet Range { get; set; } //defaults to all

        
    }
}
