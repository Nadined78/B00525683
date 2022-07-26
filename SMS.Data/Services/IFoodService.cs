using System;
using System.Collections.Generic;
	
using SMS.Data.Models;
	
namespace SMS.Data.Services
{
    // This interface describes the operations that a FoodService class should implement
    public interface IFoodService
    {
        // Initialise the repository (database)  
        void Initialise();

        // ------------- User Management -------------------

        IList<User> GetUsers();
        User GetUser(int id);
        User GetUserByEmailAddress(string email);
        User Authenticate(string email, string password);
        // User Register(string name, string email, string password, Role role, string nationality, string photoUrl);

        User AddUser(string name, string email, string password, Role role, string nationality, string photoUrl);
        User UpdateUser (User user);
        bool DeleteUser(int id);
        bool IsDuplicateUserEmail(string email, int userId);

        // ---------------- Food Management --------------

        IList<Recipe> GetAllRecipes();   
      
        Recipe GetRecipeById(int id);

        

        Recipe CreateRecipe(int userId, string name, Diet diet, MealType mealType, string recipeIngredients, string method, int prepTime, int cookTime, string cuisine, Region region, string translator, int calories, int servings, string photoUrl);
        Recipe UpdateRecipe(Recipe updated);  
        bool    DeleteRecipe(int id);

        // ---------------- Search Feature --------------

        IList<Recipe> SearchAllRecipes(AllRecipes range, string query);  
        IList<Recipe> SearchMyRecipes(AllRecipes range, int userId, string query);  

        IList<User> SearchAllUsers(AllUsers range, string query);


        // ---------------- Review of Recipe --------------

        Review GetReviewById(int id);
        Review AddReview(Review r);
        bool DeleteReview(int id);
       
    }
    
}