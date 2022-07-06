using System;
using System.Text;
using System.Collections.Generic;
using SMS.Data.Models;

namespace SMS.Data.Services
{
    public static class FoodServiceSeeder
    {
        // seeding the database with dummy test data using an IFoodService 
        public static void Seed(IFoodService svc)
        {
            // wipe and recreate the database
            svc.Initialise();

            // register members 
            var u1 = svc.Register("Pasta", "pasta@mail.com", "pasta123", Role.member, DateTime.Now, "" );
            var u2 = svc.Register("Pizza", "pizza@mail.com", "pizza123", Role.member, DateTime.Now,"");
            var u3 = svc.Register("Curry", "curry@mail.com", "curry123", Role.member, DateTime.Now, "" );
            var u4 = svc.Register("Bread", "bread@mail.com", "bread123", Role.member, DateTime.Now, "" );
            var u5 = svc.Register("Saute", "saute@mail.com", "saute123", Role.member, DateTime.Now, "" );
            var u6 = svc.Register("Stock", "stock@mail.com", "stock123", Role.member, DateTime.Now, "" );
            var u7 = svc.Register("balsamic", "balsamic@mail.com", "balsamic123", Role.member, DateTime.Now,"");
            var u8 = svc.Register("Taco", "taco@mail.com", "taco123", Role.member, DateTime.Now, "" );
            var u9 = svc.Register("Breadstick", "breadstick@mail.com", "breadstick123", Role.member, DateTime.Now, "" );
            var u10 = svc.Register("Hummus", "hummus@mail.com", "hummus123", Role.member, DateTime.Now, "" );
            var u11 = svc.Register("Pepperoni", "pepperoni@mail.com", "pepperoni123", Role.member, DateTime.Now, "" );
            var u12 = svc.Register("Burger", "burger@mail.com", "burger123", Role.member, DateTime.Now,"");
            var u13 = svc.Register("Hotdog", "hotdog@mail.com", "hotdog123", Role.member, DateTime.Now, "" );
            var u14 = svc.Register("Spaghetti", "spaghetti@mail.com", "spaghetti123", Role.member, DateTime.Now, "" );
            var u15 = svc.Register("Seabass", "seabass@mail.com", "seabass123", Role.member, DateTime.Now, "" );
            var u16 = svc.Register("Chicken", "chicken@mail.com", "chicken123", Role.member, DateTime.Now, "" );
            var u17 = svc.Register("Beef", "beef@mail.com", "beef123", Role.member, DateTime.Now,"");
            var u18 = svc.Register("Fish", "fish@mail.com", "fish123", Role.member, DateTime.Now, "" );
            var u19 = svc.Register("Pepper", "pepper@mail.com", "pepper123", Role.member, DateTime.Now, "" );
            var u20 = svc.Register("Onion", "onion@mail.com", "onion123", Role.member, DateTime.Now, "" );
           
            //Register an administrator 
            var u21 = svc.Register("Admin", "admin@mail.com", "admin", Role.admin, DateTime.Now, "");
            
            
            // add recipes for pasta
            var p1 = svc.CreateRecipe(u1.UserId, "Cajun Chicken Pizza", Diet.Omnivorous, MealType.Dinner, "Marninate Chicken breast fillets in Cajun Spices over night, fry on a low heat in olive oil until cooked. remove chicken from pan and set aside", 20, 18, "italian", "italy", "Pollo Pizza", 470, 2, "");
            // var p2 = svc.CreateRecipe(s1.Id, "Printing doesnt work");
            // var p3 = svc.CreateRecipe(s1.Id, "Forgot my password");

            // // add recipes for pizza
            // var t4 = svc.CreateTicket(s2.Id, "Please reset password");
            // var t5 = svc.


            // // add recipes for curry
            // var t5 = svc.CreateTicket(s3.Id, "No internet connection");
            // var t6 = svc.CreateTicket(s3.Id, "Internet not working.");
        
  

        }
    }
}
