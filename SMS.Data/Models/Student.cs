using System;
using System.ComponentModel.DataAnnotations;
using SMS.Data.Validators; // allows access to UrlResource

namespace SMS.Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Course { get; set; }

        [Required]
        [Range(16,80)]
        public int Age { get; set; } 

        [Required]
        [Range(0,100)]
        public double Grade { get; set; }

        [UrlResource]
        public string PhotoUrl { get; set; }     

        // Relationship 1-N tickets
        public IList<Ticket> Tickets {get; set; } = new List<Ticket>();
        
        // Relationship M:M Students - Modules
        public IList<StudentModule> StudentModules {get; set;} = new List<StudentModule>();

        // Read-Only property - not stored in database
        public string Classification => Classify();

        // private method to calculate the classification
        private string Classify() {
            if (Grade < 50)
            {
                return "Fail";
            }
            else if (Grade >=50 && Grade < 70)
            {
                return "Pass";
            }
            else if (Grade >=70 && Grade < 80)
            {
                return "Commendation";
            }
            else
            {
                return "Distinction";
            }
        }

    }
}