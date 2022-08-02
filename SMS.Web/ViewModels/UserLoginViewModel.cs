using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SMS.Data.Models;

namespace SMS.Web.ViewModels
{
    public class UserLoginViewModel
    {       
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        // [Display(Name = "Remember me?")]
        // public bool RememberMe { get; set; }
    }
}
