using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SMS.Data.Models;
using SMS.Data.Repository;
using SMS.Data.Security;

namespace SMS.Data.Services
{
    public class FoodServiceDb : IFoodService
    {
        private readonly DataContext db;

        public FoodServiceDb()
        {
            db = new DataContext();
        }

        public void Initialise()
        {
            db.Initialise(); // recreate database
        }

       // ==================== User Management ==================
        public User Authenticate(string email, string password)
        {
            // retrieve the user based on the EmailAddress (assumes EmailAddress is unique)
            var user = GetUserByEmailAddress(email);

            // Verify the user exists and Hashed User password matches the password provided
            return (user != null && Hasher.ValidateHash(user.Password, password)) ? user : null;
        }

        public User Register(string name, string email, string password, Role role, string nationality, string cookingExperience, string photoUrl)
        {
            // check that the user does not already exist (unique user name)
            var exists = GetUserByEmailAddress(email);
            if (exists != null)
            {
                return null;
            }

            // Custom Hasher used to encrypt the password before storing in database
            var user = new User 
            {
                Name = name,
                Email = email,
                Password = Hasher.CalculateHash(password),
                Role = Role.member,
                Nationality = nationality,
                CookingExperience = cookingExperience,
                PhotoUrl = photoUrl 
            };
   
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        // retrieve list of Users
        public IList<User> GetUsers()
        {
            return db.Users.ToList();
        }

        
        // Retrive user by Id and related recipes
        public User GetUser(int id)
        {
            return db.Users
                     .Include(r => r.Recipes)
                     .FirstOrDefault(r => r.Id == id);
        }
       
 
        // Add a new User checking a User with same email does not exist
        public User AddUser(string name, string email, string password, Role role, string nationality, string cookingExperience, string photoUrl)
        {     
            var existing = GetUserByEmailAddress(email);
            if (existing != null)
            {
                return null;
            } 

            var user = new User
            {            
                Name = name,
                Email = email,
                Password = Hasher.CalculateHash(password), 
                Role = role,
                Nationality = nationality,
                CookingExperience = cookingExperience,
                PhotoUrl = photoUrl         
            };
            db.Users.Add(user);
            db.SaveChanges();
            return user; // return newly added User
        }

        // Delete the user identified by Id returning true if 
        // deleted and false if not found
        public bool DeleteUser(int id)
        {
            var u = GetUser(id);

            if (u == null)
            {
                return false;
            }
            db.Users.Remove(u);
            db.SaveChanges();
            return true;
        }

        // Update the user with the details in updated 
        public User UpdateUser(User updated)
        {
            // verify the user exists
            var User = GetUser(updated.Id);
            if (User == null)
            {
                return null;
            }

            // verify email address is registered or available to this user
            if (!IsDuplicateUserEmailEdit(updated.Email, updated.Id))
            {
                return null;
            }

            // update the details of the user retrieved and save
            User.Name = updated.Name;
            User.Email = updated.Email;
            User.Password = Hasher.CalculateHash(updated.Password); 
            User.Role = updated.Role;
            User.Nationality = updated.Nationality;
            User.CookingExperience = updated.CookingExperience;
            User.PhotoUrl = updated.PhotoUrl;
          

            db.SaveChanges();
            return User;
        }

        //Get user by email address
        public User GetUserByEmailAddress(string email)
        {
            return db.Users.FirstOrDefault(u => u.Email == email);
        }

        //Check if email already exists creating a new user
        public bool IsDuplicateUserEmailCreate(string email, int userId) 
        {
            var existing = GetUserByEmailAddress(email); 
            return existing != null && userId != existing.Id;
        }

        //Check if email already exists for edit user
        public bool IsDuplicateUserEmailEdit(string email, int userId) 
        {

            return db.Users.FirstOrDefault(u => u.Email == email && u.Id != userId) == null;
            
        }
                   


        //Perform a search of the usesrs based on a query and range 'ALL'
        public IList<User> SearchAllUsers(AllUsers range, string query) 
        {
            // ensure query is not null    
            query = query == null ? "" : query.ToLower();

            // search recipe - fix
            var results =  db.Users
                            .Where(t => (t.Name.ToLower().Contains(query) || t.Nationality.ToLower().Contains(query) || 
                            t.Email.ToLower().Contains(query)) && 
                            (range == AllUsers.ALL)).ToList();

                            return (results);
          
        }

        // ===================== Recipe Management ==========================

        //Retrieve a list of recipes
        public IList<Recipe> GetRecipes()
        {
            return db.Recipes.ToList();
        }     

        //Create a new recipe for a user 
        public Recipe CreateRecipe(int userId, string name, Diet diet, MealType mealType, string recipeIngredients, string method, int prepTime, int cookTime, string cuisine, Region region, string translator, int calories, int servings, double price, string photoUrl)
        {
            var user = GetUser(userId);
            if (user == null) return null;

            var recipe = new Recipe
            {
                // Id created by Database
                Name = name,
                Diet = diet,
                MealType = mealType,
                RecipeIngredients = recipeIngredients,
                Method = method,
                PrepTime = prepTime,
                CookTime = cookTime,
                Cuisine = cuisine,
                Region = region,
                Translator = translator,
                Calories = calories,
                Servings = servings,
                Price = price,
                PhotoUrl = photoUrl,
                UserId = userId,
            };

            db.Recipes.Add(recipe);
            db.SaveChanges(); // write to database
            return recipe;
        }
        
        //Get recipe for related user or not if not found 
        public Recipe GetRecipeById(int id)
        {
            return db.Recipes
                     .Include(u => u.Reviews)
                     .FirstOrDefault(u => u.Id == id);
                     
        }

        //Delete recipe
        public bool DeleteRecipe(int id)
        {
            // find recipe
            var recipe = GetRecipeById(id);
            if (recipe == null) return false;
            
            // remove recipe 
            var result = db.Recipes.Remove(recipe);
            
            db.SaveChanges();
            return true;
        }

        // Retrieve all Recipes and the user associated with the recipe
        public IList<Recipe> GetAllRecipes()
        {
            return db.Recipes
                     .Include(u => u.User)
                     .Include(u => u.Reviews)
                     .ToList();
        }

        
        // Update an existing recipe
        public Recipe UpdateRecipe(Recipe updated)
        {
            // verify the recipe exists
            var recipe = GetRecipeById(updated.Id);
            if (recipe == null)
            {
                return null;
            }

            // update the details of the recipe retrieved and save
            recipe.Name = updated.Name;
            recipe.Diet = updated.Diet;
            recipe.MealType = updated.MealType;
            recipe.RecipeIngredients = updated.RecipeIngredients;
            recipe.Method = updated.Method;
            recipe.PrepTime = updated.PrepTime;
            recipe.CookTime = updated.CookTime;
            recipe.Cuisine = updated.Cuisine;
            recipe.Region = updated.Region;
            recipe.Translator = updated.Translator;
            recipe.Calories = updated.Calories;
            recipe.Servings = updated.Servings;
            recipe.Price = updated.Price;
            recipe.PhotoUrl = updated.PhotoUrl;            

            db.SaveChanges();
            return recipe;
        }


        // // // perform a search of the members recipes based on a query and
        // // // a range 'ALL', 'Omnivorous', 'Vegetarian', 'Vegan'
        public IList<Recipe> SearchMyRecipes(Diet range, int userId, string query)
        {
            // ensure query is not null    
            query = query == null ? "" : query.ToLower();

            // search recipe by multiple queries, by range and by users id
            var results = db.Recipes
                            .Where(t => (t.Name.ToLower().Contains(query) || t.RecipeIngredients.ToLower().Contains(query) || 
                            t.Cuisine.ToLower().Contains(query) || t.Translator.ToLower().Contains(query)) && 
                            (range == Diet.ALL || range == Diet.Vegetarian  || range == Diet.Vegan || range == Diet.Omnivorous
                            ) && t.UserId == userId).ToList();

                            return results;
        }

        // // // perform a search of all recipes based on a query and
        // // // a range 'ALL', 'Omnivorous', 'Vegetarian', 'Vegan'
        public IList<Recipe> SearchAllRecipes(Diet range, string query) 
        {
            // ensure query is not null    
            query = query == null ? "" : query.ToLower();

            // search recipe
                    var results =  db.Recipes
                    .Include(t => t.User)

                            .Where(t => (t.Name.ToLower().Contains(query) || t.RecipeIngredients.ToLower().Contains(query) || 
                            t.Cuisine.ToLower().Contains(query) || t.Translator.ToLower().Contains(query)) && 
                            (range == Diet.ALL || range == Diet.Vegetarian || range == Diet.Vegan || range == Diet.Omnivorous
                            )).ToList();

                            return results;
        }

        // ===================== Review Management ==========================
        
        //Get a review by Id
        public Review GetReviewById(int id)
        {
            return db.Reviews
                     .Include(r => r.Recipe)                 //returns review and recipe
                     .FirstOrDefault(r => r.Id == id);      
        }

        // Add a new Review to a recipe
        public Review AddReview(Review r)
        {
            var recipe = GetRecipeById(r.RecipeId);        
            if (recipe == null)                          //if recipe == null that means it doesnt exist and we cannot assign a recipe to it, so we return null.
            {
                return null;
            }

            var review = new Review                     //create the new review and assign the properties
            {
                Name = r.Name,
                RecipeId = r.Id,
                ReviewedOn = DateTime.Now,
                Rating = r.Rating,
                Comment = r.Comment,
            };

            recipe.Reviews.Add(review);  
            db.SaveChanges();           
            return review;              
        }

        // Update an existing review
        public Review UpdateReview(Review updated)
        {
            // verify the recipe exists
            var review = GetReviewById(updated.Id);
            if (review == null)
            {
                return null;
            }

            // update the details of the recipe retrieved and save
            review.Name = updated.Name;
            review.ReviewedOn = updated.ReviewedOn;
            review.Comment = updated.Comment;
            review.Rating = updated.Rating;
                       

            db.SaveChanges();
            return review;
        }

        
   
        //Delete a Review given its id
        public bool DeleteReview(int id)
        {
            //find review
            var review = GetReviewById(id);     //retrieve review with its id
            if (review == null)                 //if review is null, it doesnt exist so we return false
            {
                return false;
            }

            //else, remove review
            db.Reviews.Remove(review); 
            db.SaveChanges();
            return true;                
        }

    }
}
