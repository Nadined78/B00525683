
// using Xunit;
// using SMS.Data.Models;
// using SMS.Data.Services;

// namespace SMS.Test
// {

//     public class ServiceTests
//     {
//         private readonly IFoodService svc;

//         public ServiceTests()
//         {
//             // general arrangement
//             svc = new FoodServiceDb();

//             // ensure data source is empty before each test
//             svc.Initialise();
//         }

//         // ========================== User Tests =========================
//         [Fact] 
//         public void User_AddUser_WhenDuplicateEmail_ShouldReturnNull()
//         {
//             // act 
//             var u1 = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, new System.DateTime(2022,03,03), "");
//             // this is a duplicate as the email address is same as previous user
//             var u2 = svc.AddUser("XXX", "xxx@email.com", "saoirse123", Role.member, new System.DateTime(2022,05,03), "");
            
//             // assert
//             Assert.NotNull(u1); // this user should have been added correctly
//             Assert.Null(u2); // this user should NOT have been added        
//         }

//         [Fact]
//         public void User_AddUser_WhenNone_ShouldSetAllProperties()
//         {
//             // act 
//             var added = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, new System.DateTime(2022,03,03), "");
            
//             // retrieve user just added by using the Id returned by EF
//             var u = svc.GetUser(added.UserId);

//             // assert - that user is not null
//             Assert.NotNull(u);
            
//             // now assert that the properties were set properly
//             Assert.Equal(u.UserId, u.UserId);
//             Assert.Equal("XXX", u.Name);
//             Assert.Equal("xxx@email.com", u.Email);
//             Assert.Equal("angelo123", u.Password);
//             Assert.Equal(Role.member, u.Role);
//             Assert.Equal(new System.DateTime(2022,03,03), u.CreatedOn);
//         }

//         [Fact]
//         public void USer_UpdateUser_ThatExists_ShouldSetAllProperties()
//         {
//             // arrange - create test user
//             var s = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, new System.DateTime(2022,03,03), "");
                        
//             // act - create a copy and update any user properties (except Id) 
//             var u = new User {
//                 UserId = s.UserId,
//                 Name = "ZZZ",
//                 Email = "zzz@email.com",
//                 Password = "michael123",
//                 Role = Role.manager,
//                 CreatedOn = new System.DateTime(2022,03,04),
//                 PhotoUrl = "http://photo.com"
//             };
//             // save updated user
//             svc.UpdateUser(u); 

//             // reload updated user from database into us
//             var us = svc.GetUser(s.UserId);

//             // assert
//             Assert.NotNull(u);           

//             // now assert that the properties were set properly           
//             Assert.Equal(u.Name, us.Name);
//             Assert.Equal(u.Email, us.Email);
//             Assert.Equal(u.Password, us.Password);
//             Assert.Equal(u.Role, us.Role);
//             Assert.Equal(u.CreatedOn, us.CreatedOn);
//             Assert.Equal(u.PhotoUrl, us.PhotoUrl);
            
//         }

//         [Fact] 
//         public void User_GetAllUser_WhenNone_ShouldReturn0()
//         {
//             // act 
//             var users= svc.GetUsers();
//             var count = users.Count;

//             // assert
//             Assert.Equal(0, count);
//         }


//         [Fact]
//         public void User_GetUsers_When2Exist_ShouldReturn2()
//         {
//             // arrange
//             var u1 = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, new System.DateTime(20,03,03), "");
//             var u2 = svc.AddUser("YYY", "yyy@email.com", "michael123", Role.member, new System.DateTime(23,03,03), "");

//             // act
//             var users = svc.GetUsers();
//             var count = users.Count;

//             // assert
//             Assert.Equal(2, count);
//         }


//         [Fact] 
//         public void User_GetUSer_WhenNonExistent_ShouldReturnNull()
//         {
//             // act 
//             var user = svc.GetUser(1); // non existent user

//             // assert
//             Assert.Null(user);
//         }

//         [Fact] 
//         public void USer_GetUSer_ThatExists_ShouldReturnUser()
//         {
//             // act 
//             var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, new System.DateTime(20,03,03), "");

//             var nu = svc.GetUser(u.UserId);

//             // assert
//             Assert.NotNull(nu);
//             Assert.Equal(u.UserId, nu.UserId);
//         }

