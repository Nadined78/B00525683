using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SMS.Web.ViewModels
{
    public class UserPasswordViewModel
    {
        public int Id { get; set; }

        [Required]
        [Remote(action: "VerifyPassword", controller: "User")]
        public string OldPassword { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage ="The {0} must be at least {2} characters long", MinimumLength =4)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string PasswordConfirm  { get; set; }

    }
}