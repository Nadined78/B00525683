using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SMS.Data.Models;

namespace SMS.Web.ViewModels
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
 
        [Required]
        [EmailAddress]
        [Remote(action: "VerifyEmailAvailable", controller: "User", AdditionalFields = nameof(Id))]
        public string Email { get; set; }

        [Required]
        public Role Role { get; set; }

        [Required]
        public string Nationality {get; set;}

        [Required]
        public string PhotoUrl {get; set;}


    }
}