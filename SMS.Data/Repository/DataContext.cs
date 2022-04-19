using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using SMS.Data.Models;

namespace SMS.Data.Repository
{

    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<StudentModule> StudentModules { get; set; }
        
        public DbSet<User> Users { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlite("Filename=data.db")
            .LogTo(Console.WriteLine, LogLevel.Information);
        }

        // custom method used in development to keep database in sync with models
        public void Initialise() 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        
    }
} 
