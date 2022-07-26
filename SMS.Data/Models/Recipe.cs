using System.ComponentModel.DataAnnotations;
using SMS.Data.Validators; // allows access to UrlResource


namespace SMS.Data.Models
{
    public enum MealType { Breakfast, Lunch, Dinner, Snack }

    public enum Diet { Omnivorous, Vegetarian, Vegan }

    public enum Region { Africa, Asia, CentralAmerica, Europe, MiddleEast, NorthAmerica, Oceania, SouthAmerica, Caribbean }

    // used in ingredient search feature
    public enum AllRecipes { ALL, Vegetarian, Vegan, Omnivorous}

    public class Recipe
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Diet Diet {get; set; } 

        [Required]
        public MealType MealType {get; set; }

        [Required]
        public string RecipeIngredients {get; set;}

        [Required]
        public string Method { get; set; }

        [Required]
        [Range(0,1000)]
        public int PrepTime{ get; set; } 

        [Required]
        [Range(0,1000)]
        public int CookTime{ get; set; } 

        [Required]
        public string Cuisine { get; set; }

        [Required]
        public Region Region {get; set; }

        public string Translator {get; set; }

        public int Calories {get; set; }

        public int Servings {get; set; }

        [UrlResource]
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
        public int UserId {get; set; } //foregin key - possibly change this to id in the model

        public User User {get; set; } //navigational property
    }
}