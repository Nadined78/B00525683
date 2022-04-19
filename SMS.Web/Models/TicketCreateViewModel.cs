using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SMS.Web.Models
{
    public class TicketCreateViewModel
    {
        // selectlist of students (id, name)       
        public SelectList Students { set; get; }

        // Collecting StudentId and Issue in Form
        [Required(ErrorMessage = "Please select a student")]
        [Display(Name = "Select Student")]
        public int StudentId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Issue { get; set; }
    }

}
