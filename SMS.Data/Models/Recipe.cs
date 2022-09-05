using System.ComponentModel.DataAnnotations;
using SMS.Data.Validators; // allows access to UrlResource


namespace SMS.Data.Models
{
    public enum MealType { Breakfast, Lunch, Dinner, Snack }

    public enum Region { Africa, Asia, CentralAmerica, Europe, MiddleEast, NorthAmerica, Oceania, SouthAmerica, Caribbean }

    // used in recipe search feature
    public enum Diet { ALL, Vegetarian, Vegan, Omnivorous}

    public class Recipe
    {

        public int Id { get; set; } // primary key 

        [StringLength(100)]
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Required]
        public Diet Diet {get; set; } 

        [Required]
        public MealType MealType {get; set; }

        [Required(ErrorMessage = "Ingredients are required")]
        public string RecipeIngredients {get; set;}

        [Required(ErrorMessage = "Method steps are required")]
        public string Method { get; set; }

        [Required(ErrorMessage = "Preparation time is required")]
        [Range(0,1000)]
        public int PrepTime{ get; set; } 

        [Required(ErrorMessage = "Cooking Time is required")]
        [Range(0,1000)]
        public int CookTime{ get; set; } 

        [Required(ErrorMessage = "The recipes cuisine is required")]
        public string Cuisine { get; set; }

        [Required]
        public Region Region {get; set; }

        [Required(ErrorMessage = "Please try an enter some translation of your recipe in the cuisines language")]
        public string Translator {get; set; } 

        public int Calories {get; set; } //not required 

        public int Servings {get; set; } //not required

        [Required(ErrorMessage = "Your recipe cost must be entered")]
        public double Price {get; set; }

        [UrlResource]
        [Required(ErrorMessage = "You must enter a recipe photo")]
        public string PhotoUrl { get; set; }    

      
      // ReadOnly Property - Calculates Rating % based on average of all reviews
        public int Rating
        {
            get
            {
                var count = Reviews.Count > 0 ? Reviews.Count : 1;
                return Reviews.AsEnumerable().Sum(r => r.Rating) / count * 10;
            }
        }

        // EF Relationship - a recipe can have many reviews 
        public IList<Review> Reviews { get; set; } = new List<Review>();

        public int UserId {get; set; } //forgein key

        public User User {get; set; } //navigational property
    }
}