//         [Fact] 
//         public void User_GetUser_ThatExistsWithRecipes_ShouldReturnUserWithRecipes()
//         {
//             // arrange 
//             var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, new System.DateTime(20,03,03), "");
//             svc.CreateRecipe(u.UserId, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "Simmer", 20, 20, "italian", "italy", "Spaghetti alla Carbonara", 460, 2, "");
//             svc.CreateRecipe(u.UserId, "Spaghetti Bolognese", Diet.Omnivorous, MealType.Dinner, "Sweat off onions", 25, 90, "italian", "italy", "spaghetti alla bolognese", 576, 4, "");
            
//             // act
//             var user = svc.GetUser(u.UserId);

//             // assert
//             Assert.NotNull(u);    
//             Assert.Equal(2, user.Recipes.Count);
//         }

//         [Fact]
//         public void User_DeleteUser_ThatExists_ShouldReturnTrue()
//         {
//             // act 
//             var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, new System.DateTime(20,03,03), "");
//             var deleted = svc.DeleteUser(u.UserId);

//             // try to retrieve deleted user
//             var u1 = svc.GetUser(u.UserId);

//             // assert
//             Assert.True(deleted); // delete user should return true
//             Assert.Null(u1);      // u1 should be null
//         }

//         [Fact]
//         public void User_DeleteUser_ThatDoesntExist_ShouldReturnFalse()
//         {
//             // act 	
//             var deleted = svc.DeleteUser(0);

//             // assert
//             Assert.False(deleted);
//         }        

//         [Fact]
//         public void User_UpdateUser_ThatExistsWithNewRole_ShouldWork()
//         {
//             // arrange
//             var added = svc.AddUser("Nadine", "nadine@gmail.com", "password", Role.member, new System.DateTime(2022,03,03), "");

//             // act
//             // create a copy of added user and update their role from member to admin
//             var u = new User {
//                 UserId = added.UserId,
//                 Name = added.Name,
//                 Email = added.Email,
//                 Password = added.Password,
//                 Role = Role.admin,
//                 CreatedOn = added.CreatedOn,
//                 PhotoUrl = added.PhotoUrl              
//             };
//             // update this user
//             svc.UpdateUser(u);

//             // now load the user and verify age was updated
//             var nu = svc.GetUser(u.UserId);

//             // assert
//             Assert.Equal(u.Role, nu.Role);
//         }


//          [Fact] // --- Register Valid User test
//         public void User_Register_WhenValid_ShouldReturnUser()
//         {
//             // arrange 
//             var reg = svc.Register("XXX", "xxx@email.com", "password", Role.member, new System.DateTime(2022,03,03));
            
//             // act
//             var user = svc.GetUserByEmailAddress(reg.Email);
            
//             // assert
//             Assert.NotNull(reg);
//             Assert.NotNull(user);
//         } 

//         [Fact] // --- Register Duplicate Test
//         public void User_Register_WhenDuplicateEmail_ShouldReturnNull()
//         {
//             // arrange 
//             var u1 = svc.Register("XXX", "xxx@email.com", "password", Role.member, new System.DateTime(2022,03,03));
            
//             // act
//             var u2 = svc.Register("YYY", "xxx@email.com", "admin", Role.member, new System.DateTime(2022,03,03));

//             // assert
//             Assert.NotNull(u1);
//             Assert.Null(u2);
//         } 

//         [Fact] // --- Authenticate Invalid Test
//         public void User_Authenticate_WhenInValidCredentials_ShouldReturnNull()
//         {
//             // arrange 
//             var u1 = svc.Register("XXX", "xxx@email.com", "password", Role.member, new System.DateTime(2022,03,03));
        
//             // act
//             var user = svc.Authenticate("xxx@email.com", "guest");

//             // assert
//             Assert.Null(user);

//         } 

//         [Fact] // --- Authenticate Valid Test
//         public void User_Authenticate_WhenValidCredentials_ShouldReturnUser()
//         {
//             // arrange 
//             var u1 = svc.Register("XXX", "xxx@email.com", "password", Role.member, new System.DateTime(2022,03,03));
        
//             // act
//             var user = svc.Authenticate("xxx@email.com", "admin");
            
//             // assert
//             Assert.NotNull(user);
//         } 


//         // ---------------------- Recipes Tests ------------------------
        
//         [Fact] 
//         public void Recipe_CreateRecipe_ForExistingUser_ShouldBeCreated()
//         {
//             // arrange
//             var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, new System.DateTime(20,03,03), "");
         
