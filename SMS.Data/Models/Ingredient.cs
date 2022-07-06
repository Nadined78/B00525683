// using System.ComponentModel.DataAnnotations;
// using System.Text.Json.Serialization;

// namespace SMS.Data.Models
// {
//     public class Ingredient
//     {
//         public int IngredientId { get; set; }
        
//         [Required]
//         [StringLength(500, MinimumLength = 5)]
//         public string Name { get; set; }    

//         // public virtual ICollection<Recipe> Recipes {get; set;}

//         // public Ingredient()
//         // {
//         //     Recipes = new HashSet<Recipe>();
//         // }    


//         IList<RecipeIngredient> RecipeIngredients {get; set;} = new List<RecipeIngredient>();

//         // ingredient owned by a recipe
//         public int RecipeId { get; set; }      // foreign key
        
//         public Recipe Recipe { get; set; }    // navigation property
//     } 

// }

