using SMS.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace SMS.Web.ViewModels
{
    public class ReviewViewModel
    {

        public int Id { get; set; }      

        [Display(Name ="Your name")]   
        [Required]
        [StringLength(20, ErrorMessage = "{0} must be between {2} - {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        public DateTime ReviewedOn { get; set; }

        [Display(Name ="Thoughts on the recipe?")] 
        [Required]
        [StringLength(100, ErrorMessage = "{0} must be between {2} - {1} characters long.", MinimumLength = 2)]
        public string Comment { get; set; }

        [Display(Name ="Rating (1 - 10)")] 
        [Required]
        [Range(1,10, ErrorMessage = "Please enter a value between {1} - {2}.")] 
        public int Rating { get; set; }
       
        public int RecipeId { get; set; }  

        public Recipe Recipe { get; set; }


    }

}