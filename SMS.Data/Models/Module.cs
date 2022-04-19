using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    public class Module
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
            
        // Navigation property
        IList<StudentModule> StudentModules { get; set; } = new List<StudentModule>();
    }
}