//             // act
//             var r = svc.CreateRecipe(u.UserId, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "Simmer", 20, 20, "italian", "italy", "Spaghetti alla Carbonara", 460, 2, "");
           
//             // assert
//             Assert.NotNull(r);
//             Assert.Equal(u.UserId, r.UserId);
//         }

//          [Fact] // --- GetRecipe should include User
//         public void Recipe_GetRecipe_WhenExists_ShouldReturnRecipeAndUser()
//         {
//             // arrange
//             var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, new System.DateTime(20,03,03), "");
//             var r = svc.CreateRecipe(u.UserId, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "Simmer", 20, 20, "italian", "italy", "Spaghetti alla Carbonara", 460, 2, "");

//             // act
//             var recipe = svc.GetRecipe(r.RecipeId);

//             // assert
//             Assert.NotNull(recipe);
//             Assert.NotNull(recipe.User);
//             Assert.Equal(u.Name, recipe.User.Name); 
//         }

//         // [Fact] // --- GetOpenTickets When two added should return two 
//         // public void Ticket_GetOpenTickets_WhenTwoAdded_ShouldReturnTwo()
//         // {
//         //     // arrange
//         //     var s = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "http://photo.com");
//         //     var t1 = svc.CreateTicket(s.Id, "Dummy Ticket 1");
//         //     var t2 = svc.CreateTicket(s.Id, "Dummy Ticket 2");

//         //     // act
//         //     var open = svc.GetOpenTickets();

//         //     // assert
//         //     Assert.Equal(2,open.Count);                        
//         // }


//         [Fact] 
//         public void Recipe_DeleteRecipe_WhenExists_ShouldReturnTrue()
//         {
//             // arrange
//             var u = svc.AddUser("XXX", "xxx@email.com", "angelo123", Role.member, new System.DateTime(20,03,03), "");
//             var r = svc.CreateRecipe(u.UserId, "creamy carbonara", Diet.Omnivorous, MealType.Dinner, "Simmer", 20, 20, "italian", "italy", "Spaghetti alla Carbonara", 460, 2, "");

//             // act
//             var deleted = svc.DeleteRecipe(r.RecipeId);     // delete recipe    
            
//             // assert
//             Assert.True(deleted);                    // recipe should be deleted
//         }   

//         [Fact] 
//         public void Recipe_DeleteRecipe_WhenNonExistant_ShouldReturnFalse()
//         {
//             // arrange
           
//             // act
//             var deleted = svc.DeleteRecipe(1);     // delete non-existent recipe  
            
//             // assert
//             Assert.False(deleted);                  // recipe should not be deleted
//         }  


//         // // ======================= Module Tests =======================
        
//         // [Fact] 
//         // public void Module_AddStudentToModule_WhenValid_ShouldReturnStudentModule()
//         // {
//         //     // arrange
//         //     var s = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "http://photo.com");
//         //     var m = svc.AddModule("YYY");

//         //     // act
//         //     var sm = svc.AddStudentToModule(s.Id, m.Id, 0);
        
//         //     // assert
//         //     Assert.NotNull(sm);
//         //     Assert.Equal(s.Id, sm.StudentId);
//         //     Assert.Equal(m.Id, sm.ModuleId);                      
//         // }

//         //  [Fact] 
//         // public void Student_GetStudent_WhenContainsTicketsAndModules_ShouldReturnAll()
//         // {
//         //     // arrange
//         //     var s = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "http://photo.com");
//         //     var m = svc.AddModule("YYY");

//         //     var sm = svc.AddStudentToModule(s.Id, m.Id, 0);
//         //     var t = svc.CreateTicket(s.Id, "XXX");
        
//         //     // act

//         //     var r = svc.GetStudent(s.Id);

//         //     // assert
//         //     Assert.NotNull(r);
//         //     Assert.Equal(1, r.Tickets.Count);
//         //     Assert.Equal(1, r.StudentModules.Count);                      
//         // }

//         // [Fact] 
//         // public void AddStudentToModule_WhenAlreadyTakingModule_ShouldReturNull()
//         // {
//         //     // arrange
//         //     var s = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "http://photo.com");
//         //     var m = svc.AddModule("YYY");

//         //     // act
//         //     var sm1 = svc.AddStudentToModule(s.Id, m.Id, 0);
//         //     var sm2 = svc.AddStudentToModule(s.Id, m.Id, 0); // duplicate

//         //     // assert
//         //     Assert.Null(sm2);           
//         // }         
       
    
//     }
// }