using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMS.Data.Models;


namespace SMS.Web.ViewModels
{
    public class RecipeCreateViewModel
    {
        // selectlist of users (id, name)       
        public SelectList Users { set; get; }

        
        [Required(ErrorMessage = "Please select a user")]
        [Display(Name = "Select User")]
        public int UserId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public Diet Diet {get; set; } 

        [Required]
        public MealType MealType {get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string RecipeIngredients {get; set;} 

        [Required]
        [StringLength(2000, MinimumLength = 25)]
        public string Method { get; set; }

        [Required]
        [Range(0,1000)]
        public int PrepTime{ get; set; } 

        [Required]
        [Range(0,1000)]
        public int CookTime{ get; set; } 

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Cuisine { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public Region Region {get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string Translator {get; set; }

        [Required] 
        public int Calories {get; set; }

        [Required]
        public int Servings {get; set; }

        [Required]
        public double Price {get; set; }

        [Required]
        public string PhotoUrl { get; set; }
    }

}
