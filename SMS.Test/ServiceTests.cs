using Xunit;
using SMS.Data.Models;
using SMS.Data.Services;

namespace SMS.Test
{

    public class ServiceTests
    {
        private readonly IFoodService svc;

        public ServiceTests()
        {
            // general arrangement
            svc = new FoodServiceDb();

            // ensure data source is empty before each test
            svc.Initialise();
        }

        // ========================== User Tests =========================
        
        [Fact]
        public void LoginWithValidCredentialsShouldWork()
        {
            // arrange
            svc.AddUser("admin", "admin@mail.com", "admin", Role.admin, "irish", "", "");
            
            // act            
            var user = svc.Authenticate("admin@mail.com","admin");

            // assert
            Assert.NotNull(user);
           
        }

        [Fact]
        public void LoginWithInvalidCredentialsShouldNotWork()
        {
            // arrange
            svc.AddUser("admin", "admin@mail.com", "admin", Role.admin, "irish", "", "");

            // act      
            var user = svc.Authenticate("admin@mail.com","xxx");

            // assert
            Assert.Null(user);
           
        }


        [Fact] 
        public void User_AddUser_WhenDuplicateEmail_ShouldReturnNull()
        {
            // act 
            var u1 = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "irish", "",  "");
            // this is a duplicate as the email address is same as previous user
            var u2 = svc.AddUser("XXX", "xxx@email.com", "saoirse123", Role.member, "irish", "",  "");
            
            // assert
            Assert.NotNull(u1); // this user should have been added correctly
            Assert.Null(u2); // this user should NOT have been added        
        }

        [Fact]
        public void User_AddUser_WhenNone_ShouldSetAllProperties()
        {
            // act 
            var added = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            
            // retrieve user just added by using the Id returned by EF
            var u = svc.GetUser(added.Id);

            // assert - that user is not null
            Assert.NotNull(u);
            
            // now assert that the properties were set properly
            Assert.Equal(u.Id, u.Id);
            Assert.Equal("XXX", u.Name);
            Assert.Equal("xxx@email.com", u.Email);
            Assert.NotEqual("angelo123", u.Password);
            Assert.Equal(Role.member, u.Role);
            Assert.Equal("xxx", u.Nationality);
            Assert.Equal("xxx", u.CookingExperience);
        }

        [Fact]
        public void User_UpdateUser_ThatExists_ShouldSetAllProperties()
        {
            // arrange - create test user
            var s = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
                        
            // act - create a copy and update any user properties (except Id) 
            var u = new User {
                Id = s.Id,
                Name = "ZZZ",
                Email = "zzz@email.com",
                Password = "michael123",
                Role = Role.admin,
                Nationality = "zzz",
                CookingExperience = "zzz",
                PhotoUrl = "http://photo.com"
            };
            // save updated user
            svc.UpdateUser(u); 

            // reload updated user from database into us
            var us = svc.GetUser(s.Id);

            // assert
            Assert.NotNull(u);           

            // now assert that the properties were set properly           
            Assert.Equal(u.Name, us.Name);
            Assert.Equal(u.Email, us.Email);
            Assert.NotEqual(u.Password, us.Password);
            Assert.Equal(u.Role, us.Role);
            Assert.Equal(u.Nationality, us.Nationality);
            Assert.Equal(u.CookingExperience, us.CookingExperience);
            Assert.Equal(u.PhotoUrl, us.PhotoUrl);
            
        }

        [Fact] 
        public void User_GetAllUser_WhenNone_ShouldReturn0()
        {
            // act 
            var users= svc.GetUsers();
            var count = users.Count;

            // assert
            Assert.Equal(0, count);
        }


        [Fact]
        public void User_GetUsers_When2Exist_ShouldReturn2()
        {
            // arrange
            var u1 = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            var u2 = svc.AddUser("YYY", "yyy@email.com", "michael123", Role.member, "yyy", "yyy", "");

            // act
            var users = svc.GetUsers();
            var count = users.Count;

            // assert
            Assert.Equal(2, count);
        }


        [Fact] 
        public void User_GetUser_WhenNonExistent_ShouldReturnNull()
        {
            // act 
            var user = svc.GetUser(1); // non existent user

            // assert
            Assert.Null(user);
        }

        [Fact] 
        public void User_GetUser_ThatExists_ShouldReturnUser()
        {
            // act 
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");

            var nu = svc.GetUser(u.Id);

            // assert
            Assert.NotNull(nu);
            Assert.Equal(u.Id, nu.Id);
        }

