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

        public User Register(string name, string email, string password, Role role, DateTime createdOn, string photoUrl)
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
                Role = role,
                CreatedOn = createdOn,
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

        // Retrive user by Id and related tickets

        public User GetUser(int id)
        {
            return db.Users
                     .Include(r => r.Recipes)
                     .FirstOrDefault(r => r.UserId == id);
        }

        
        //Admin can add a new user - checking email is unique

        public User AddUser(string name, string email, string password, Role role, DateTime createdOn, string photoUrl)
        {
            // check if user with email exists            
            var exists = GetUserByEmailAddress(email);
            if (exists != null)
            {
                return null;
            } 

            // create new user
            var u = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Role = role,
                CreatedOn = createdOn,
                PhotoUrl = photoUrl
            };

            db.Users.Add(u); // add user to the list
            db.SaveChanges();
            return u; // return newly added user
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
            var User = GetUser(updated.UserId);
            if (User == null)
            {
                return null;
            }

            if (!IsDuplicateUserEmail(updated.Email, updated.UserId))
            {
                return null;
            }

            // update the details of the user retrieved and save
            User.Name = updated.Name;
            User.Email = updated.Email;
            User.Password = updated.Password;
            User.Role = updated.Role;
            User.PhotoUrl = updated.PhotoUrl;

            db.SaveChanges();
            return User;
        }

        public User GetUserByEmailAddress(string email)
        {
            return db.Users.FirstOrDefault(u => u.Email == email);
        }
       
        public bool IsDuplicateUserEmail(string email, int userId) 
        {
            var existing = GetUserByEmailAddress(email);
            // if a user with email exists and the Id does not match
            // the userId (if provided), then they cannot use the email
            return existing != null && userId != existing.UserId;           
        }


        // ===================== Recipe Management ==========================

        public IList<Recipe> GetRecipes()
        {
            return db.Recipes.ToList();
        }     

        public Recipe CreateRecipe(int userId, string name, Diet diet, MealType mealType, string recipeIngredients, string method, int prepTime, int cookTime, string cuisine, string region, string translator, int calories, int servings, string photoUrl)
        {
            var user = GetUser(userId);
            if (user == null) return null;

            var recipe = new Recipe
            {
                // Id created by Database
                UserId = userId,
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
                PhotoUrl = photoUrl  
            };

            db.Recipes.Add(recipe);
            db.SaveChanges(); // write to database
            return recipe;
        }
        

        public Recipe GetRecipeById(int id)
        {
            // return recipe and related user or null if not found
            return db.Recipes
                     .Include(u => u.User)
                     .FirstOrDefault(u => u.RecipeId == id);
                     
        }

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
                     .ToList();
        }

        public Recipe UpdateRecipe(Recipe updated)
        {
            // verify the recipe exists
            var recipe = GetRecipeById(updated.RecipeId);
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
            recipe.PhotoUrl = updated.PhotoUrl;            

            db.SaveChanges();
            return recipe;
        }


        // // // perform a search of the recipes based on a query and
        // // // an active range 'ALL', 'Chicken', 'Beef', 'Fish' - possibly change this to vegan vegetarian etc
        public IList<Recipe> SearchRecipes(recipeSearch range, string query) 
        {
            // ensure query is not null    
            query = query == null ? "" : query.ToLower();

            // search recipe, active status and users name
            var results = db.Recipes
                            .Include(t => t.User)
                            .Where(t => (t.RecipeIngredients.ToLower().Contains(query) || t.Cuisine.ToLower().Contains(query) || t.Translator.ToLower().Contains(query)
                                        ) &&
                                        (range == recipeSearch.ALL ||
                                         range == recipeSearch.Omnivorous ||
                                         range == recipeSearch.Vegetarian ||
                                         range == recipeSearch.Vegan
                                        ) 
                            ).ToList();
            return  results;  
        }

        //Get a review by Id
        public Review GetReviewById(int id)
        {
            return db.Reviews
                     .Include(r => r.Recipe)                 //returns review and recipe
                     .FirstOrDefault(r => r.Id == id);      
        }

        // Add a new Review to a movie 
        public Review AddReview(Review r)
        {
            var recipe = GetRecipeById(r.RecipeId);        //first we need to check if the recipe we want to add a review to exists
            if (recipe == null)                          //if recipe == null that means it doesnt exist and we cannot assign a recipe to it, so we return null.
            {
                return null;
            }

            var review = new Review                     //create the new review and assign the properties
            {
                Name = r.Name,
                RecipeId = r.RecipeId,
                ReviewedOn = DateTime.Now,
                Rating = r.Rating,
                Comment = r.Comment,
            };

            recipe.Reviews.Add(review);  
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
