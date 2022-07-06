using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using SMS.Data.Models;

namespace SMS.Data.Repository
{

    public class DataContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        
        // public DbSet<Ingredient> Ingredients { get; set; }

        // public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        
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
