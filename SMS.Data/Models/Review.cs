using System.ComponentModel.DataAnnotations; 

namespace SMS.Data.Models
{
    public class Review
    {     
        public int Id { get; set; }      

        // name of member reviewing recipe
        [Display(Name ="Your name")]   
        [Required]
        [StringLength(20, ErrorMessage = "{0} must be between {2} - {1} characters long.", MinimumLength = 3)]    //personalised validation messages for all attributes
        public string Name { get; set; }   

        // date review was made
        [Required]        
        public DateTime ReviewedOn { get; set; }

        // reviewer comments
        [Display(Name ="Thoughts on the recipe?")] 
        [Required]
        [StringLength(100, ErrorMessage = "{0} must be between {2} - {1} characters long.", MinimumLength = 2)]
        public string Comment { get; set; }

        // value between 1-10
        [Display(Name ="Rating (1 - 10)")] 
        [Required]
        [Range(1,10, ErrorMessage = "Please enter a value between {1} - {2}.")] 
        public int Rating { get; set; }
    
        // EF Dependant Relationship Review belongs to a Recipe
        public int RecipeId { get; set; }  //Foreign Key

        // Navigation property
        public Recipe Recipe { get; set; }
 
    }
}