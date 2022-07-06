using System;
using System.ComponentModel.DataAnnotations;
using SMS.Data.Validators; // allows access to UrlResource


namespace SMS.Data.Models
{
    public enum MealType { Breakfast, Lunch, Dinner, Snack }

    public enum Diet { Omnivorous, Vegetarian, Vegan }

    // used in ingredient search feature
    public enum recipeSearch { Omnivorous, Vegetarian, Vegan, ALL }

    public class Recipe
    {

        public int RecipeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Diet Diet {get; set; } 

        [Required]
        public MealType MealType {get; set; }

        // [Required]
        // public string RecipeIngredients {get; set;}  //public List<Ingredient> Ingredient { get; set; } = new();

        [Required]
        public string Method { get; set; }

        [Required]
        [Range(0,1000)]
        public int PrepTime{ get; set; } 

        [Required]
        [Range(0,1000)]
        public int CookTime{ get; set; } 

        [Required]
        [Range(0,100)]
        public string Cuisine { get; set; }

        public string Region {get; set; }

        public string Translator {get; set; }

        public int Calories {get; set; }

        public int Servings {get; set; }

        [UrlResource]
        public string PhotoUrl { get; set; }    

        public int UserId {get; set; } //foregin key

        public User User {get; set; } //navigational property
        
        // // // Relationship 1:M Ingredient - Recipes
        // public IList<RecipeIngredient> Ingredients {get; set;} = new List<RecipeIngredient>();



    }
}