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
            var u1 = svc.Register("Pasta", "pasta@mail.com", "pasta123", Role.member, DateTime.Now, "https://tse3.mm.bing.net/th?id=OIP.HIBwLtEXMnop_y4pGUVbQwHaLH&pid=Api&P=0&w=109&h=163" );
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
            var r1 = svc.CreateRecipe(u1.UserId, "Cajun Chicken Pasta", Diet.Omnivorous, MealType.Dinner, "chicken, onion, peppers, cajun spice, pasta, double cream, chorizo", "Marninate Chicken breast fillets in Cajun Spices over night, fry on a low heat in olive oil until cooked. remove chicken from pan and set aside", 20, 18, "italian", "italy", "Cajun Pollo Pasta", 470, 2, "https://tse1.mm.bing.net/th?id=OIP.iw_7gH8lF80C5RcIhVWlLQHaLH&pid=Api&P=0&w=102&h=153");
            var r2 = svc.CreateRecipe(u1.UserId, "Spaghetti Bolognese", Diet.Omnivorous, MealType.Dinner, "Lean mince beef, tomato puree, passata, onion, bacon, red wine", "fry off onion for 5 minutes, season mince and fry until browned, add tablespoon puree, carton of passata, cup of red wine, boil pasta", 15, 60, "italian", "Italy", "Spaghetti Alla Bolognese", 500, 4, "https://tse2.mm.bing.net/th?id=OIP.lzO82PYyrudX9qcEnqS28wHaKN&pid=Api&P=0&w=117&h=161" );
            var r3 = svc.CreateRecipe(u1.UserId, "Chicken and Bacon Carbonara", Diet.Omnivorous, MealType.Dinner, "pasta, onion, chicken, parmasean, egg yolk, bacon", "cook pasta, fry onion, add bacon until browned, add egg yolk and parmesan to bowl and mix to a thick consistency, lower heat to lowest setting, add mix to pan with half a cup of pasta water and bring together", 20, 45, "italian", "italy", "pancetta di pollo carbonara", 375, 2, "https://tse1.mm.bing.net/th?id=OIP.REMYdE2c1UbI5QUQXS3FqQHaJQ&pid=Api&P=0&w=136&h=170" );

            // // add recipes for pizza
            var t4 = svc.CreateRecipe(u2.UserId, "Chicken and pepperoni pizza", Diet.Omnivorous, MealType.Dinner, "Chicken, pepperoni, pizza dough, tomato based sauce, mozzarella, cheddar cheese", "Method", 30, 45, "Italian", "Italy", "Pizza peperoni di pollo", 450, 4, "https://tse4.mm.bing.net/th?id=OIP.1YJoRwA972tJg76PfTJ22wHaLH&pid=Api&P=0&w=110&h=165" );
            // var t5 = svc.


            // // add recipes for curry
            // var t5 = svc.CreateTicket(s3.Id, "No internet connection");
            // var t6 = svc.CreateTicket(s3.Id, "Internet not working.");
        
  

        }
    }
}
