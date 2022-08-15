using System;
using System.Collections.Generic; 
using System.Linq;
using System.ComponentModel.DataAnnotations; 

namespace SMS.Data.Models {
     
    public enum Role { admin, member } 
    
    // used in user search feature
    public enum AllUsers { ALL}

    public class User {
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Required(ErrorMessage = "Email Required")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [StringLength(50, ErrorMessage ="The {0} must be at least {2} characters long", MinimumLength =4)]
        public string Password { get; set; }

        public Role Role { get; set; } 

        [Required(ErrorMessage = "Nationality Required")]
        public string Nationality {get; set; }

        public string CookingExperience {get; set;}

        public string PhotoUrl { get; set; }

        //relationship 1-M - A user can have mutiple recipes 
        
        public IList<Recipe> Recipes {get; set; } = new List<Recipe>();

    }
}