        [Fact] 
        public void User_GetUser_ThatExistsWithRecipes_ShouldReturnUserWithRecipes()
        {
            // arrange 
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "x", "Simmer", 20, 20, "italian", Region.Africa, "Spaghetti alla Carbonara", 460, 2, 1.90, "");
            svc.CreateRecipe(u.Id, "Spaghetti Bolognese", Diet.Omnivorous, MealType.Dinner, "x", "Sweat off onions", 25, 90, "italian", Region.Europe, "spaghetti alla bolognese", 576, 4, 2.10, "");
            
            // act
            var user = svc.GetUser(u.Id);

            // assert
            Assert.NotNull(u);    
            Assert.Equal(2, user.Recipes.Count);
        }

        [Fact]
        public void User_DeleteUser_ThatExists_ShouldReturnTrue()
        {
            // act 
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            var deleted = svc.DeleteUser(u.Id);

            // try to retrieve deleted user
            var u1 = svc.GetUser(u.Id);

            // assert
            Assert.True(deleted); // delete user should return true
            Assert.Null(u1);      // u1 should be null
        }

        [Fact]
        public void User_DeleteUser_ThatDoesntExist_ShouldReturnFalse()
        {
            // act 	
            var deleted = svc.DeleteUser(0);

            // assert
            Assert.False(deleted);
        }        

        [Fact]
        public void User_UpdateUser_ThatExistsWithNewRole_ShouldWork()
        {
            // arrange
            var added = svc.AddUser("Nadine", "nadine@gmail.com", "password", Role.member, "xxx", "xxx", "");

            // act
            // create a copy of added user and update their role from member to admin
            var u = new User {
                Id = added.Id,
                Name = added.Name,
                Email = added.Email,
                Password = added.Password,
                Role = Role.admin,
                Nationality = added.Nationality,
                CookingExperience = added.CookingExperience,
                PhotoUrl = added.PhotoUrl              
            };
            // update this user
            svc.UpdateUser(u);

            // now load the user and verify age was updated
            var nu = svc.GetUser(u.Id);

            // assert
            Assert.Equal(u.Role, nu.Role);
        }


         [Fact] // --- Add user Valid User test
        public void User_AddUser_WhenValid_ShouldReturnUser()
        {
            // arrange 
            var add = svc.AddUser("XXX", "xxx@email.com", "password", Role.member, "xxx", "xxx", "");
            
            // act
            var user = svc.GetUserByEmailAddress(add.Email);
            
            // assert
            Assert.NotNull(add);
            Assert.NotNull(user);
        } 

        [Fact] // --- Add user Duplicate Test
        public void User_Add_WhenDuplicateEmail_ShouldReturnNull()
        {
            // arrange 
            var u1 = svc.AddUser("XXX", "xxx@email.com", "password", Role.member, "xxx", "xxx", "");
            
            // act
            var u2 = svc.AddUser("YYY", "xxx@email.com", "admin", Role.member, "yyy", "yyy", "");

            // assert
            Assert.NotNull(u1);
            Assert.Null(u2);
        } 

        [Fact] // --- Authenticate Invalid Test
        public void User_Authenticate_WhenInValidCredentials_ShouldReturnNull()
        {
            // arrange 
            var u1 = svc.AddUser("XXX", "xxx@email.com", "password", Role.member, "xxx", "xxx", "");
        
            // act
            var user = svc.Authenticate("xxx@email.com", "guest");

            // assert
            Assert.Null(user);

        } 

        [Fact] // --- Authenticate Valid Test
        public void User_Authenticate_WhenValidCredentials_ShouldReturnUser()
        {
            // arrange 
            var u1 = svc.AddUser("XXX", "xxx@email.com", "password", Role.member, "xxx", "xxx", "");
        
            // act
            var user = svc.Authenticate("xxx@email.com", "password");
            
            // assert
            Assert.NotNull(user);
        } 


        // ---------------------- Recipes Tests ------------------------
        
        [Fact]
         public void GetAllRecipes_GetRecipesWhenNoneExist_ShouldReturnNone()
        {
            //act
            var recipes = svc.GetAllRecipes();
            var count = recipes.Count;

            //assert
            Assert.Equal(0, count);

        }

        
        [Fact]
        public void GetAllRecipes_GetRecipesWith2Added_ShouldReturn2()
        {
            //arrange - adding 2 recipes for a user
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "x", "Simmer", 20, 20, "italian", Region.Africa, "Spaghetti alla Carbonara", 460, 2, 1.90, "");
            svc.CreateRecipe(u.Id, "Spaghetti Bolognese", Diet.Omnivorous, MealType.Dinner, "x", "Sweat off onions", 25, 90, "italian", Region.Europe, "spaghetti alla bolognese", 576, 4, 2.10, "");
                        

            //act - retive number of recipes in the database
            var totalRecipes = svc.GetAllRecipes();
            var count = totalRecipes.Count;

            //assert - assert that the count is 2
            Assert.Equal(2, count);

        }

        [Fact] 
        public void Recipe_GetRecipe_WhenNonExistent_ShouldReturnNull()
        {
            // act 
            var recipe = svc.GetRecipeById(1); // non existent recipe

            // assert
            Assert.Null(recipe);
        }

        [Fact] 
        public void Recipe_GetRecipe_ThatExists_ShouldReturnRecipe()
        {
            // act 
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "x", "Simmer", 20, 20, "italian", Region.Africa, "Spaghetti alla Carbonara", 460, 2, 1.90, "");

            var re = svc.GetRecipeById(u.Id);

            // assert
            Assert.NotNull(re);
            Assert.Equal(u.Id, re.Id);
        }


        [Fact] 
        public void Recipe_CreateRecipe_ForExistingUser_ShouldBeCreated()
        {
            // arrange
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
         
            // act
            var r = svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "", "Simmer", 20, 20, "italian", Region.Africa, "Spaghetti alla Carbonara", 460, 2, 1.90, "");
           
            // assert
            Assert.NotNull(r);
            Assert.Equal(u.Id, r.UserId);
        }

        
        [Fact]
        public void GetRecipeById_WhenRecipeExists_ShouldReturnRecipe()
        {
            //arrange - add user with a recipe
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            var r = svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "", "Simmer", 20, 20, "italian", Region.Africa, "Spaghetti alla Carbonara", 460, 2, 1.90, "");
            
            //act
            var r2 = svc.GetRecipeById(r.Id); 
            
            //assert - assert both recipes are not null and that retrieving an existing recipe with an id works 
             Assert.NotNull(r2);    
             Assert.NotNull(r);
             Assert.Equal(r.Id, r2.Id);  
        }



        [Fact] // --- GetRecipe should include User
        public void Recipe_GetRecipe_WhenExists_ShouldReturnRecipeAndUser()
        {
            // arrange
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            var r = svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "", "Simmer", 20, 20, "italian", Region.Africa, "Spaghetti alla Carbonara", 460, 2, 1.90, "");

            // act
            var recipe = svc.GetRecipeById(r.Id);

            // assert
            Assert.NotNull(recipe);
            Assert.NotNull(recipe.User);
            Assert.Equal(u.Name, recipe.User.Name); 
        }

        [Fact] // --- GetRecipe should include User and review
        public void Recipe_GetRecipe_WhenExists_ShouldReturnRecipeReviewsAndUser()
        {
            // arrange
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            var r = svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "", "Simmer", 20, 20, "italian", Region.Africa, "Spaghetti alla Carbonara", 460, 2, 1.90, "");
           
            var re1 = new Review { RecipeId = r.Id, Name = "A", Comment = "Good", Rating = 7 };
            svc.AddReview(re1);

            // act
            var recipe = svc.GetRecipeById(r.Id);

            // assert
            Assert.NotNull(recipe);
            Assert.NotNull(recipe.User);
            Assert.NotNull(re1);
            Assert.Equal(u.Name, recipe.User.Name); 
        }


        [Fact] 
        public void Recipe_DeleteRecipe_WhenExists_ShouldReturnTrue()
        {
            // arrange
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            var r = svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "", "Simmer", 20, 20, "italian", Region.Europe, "Spaghetti alla Carbonara", 460, 2, 1.90, "");

            // act
            var deleted = svc.DeleteRecipe(r.Id);     // delete recipe    
            
            // assert
            Assert.True(deleted);                    // recipe should be deleted
        }   

        [Fact] 
        public void Recipe_DeleteRecipe_WhenNonExistant_ShouldReturnFalse()
        {
            // arrange
           
            // act
            var deleted = svc.DeleteRecipe(1);     // delete non-existent recipe  
            
            // assert
            Assert.False(deleted);                  // recipe should not be deleted
        }  

        
        [Fact]
        public void DeleteRecipe_DeleteRecipeThatDoesExist_ShouldReduceRecipeCountBy1()
        {
            //arrange - create 2 recipes for a user
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            var recipe1 = svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "x", "Simmer", 20, 20, "italian", Region.Africa, "Spaghetti alla Carbonara", 460, 2, 1.90, "");
            var recipe2 = svc.CreateRecipe(u.Id, "Spaghetti Bolognese", Diet.Omnivorous, MealType.Dinner, "x", "Sweat off onions", 25, 90, "italian", Region.Europe, "spaghetti alla bolognese", 576, 4, 2.10, "");

            //act 
            var deletedRecipe = svc.DeleteRecipe(recipe1.Id);   //delete recipe
            var recipes = svc.GetAllRecipes();    //retrieve list of recipes

            //assert
            Assert.Equal(1, recipes.Count);  //after deleting one recipe make sure the recipe count is now 1

        }

        [Fact]
        public void DeleteRecipe_DeleteRecipeThatDoesNotExist_ShouldNotReduceRecipeCount()
        {
            //arrange - add recipes
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            var recipe1 = svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "x", "Simmer", 20, 20, "italian", Region.Africa, "Spaghetti alla Carbonara", 460, 2, 1.90, "");
            var recipe2 = svc.CreateRecipe(u.Id, "Spaghetti Bolognese", Diet.Omnivorous, MealType.Dinner, "x", "Sweat off onions", 25, 90, "italian", Region.Europe, "spaghetti alla bolognese", 576, 4, 2.10, "");
            
            //act
            svc.DeleteRecipe(3);     //delete recipe
            var recipes = svc.GetAllRecipes();    //retrieve all recipes

            //assert
            Assert.Equal(2, recipes.Count);  //assert that recipe count is still 2
        }



         // ---------------------- Review  Tests ------------------------

        [Fact]
        public void AddReview_AddingReviewForExistingRecipe_ShouldAddCorrectly()
        {
            //arrange 
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            var r = svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "", "Simmer", 20, 20, "italian", Region.Europe, "Spaghetti alla Carbonara", 460, 2, 1.90, "");
            
            var re1 = new Review { RecipeId = r.Id, Name = "A", Comment = "Good", Rating = 7 };
            svc.AddReview(re1);

            //assert - assert that the new recipe now has a review
            Assert.NotNull(r.Reviews);

        }

        [Fact]
        public void AddReview_AddReviewToExisitingRecipe_ReviewPropertiesShouldAddCorrectly()
        {

            //arrage - create a recipe and review
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            var r = svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "", "Simmer", 20, 20, "italian", Region.Europe, "Spaghetti alla Carbonara", 460, 2, 1.90, "");
            
            var re1 = new Review { RecipeId = u.Id, Name = "A", Comment = "Good", Rating = 7 };
            svc.AddReview(re1);

            //assert
            Assert.NotNull(u);   //assert the recipe exists
            Assert.Equal("A", re1.Name);   //assert the review properties have been assigned correctly
            Assert.Equal("Good", re1.Comment);
            Assert.Equal(7, re1.Rating);
         }

        
        [Fact]
        public void AddReview_Add2ReviewsToARecipe_RecipeReviewCountShouldReturn2()
        {
            //arrange - create a user and a recipe
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            var r = svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "", "Simmer", 20, 20, "italian", Region.Europe, "Spaghetti alla Carbonara", 460, 2, 1.90, "");

            //create 2 reviews
            var re1 = new Review { RecipeId = r.Id, Name = "A", Comment = "Good", Rating = 7 };
            svc.AddReview(re1);
            var re2 = new Review { RecipeId = r.Id, Name = "B", Comment = "Bad", Rating = 3 };
            svc.AddReview(re2);

            //act - rev
            var recipe = svc.GetRecipeById(r.Id);

            //assert
            Assert.NotNull(recipe);  //assert recipe is not null
            Assert.Equal(recipe.Reviews.Count, 2);   //assert the recipe has 2 revies
            Assert.NotEqual(recipe.Reviews.Count, 3);    //assert the recipe does not have 3 reviews
        }

        [Fact]
        public void AddReview_AddAReviewsToANewRecipe_RecipeReviewCountShouldBe0()
        {
            //arrange - create user/recipe
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            var r = svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "", "Simmer", 20, 20, "italian", Region.Europe, "Spaghetti alla Carbonara", 460, 2, 1.90, "");
            

            //act - retieve recipe
            var recipe = svc.GetRecipeById(r.Id);

            //assert
            Assert.NotNull(recipe);  //assert the recipe is not null
            Assert.Equal(recipe.Reviews.Count, 0); //assert the new recipe has 0 reviews
            Assert.NotEqual(recipe.Reviews.Count, 1);  //assert the new recipe does not have 1 review 
        }

        [Fact]
        public void DeleteReview_DeleteReviewFromARecipe_ReviewShouldReturnTrue()
        {
            //arrange - create recipe and review
            var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, "xxx", "xxx", "");
            var r = svc.CreateRecipe(u.Id, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "", "Simmer", 20, 20, "italian", Region.Europe, "Spaghetti alla Carbonara", 460, 2, 1.90, "");

            var re = new Review { RecipeId = r.Id, Name = "A", Comment = "Good", Rating = 7 };
            svc.AddReview(re);   //add review to recipe

            //act - Delete the recipe
            var deleted = svc.DeleteReview(r.Id);

            //assert that review has been deleted delete the review
            Assert.True(deleted);
        }

    }
}
    
//     }
// }