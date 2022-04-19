using System;

namespace SMS.Data.Models
{
    public class StudentModule
    {
        public int Id { get; set; }
        public double Mark {get; set; }

        // Foreign key for related Student model
        public int StudentId { get; set; }
        public Student Student { get; set; }

        // Foreign key for related Module model
        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
