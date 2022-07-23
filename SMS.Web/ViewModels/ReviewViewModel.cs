using SMS.Data.Models;

namespace SMS.Web.ViewModels
{
    public class ReviewViewModel
    {

        public int Id { get; set; }      

        public string Name { get; set; }

        public int MealType { get; set; }

        public DateTime ReviewedOn { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }
       
        public int RecipeId { get; set; }  

        public Recipe Recipe { get; set; }


    }

}