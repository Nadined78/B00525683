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

            // register pasta
            var u1 = svc.AddUser("Pasta", "pasta@mail.com", "pasta123", Role.member, "Italian", "All things Italian, food, recipes, and what I love. Love to share stories, tips, offering you, easy and simple recipes. I am a mother of two extraordinary boys, Joey Rocco and Vito Anthony. I am a doctor and healthcare consultant by week and food lover, home chef of Italian dishes, desserts, stories, and traditions on the weekend", "https://tse3.mm.bing.net/th?id=OIP.HIBwLtEXMnop_y4pGUVbQwHaLH&pid=Api&P=0&w=109&h=163" );
           
            // add recipes for pasta
            var r1 = svc.CreateRecipe(u1.Id, "Cajun Chicken Pasta", Diet.Omnivorous, MealType.Dinner, "chicken, onion, peppers, cajun spice, pasta, double cream", "Marninate Chicken breast fillets in Cajun Spices over night, fry on a low heat in olive oil until cooked. remove chicken from pan and set aside, fry off onions and peppers, add cream and let it simmer for 10 minutes. Re-add the chicken and serve", 20, 18, "Italian", Region.Europe, "Pasta Di Pollo Cajun", 470, 2, 2.50, "https://tse1.mm.bing.net/th?id=OIP.iw_7gH8lF80C5RcIhVWlLQHaLH&pid=Api&P=0&w=102&h=153");
            var r2 = svc.CreateRecipe(u1.Id, "Spaghetti Bolognese", Diet.Omnivorous, MealType.Dinner, "Lean mince beef, tomato puree, passata, onion, bacon, red wine", "fry off onion for 5 minutes, season mince and fry until browned, add tablespoon puree, carton of passata, cup of red wine, boil pasta. Simmer sauce for 10 minutes to allow flavours to mix, once pasta is boiled, add sauce mix on top, top with parmesan and serve", 15, 60, "Italian", Region.Europe, "Spaghetti Alla Bolognese", 500, 4, 2.00, "https://tse2.mm.bing.net/th?id=OIP.lzO82PYyrudX9qcEnqS28wHaKN&pid=Api&P=0&w=117&h=161" );
            var r3 = svc.CreateRecipe(u1.Id, "Chicken and Bacon Carbonara", Diet.Omnivorous, MealType.Dinner, "pasta, onion, chicken, parmasean, egg yolk, bacon", "cook pasta, fry onion, add bacon until browned, add egg yolk and parmesan to bowl and mix to a thick consistency, lower heat to lowest setting, add mix to pan with half a cup of pasta water and bring together", 20, 45, "Italian", Region.Europe, "Carbonara Di Pollo E Pancetta", 375, 2, 3.00, "https://tse1.mm.bing.net/th?id=OIP.REMYdE2c1UbI5QUQXS3FqQHaJQ&pid=Api&P=0&w=136&h=170" );
            
            // add reviews for pasta's recipes 
            var e1 = new Review { RecipeId = 1, Name = "Michael", ReviewedOn = new DateTime(08/07/2022), Comment = "Delicious Recipe, a must-try!!!", Rating = 10 };
            svc.AddReview(e1);
            
            var e2 = new Review { RecipeId = 1, Name = "Cillian", ReviewedOn = new DateTime(17/10/22), Comment = "The chicken was beautiful. Thank You", Rating = 9 };
            svc.AddReview(e2);

            var e3 = new Review { RecipeId= 1, Name = "Conor", ReviewedOn = new DateTime(24/02/21), Comment = "I added some chorizo and it was great!", Rating = 9 };
            svc.AddReview(e3);

            var e4 = new Review { RecipeId= 2, Name = "Carolina", ReviewedOn = new DateTime(20/12/2021), Comment = "Tasty!" , Rating = 8};
            svc.AddReview(e4);

            var e5 = new Review { RecipeId= 2, Name = "Monica", ReviewedOn = new DateTime(25/03/2022), Comment = "Sauce was a little watery. Will try again as flavour was great", Rating = 7};
            svc.AddReview(e5);

            var e6 = new Review { RecipeId= 2, Name = "Roberta", ReviewedOn = new DateTime(30/04/2022), Comment = "Kids loved it!", Rating = 8};
            svc.AddReview(e6);

            var e7 = new Review { RecipeId= 3, Name = "Alana", ReviewedOn = new DateTime(04/09/2021), Comment = "Added some red peppers and it was Delicious", Rating = 9 };
            svc.AddReview(e7);

            var e8 = new Review { RecipeId= 3, Name = "Stephen", ReviewedOn = new DateTime(01/01/2021), Comment = "Nice Recipe!!!", Rating = 6 };
            svc.AddReview(e8);

            var e9 = new Review { RecipeId= 3, Name = "Isabella Lazio", ReviewedOn = new DateTime(05/07/2021), Comment = "Added Cherry Tomatoes, be sure to save enough pasta water. Will make again", Rating = 8};
            svc.AddReview(e9);

            // register pizza member
            var u2 = svc.AddUser("Pizza", "pizza@mail.com", "pizza123", Role.member, "Italian", "My Greek stepmother loves to cook and taught me mostly everything I know. Her passion for food was passed onto me, although I'm not an expert, I seem to get many compliments on my meals. When I come home from work, my winding down time is to cook.", "https://tse3.mm.bing.net/th?id=OIP.Gi-aQfdYcOTWE_x7zGz7YQHaI2&pid=Api&P=0");

            // // add recipes for pizza
            var t4 = svc.CreateRecipe(u2.Id, "Chicken and Pepperoni Pizza", Diet.Omnivorous, MealType.Dinner, "Chicken, pepperoni, pizza dough, tomato based sauce, mozzarella, cheddar cheese", "Method", 30, 45, "Italian", Region.Europe, "Pizza Pollo E Peperoni", 450, 2, 3.25, "https://tse4.mm.bing.net/th?id=OIP.1YJoRwA972tJg76PfTJ22wHaLH&pid=Api&P=0&w=110&h=165" );
            var t5 = svc.CreateRecipe(u2.Id, "Mushroom Pizza", Diet.Vegetarian, MealType.Dinner, "Mushroom, pizza dough, tomato based sauce, mozzarella, cheddar cheese", "Method", 15, 15, "Italian", Region.Europe, "Pizza ai Funghi", 350, 2, 2.20, "https://tse2.mm.bing.net/th?id=OIP.bEMl9MFoe6hpZcNkwfDoQwHaLH&pid=Api&P=0&w=105&h=157" );
            var t6 = svc.CreateRecipe(u2.Id, "Margherita Pizza", Diet.Vegetarian, MealType.Dinner, "Basil, Mozzarella, tomatoes, pizza dough, tomato based sauce", "Method", 20, 20, "Italian", Region.Europe, "Margherita Pizza", 300, 2, 2.25, "https://tse4.mm.bing.net/th?id=OIP.VcalYhLe9cc0_fhlNFxE5QHaJQ&pid=Api&P=0&w=151&h=188" ); 
            
           
            // add reviews for pizza's recipes 
            var e10 = new Review { RecipeId = 4, Name = "Sarah", ReviewedOn = new DateTime(08/07/2022), Comment = "Very flavorful", Rating = 9 };
            svc.AddReview(e10);
            
            var e11 = new Review { RecipeId = 4, Name = "Bacarat", ReviewedOn = new DateTime(17/10/22), Comment = "Thank You, Very Tasty", Rating = 9 };
            svc.AddReview(e10);

            var e12 = new Review { RecipeId= 4, Name = "Shokod", ReviewedOn = new DateTime(24/02/21), Comment = "So delicious. I sauteed a sweet onion and garlic cloves in olive oil and added on top", Rating = 9 };
            svc.AddReview(e12);

            var e13 = new Review { RecipeId= 5, Name = "PLZNRC", ReviewedOn = new DateTime(20/12/2021), Comment = "Tasty!" , Rating = 8};
            svc.AddReview(e13);

            var e14 = new Review { RecipeId= 5, Name = "Lizanne", ReviewedOn = new DateTime(25/03/2022), Comment = "Found the flavours a little bland. Maybe some more ingredients needed. I will add more next time. Would try again. ", Rating = 6};
            svc.AddReview(e14);

            var e15 = new Review { RecipeId= 5, Name = "Erin", ReviewedOn = new DateTime(30/04/2022), Comment = "My husband is a vegetarian and he loved this! We added some tomatoes. Thank you!", Rating = 8};
            svc.AddReview(e15);

            var e16 = new Review { RecipeId= 6, Name = "Gitano", ReviewedOn = new DateTime(04/09/2021), Comment = "Added some peppers and it was Delicious", Rating = 9 };
            svc.AddReview(e16);

            var e17 = new Review { RecipeId= 6, Name = "Izzy", ReviewedOn = new DateTime(01/01/2021), Comment = "Easy to make, but it definitely needs a lot more flavours/ingredients!!!", Rating = 6 };
            svc.AddReview(e17);

            var e18 = new Review { RecipeId= 6, Name = "Cruz", ReviewedOn = new DateTime(03/09/2021), Comment = "This is great, the only thing I did differently was add the fresh basil to the tomato mixture just before serving.", Rating = 7};
            svc.AddReview(e18);
            

            // Register curry member
            var u3 = svc.AddUser("Curry", "curry@mail.com", "curry123", Role.member, "Indian", "Hi, I am a recipe blogger who likes to eat and experiment in cooking. Please email me and we can talk all things food" , "https://tse3.mm.bing.net/th?id=OIP.ogIx0NqKwIigj7lxwz83wwHaLG&pid=Api&P=0" );

            // // add recipes for curry 
            var t7 = svc.CreateRecipe(u3.Id, "Chicken Madras", Diet.Omnivorous, MealType.Dinner, "1 onion, peeled and quartered, 2 garlic cloves, thumb-sized chunk of ginger, peeled red chilli, 1 tbsp vegetable oil, 1 tsp turmeric, 1 tsp ground cumin, 1 tsp ground coriander, 1-2 tsp hot chilli powder (depending on how spicy you like your curry), 4 chicken breasts, cut into chunks,400g can chopped tomatoes, small pack coriander, chopped rice, naan and mango chutney, to serve", "Blitz 1 quartered onion, 2 garlic cloves, a thumb-sized chunk of ginger and ½ red chilli together in a food processor until it becomes a coarse paste. Heat 1 tbsp vegetable oil in a large saucepan and add the paste, fry for 5 mins, until softened. If it starts to stick to the pan at all, add a splash of water, Tip in ½ tsp turmeric, 1 tsp ground cumin, 1 tsp ground coriander and 1-2 tsp hot chilli powder and stir well, cook for a couple of mins to toast them a bit, then add 4 chicken breasts, cut into chunks. Stir and make sure everything is covered in the spice mix. Cook until the chicken begins to turn pale, adding a small splash of water if it sticks to the base of the pan at all. Pour in 400g can chopped tomatoes, along with a big pinch of salt, cover and cook on a low heat for 30 mins, until the chicken is tender. Stir through small pack of coriander and serve with rice, naan and a big dollop of mango chutney.", 30, 35,  "Indian", Region.Asia, "Ciken madrās/Kōḻi meṭrās", 373, 4, 4.25, "https://tse1.mm.bing.net/th?id=OIP.ZPko7gRxk0cgNcrmqDkqxwHaLH&pid=Api&P=0" );
            var t8 = svc.CreateRecipe(u3.Id, "Lamb Jalfrezi", Diet.Omnivorous, MealType.Dinner, "30ml (1 tbsp) ghee, 800g (2lbs) lamb shoulder, cubed, 30ml (2 tbsp) ground turmeric, 500ml (2 cups) curry base sauce, 30ml (2 tbsp) vegetable oil, 2 onions, peeled and chopped, 5 garlic cloves, peeled and crushed, 2.5cm (1in) fresh ginger, peeled and finely diced, 2 red peppers, washed and chopped, 2 green chilli peppers, peeled and finely chopped, 60ml (4 tbsp) fresh coriander stalks, washed and finely chopped, 60ml (4 tbsp) tomato puree, 2 tomatoes, washed and quartered, 10ml (2 tsp) garam masala, 60ml (4 tbsp) fresh coriander leaves, washed and chopped", "Heat the ghee in a large ovenproof casserole. Cover the lamb with turmeric and brown on all sides in the casserole. Pour in the curry base sauce, stir and cover with a lid. Simmer on a low heat until the meat is cooked and tender. In this case, it took about 90 minutes. Heat the oil in a large frying pan. Fry the onions at a high heat for 2 minutes. Add the garlic, ginger, coriander stalks, peppers and chillies. Continue to fry for another 2 minutes. Pour in the stewed lamb and all its sauce to the frying pan. Stir in the tomato puree, tomatoes and garam masala. Let the curry bubble away for 5 minutes. Serve immediately, topped with fresh coriander leaves, with your favourite Indian accompaniments. Enjoy!", 20, 90, "Indian", Region.Asia, "Gorre jalphrējī/Āṭṭukkuṭṭi jālḥprēci", 609, 4, 4.15, "https://tse3.mm.bing.net/th?id=OIP.MXFjogPItv_zacF_h6qgKAAAAA&pid=Api&P=0" );
            var t9 = svc.CreateRecipe(u3.Id, "Vegatable Rogan Josh", Diet.Vegan, MealType.Dinner, "1 pouch Basmati rice, 150g baby new potatoes, diced 150g cauliflower florets, 150g baby carrots, halved, 2 tbsps oil, 1 onion, finely chopped, 1 clove garlic, crushed, 1 thumb ginger, grated, 3 tbsps rogan josh paste, 1/2 tsp toasted black onion seeds, 200g canned chopped tomatoes, 200ml water, 100g chickpeas drained, 1 large tomato cut into quarters, Salt and black pepper to season", "", 30, 60, "Indian", Region.Asia, "Kūragāyala rōgan jōṣ/Kāykaṟi rōkaṉ jōṣ", 470, 2, 3.75, "https://tse4.mm.bing.net/th?id=OIP.ac0lFXRBocYbHUG3af-njwHaKn&pid=Api&P=0" ); 

            var e19 = new Review { RecipeId = 7, Name = "Bill", ReviewedOn= new DateTime(19/01/2020), Comment = "This is a lovely Chicken curry recipe - the balance of spices is wonderful and I imagine it would be gorgeous with naan or any kind of flatbread!", Rating = 10};
            svc.AddReview(e19);

            var e20 = new Review {RecipeId = 7, Name = "Frankie", ReviewedOn= new DateTime(24/02/2021), Comment = "Delicious. Well Done on a tasty recipe", Rating = 9};
            svc.AddReview(e20);

            var e21= new Review {RecipeId = 7, Name = "Rosette", ReviewedOn= new DateTime(09/08/20), Comment = "As good as the restaurant near my home!", Rating = 10};
            svc.AddReview(e21);

            var e22 = new Review {RecipeId = 8, Name = "Buster", ReviewedOn= new DateTime(15/04/2021), Comment = "The lamb is fantastic. A Must try!", Rating = 9};
            svc.AddReview(e22);

            var e23 = new Review {RecipeId = 8, Name = "Ali", ReviewedOn = new DateTime(07/08/21), Comment = "A little Hot for me, but still a delicious recipe. Flavours are great", Rating= 9};
            svc.AddReview(e23);

            var e24 = new Review {RecipeId = 8, Name = "Veron", ReviewedOn = new DateTime(28/10/2021), Comment = "Allergic to Ginger so I removed. Still great!", Rating = 8};
            svc.AddReview(e24);

            var e25 = new Review {RecipeId = 9, Name = "Zayete", ReviewedOn = new DateTime(28/11/2021), Comment = "Great addition of baby potatoes, bulky dish that filled all the family!", Rating = 9};
            svc.AddReview(e25);

            var e26 = new Review {RecipeId = 9, Name = "Melissa", ReviewedOn = new DateTime(16/10/2021), Comment = "Great Recipe. flavours are 10/10!", Rating = 10};
            svc.AddReview(e26);

            var e27 = new Review {RecipeId = 9, Name = "Sedate", ReviewedOn = new DateTime(28/02/2021), Comment = "Added chicken, SUPERB!!", Rating = 10};
            svc.AddReview(e27);


            // Register Soup Member
            var u4 = svc.AddUser("Soup", "Soup@mail.com", "soup123", Role.member,  "French", "Cookin' up ethnic dishes, one spice at a time", "https://tse3.mm.bing.net/th?id=OIP.jFCaOstaToQH90hXktCBGAAAAA&pid=Api&P=0" );

            //add recipes for soup member
            var t10 = svc.CreateRecipe(u4.Id, "French Onion Soup", Diet.Vegetarian, MealType.Lunch, "50g butter, 1 tbsp olive oil, 1kg onions, halved and thinly sliced, 1 tsp sugar, 4 garlic cloves, thinly sliced, 2 tbsp plain flour, 250ml dry white wine, 1.3l hot strongly-flavoured beef stock, 4-8 slices baguette (depending on size), 140g gruyère, finely grated", "Melt the butter with the olive oil in a large heavy-based pan. Add the onions and fry with the lid on for 10 mins until soft. Sprinkle in the sugar and cook for 20 mins more, stirring frequently, until caramelised. The onions should be really golden, full of flavour and soft when pinched between your fingers. Take care towards the end to ensure that they don’t burn. Add the garlic cloves for the final few minutes of the onions’ cooking time, then sprinkle in the plain flour and stir well. Increase the heat and keep stirring as you gradually add the wine, followed by the beef stock. Cover and simmer for 15-20 mins. To serve, turn on the grill, and toast the bread. Ladle the soup into heatproof bowls. Put a slice or two of toast on top of the bowls of soup, and pile on the gruyère. Grill until melted. Alternatively, you can cook the toasts under the grill, then add them to the soup to serve.", 15, 55, "French", Region.Europe, "Soupe à l'oignon", 618, 4, 2.95, "https://tse1.mm.bing.net/th?id=OIP.TKCLor3jzONVXqWzwoj8RwHaHa&pid=Api&P=0");   
            var t11 = svc.CreateRecipe(u4.Id, "French Garlic Soup", Diet.Omnivorous, MealType.Lunch, "1 litre or 2 pints of chicken stock, 8 cloves of garlic, minced, 75g or 3oz of duck fat, 2 eggs, separated, 1 bouquet garni, salt & pepper, 4 slices of stale bread toasted, 75g or 3oz of grated cheese", "Bring the stock to the boil, fry the garlic in the duck fat, then add to the stock, add the bouquet garni and simmer for 20 mins, remove the bouquet garni, beat the egg whites lightly and add to the soup, as soon as they have set remove from the heat, whisk some of the soup with the egg yolks a bit at a time, then pour into the rest of the soup, add salt and pepper to taste, put a slice of the stale, toasted bread in the bottom of the bowl, cover with grated cheese, pour on the soup, cut the egg whites into pieces if you like", 5, 30, "French", Region.Europe, "Soupe a l'ail", 590, 4, 2.25, "https://tse1.mm.bing.net/th?id=OIP.zfyEeS6Rc61zwNNjHsHn_AHaE8&pid=Api&P=0");
            var t12 = svc.CreateRecipe(u4.Id, "French Tomato Soup", Diet.Vegetarian, MealType.Lunch, "1 tablespoon butter, 1 large onion, chopped, 6 tomatoes, peeled and quartered, 1 large potato, peeled and quartered, 6 cups water, 1 bay leaf, 1 clove garlic, pressed, 1 teaspoon salt, ½ cup long-grain rice", "Melt butter in a large saucepan over medium heat. Saute onions in butter until tender and lightly browned, about 10 minutes. Add tomatoes, and continue cooking for 10 more minutes, stirring frequently. Add the potato, and 2 cups of water. Season with the bay leaf, garlic and salt. Bring to a boil, then reduce heat and simmer, covered, for about 20 minutes. Stir in the remaining water, and bring to a boil again. Discard bay leaf, and strain the solids from the broth, reserving both. Puree the vegetables in a food processor or blender, and stir them back into the broth. Bring to a boil, and add the rice. Cover and simmer over low heat for about 15 minutes, or until rice is tender. Serve hot", 20,75, "French", Region.Europe, "Soupe à la tomate française", 390, 6, 2.45, "https://tse3.mm.bing.net/th?id=OIP.5kJBrHHS84Lc5rOWufhfpAHaLH&pid=Api&P=0");
            
            //add reviews for soups's recipes           
            var e28 = new Review {RecipeId = 10, Name = "Paula", ReviewedOn = new DateTime(08/02/2021), Comment = "Soup was very watery, would not rate. Recipe followed excately", Rating = 4};
            svc.AddReview(e28);

            var e29 = new Review {RecipeId = 10, Name = "Rachael", ReviewedOn = new DateTime(19/07/2021), Comment = "A nice recipe but could be improved a lot", Rating = 5};
            svc.AddReview(e29);

            var e30 = new Review {RecipeId = 10, Name = "Brigette", ReviewedOn = new DateTime(11/11/2021), Comment = "A little bland, I made a few little improvements and it turned out ok", Rating = 5};
            svc.AddReview(e30);

            var e31 = new Review {RecipeId = 11, Name = "Annette", ReviewedOn = new DateTime(27/12/2021), Comment = "Soup was Great!! Highly Recommend", Rating = 8};
            svc.AddReview(e31);

            var e32 = new Review {RecipeId = 11, Name = "Audrey", ReviewedOn = new DateTime(15/05/2021), Comment = "Velvety Smooth and full of Flavour", Rating = 10};
            svc.AddReview(e32);

            var e33 = new Review {RecipeId = 11, Name = "Albert", ReviewedOn = new DateTime(18/09/2021), Comment = "Bowl of Comfort. Thank You!", Rating = 9};
            svc.AddReview(e33);

            var e34 = new Review {RecipeId = 12, Name = "Alan", ReviewedOn = new DateTime(13/01/2020), Comment = "Bland Recipe - Added a lot of my own ingredients to avoid dumping", Rating = 3};
            svc.AddReview(e34);

            var e35 = new Review {RecipeId = 12, Name = "Chloe", ReviewedOn = new DateTime(03/05/2021), Comment = "Soup was very watery, would not rate. Recipe followed excately", Rating = 5};
            svc.AddReview(e35);

            var e36 = new Review {RecipeId = 12, Name = "Gabriel", ReviewedOn = new DateTime(11/11/2021), Comment = "Throughly enjoyed. Thank you!", Rating = 8};
            svc.AddReview(e36);

            // Register Thai Member
            var u5 = svc.AddUser("Thai", "thai@mail.com", "thai123", Role.member, "Ethnic Thai" , "If you're afraid of butter, use cream -Julia Child Recipe developer, food stylist, culinary tinkerer and mama of two kitchen monkeys! When I'm not cooking (or cleaning up after cooking), I'm outside running, skiing, gardening and dodging nerf bullets", "https://tse2.mm.bing.net/th?id=OIP.TN83udI5uc5Gvhvc8gSyoAHaLd&pid=Api&P=0" );
            
            //add recipes for Thai
            var t13 = svc.CreateRecipe(u5.Id, "Spicy Garlic and Pepper Shrimp", Diet.Omnivorous, MealType.Dinner, "2.5 tablespoons vegetable oil, quater cup water, 1 cup shredded cabbage, 1 tablespoon minced garlic, 8 large fresh shrimp, peeled and deveined, 2 teaspoons crushed red pepper flakes, 2 tablespoons sliced onion, 1 tablespoon chopped fresh cilantro, 1 tablespoon soy sauce", "Heat 1 tablespoon oil in a skillet over high heat. Add cabbage and 1 tablespoon water stir-fry for 30 seconds. Remove cabbage from skillet and place on a serving platter. Heat the remaining 1 1/2 tablespoons oil in the skillet over high heat. Place the garlic and shrimp in the skillet and stir until garlic is lightly browned and shrimp turns pink. Add pepper, onion, cilantro, soy sauce and remaining water to the skillet. Stir-fry for 10 seconds. Pour the hot mixture onto the cabbage.", 25, 10, "Thai", Region.Asia, "P̄hĕd kratheīym phrikthịy kûng", 460, 1, 3.75,"https://tse2.mm.bing.net/th?id=OIP.GrG7iZLhsHcGoFazsbJpyAHaLH&pid=Api&P=0");
            var t14 = svc.CreateRecipe(u5.Id, "Thai Mango Salad with Peanut Dressing", Diet.Vegetarian, MealType.Lunch, "One head (about 7 ounces) butter leaf lettuce or your greens of choice, chopped into bite-sized pieces, 1 red bell pepper, thinly sliced and then sliced across to make 1″ long pieces, 3 ripe champagne mangos, diced, ½ cup thinly sliced green onion (both green and white parts), ⅓ cup chopped roasted peanuts, ¼ cup chopped fresh cilantro, 1 medium jalapeño, seeds and membranes removed, finely chopped, Peanut dressing, ¼ cup creamy peanut butter, ¼ cup lime juice (about 2 to 3 limes), 1 tablespoon tamari or soy sauce, 1 tablespoon apple cider vinegar, 1 tablespoon honey or maple syrup, 1 teaspoon sesame oil, 2 cloves garlic, pressed or minced, Pinch of red pepper flakes (if you like spice)", "To assemble the salad, simply combine all of the salad ingredients in a large serving bowl. To prepare the dressing, combine all of the ingredients in a liquid measuring cup or bowl, and whisk until combined. When you’re ready to serve, drizzle the dressing over the salad, and toss to combine. Serve immediately", 20, 0, "Thai", Region.Asia, "Yả mam̀wng n̂ả s̄lạd t̄hạ̀w lis̄ng", 377, 4, 3.95, "https://tse1.mm.bing.net/th?id=OIP.uJu-r9jm6XbmIbCDsgk58QHaLH&pid=Api&P=0");
            var t15 = svc.CreateRecipe(u5.Id, "Easy Thai Chicken", Diet.Omnivorous, MealType.Dinner, "2 tablespoons unsalted butter, 8 bone-in, skin-on chicken thighs, 1/4 cup peanuts, chopped, 2 tablespoons chopped fresh cilantro leaves, 1/2 cup sweet chili sauce, 2 tablespoons reduced sodium soy sauce, 2 cloves garlic, minced, 1 tablespoon fish sauce, 1 tablespoon freshly grated ginger, Juice of 1 lime, 1 teaspoon Sriracha, or more, to taste", "Preheat oven to 400 degrees F. To make the sauce, whisk together chili sauce, soy sauce, garlic, fish sauce, ginger, lime juice and Sriracha in a small bowl; set aside. Melt butter in a large oven-proof skillet over medium high heat. Add chicken, skin-side down, and sear both sides until golden brown, about 2-3 minutes per side. Stir in chili sauce mixture. Place into oven and roast until completely cooked through, reaching an internal temperature of 165 degrees F, about 25-30 minutes. Then broil for 2-3 minutes, or until caramelized and slightly charred. Serve immediately, garnished with peanuts and cilantro, if desired", 10, 30, "Thai", Region.Asia, "Kị̀ thịy ng̀āy", 252, 8, 3.79, "https://tse3.mm.bing.net/th?id=OIP.HFSuCjlgpXhyvpm7gKTNowHaLH&pid=Api&P=0");

            //add reviews for Thai's Recipes
            var e37 = new Review {RecipeId = 13, Name = "Achara", ReviewedOn = new DateTime(01/12/2021), Comment = "This is one of my favorite recipes I have found online. Smashing!!", Rating = 10};
            svc.AddReview(e37);

            var e38 = new Review {RecipeId = 13, Name = "Lisa", ReviewedOn = new DateTime(19/01/2021), Comment = "Awesome, My husband and I love this.", Rating = 10};
            svc.AddReview(e38);

            var e39 = new Review {RecipeId = 13, Name = "Monique", ReviewedOn = new DateTime(11/09/2021), Comment = "LOVED this one! It was spicy and delicious!!!", Rating = 10};
            svc.AddReview(e39);

            var e40 = new Review {RecipeId = 14, Name = "Matthew", ReviewedOn = new DateTime(13/05/2022), Comment = "Beautiful salad!! Love the combo of sweet and spicy flavors!!!", Rating = 8};
            svc.AddReview(e40);

            var e41 = new Review {RecipeId = 14, Name = "James", ReviewedOn = new DateTime(17/10/2020), Comment = "Perfect on a hot day. Will continue to make for a long time", Rating = 9};
            svc.AddReview(e41);

            var e42 = new Review {RecipeId = 14, Name = "Linda", ReviewedOn = new DateTime(19/11/2021), Comment = "Enjoyed by the whole family. Thank you!", Rating = 9};
            svc.AddReview(e42);

            var e43= new Review {RecipeId = 15, Name = "Fern", ReviewedOn = new DateTime(02/09/2020), Comment = "Really Good - quick and easy", Rating = 8};
            svc.AddReview(e43);

            var e44= new Review {RecipeId = 15, Name = "Chai", ReviewedOn = new DateTime(11/10/2021), Comment = "Throughly enjoyed. Thank you!", Rating = 8};
            svc.AddReview(e44);

            var e45 = new Review {RecipeId = 15, Name = "Kannika", ReviewedOn = new DateTime(17/11/2021), Comment = "Fabulous! I used skinless thighs and it turned out great!", Rating = 9};
            svc.AddReview(e45);

            // Register Stock Member
            var u6 = svc.AddUser("Stock", "stock@mail.com", "stock123", Role.member,  "Irish", "I've only started to cook in the past 6 months... I was sick of cooking things that came out of a box!!! Lets communicate and discuss our food experiences and travel", "https://tse1.mm.bing.net/th?id=OIP.WYni2MN-426nGod4j9FSzQHaJQ&pid=Api&P=0" );

            //add recipes for Stock
            var t16 = svc.CreateRecipe(u6.Id, "Slow cooker honey mustard chicken", Diet.Omnivorous, MealType.Dinner, "1 tsp sunflower, vegetable or light olive oil, 6–8 chicken thighs, with skin and bone-in,300ml/10fl oz hot chicken stock, made with 1 stock cube, 2 tbsp mustard, English, wholegrain or a combination,2 tbsp runny honey, ½ tsp dried mixed herbs, 4 tbsp double cream, 1 tbsp cornflour mixed with 1 tbsp cold water, salt and freshly ground black pepper", "Heat the oil in a large non-stick frying pan over a medium-high heat. Season the chicken thighs on all sides with salt and freshly ground black pepper. Fry the chicken thighs, skin-side down, for 3–5 minutes or until crisp and golden. Turn and cook on the other side for 2 minutes. Frying the chicken will give it a lovely colour and render out some of the fat that sits just below the skin, but take care as it can spit a little as it fries. While the chicken is frying, pour the stock into the slow cooker and stir in the mustard, honey and herbs until thoroughly mixed. Add the chicken pieces to the slow cooker, skin-side up, cover and cook on high for 3–4 hours. Once the chicken is cooked, gently stir in the cream and cornflour mixture, cover and cook for a further 10 minutes or until the sauce thickens. (If your chicken releases lots of fat into the pot, you may want to spoon a little off before adding the cream.), Serve the chicken hot with the sauce and lots of freshly cooked vegetables, with potatoes or rice on the side.", 30, 120, "Traditional English", Region.Europe, "", 600, 4, 3.25, "https://tse3.mm.bing.net/th?id=OIP.SLTDY8MBsTOd7jdQ2KRCegHaLJ&pid=Api&P=0");
            var t17 = svc.CreateRecipe(u6.Id, "Hainanese Chicken Rice", Diet.Omnivorous, MealType.Dinner, "1 (3-1/2 pound) whole chicken, preferably free-range, Rock salt, for cleaning, 1/2 cup rice wine, 4 quarts chicken broth, 2 shallots, peeled and halved, 4 garlic cloves, smashed, 1-inch ginger root, scrubbed, 1 stalk lemongrass, white portion only, lightly pounded, 6 whole peppercorns, Salt, to taste, 3 cups chicken broth (reserved from poaching chicken), 2 cups long-grain rice, 2 tablespoons grated ginger, 2 tablespoons finely chopped scallions, 4 tablespoons peanut oil", "Rub the chicken all over with rock salt to remove impurities. Do this two to three times until you see that the skin is clean. Place the chicken in a pot deep enough to allow the chicken to be submerged in the cooking liquid. Pour in the rice wine and enough chicken broth so that there is at least an inch of liquid above the chicken. Bring to a boil, skimming off any scum that rises; then lower the heat so that the liquid is barely simmering. Add the shallots, garlic, ginger, lemongrass, peppercorns, and salt, if the broth is unsalted. Cover the pot and let the chicken poach—about 45 minutes. When the poaching time is finished, turn off the heat but leave the chicken in the pot, still covered, for another 10 minutes. strain the broth and measure 3 cups broth to cook the rice in. Let the broth cool. In a medium to large pot, add the cold broth to the rice and bring the mixture to a boil. Mix together the grated ginger, chopped scallions, peanut oil, and enough salt to taste.Cut the Chicken and Serve", 25, 80, "Singaporean", Region.Asia, "Nasi Ayam Hainan", 550, 4, 3.75, "https://tse1.mm.bing.net/th?id=OIP.5dMeTaEAxcIaJZ6eRZGcOgHaIr&pid=Api&P=0");
            var t18 = svc.CreateRecipe(u6.Id, "Shrimp Risotto", Diet.Omnivorous, MealType.Dinner, "3 tablespoons olive oil, 1 pound extra jumbo (16 to 20) shrimp, peeled and deveined, 1 teaspoon salt, 1/2 teaspoon freshly ground black pepper, 5 ounces (10 tablespoons) unsalted butter, divided, 6 cloves garlic, minced, 1 1/2 cups white wine, 1 1/2 tablespoons lemon juice, 2 tablespoons finely chopped parsley, 3 cups chicken stock, 2 tablespoons olive oil, 4 tablespoons unsalted butter, divided, 2 small shallots, minced, 3 clove garlic, minced, 1 cup Arborio rice, 1/2 cup shredded Parmesan cheese", "Sear the shrimp to golden brown on both sides. Remove the shrimp from the heat, Turn the heat to medium-low. Add 2 tablespoons of the butter to the pan and add the minced garlic. Sauté until fragrant, about 1 minute. Add the white wine and lemon juice to deglaze the pan. Allow the sauce to reduce by about a third. Whisk in the remaining butter and the parsley. Heat the olive oil and 2 tablespoons of the butter in the large skillet. Once the butter has melted, add the shallots and garlic. Add the Arborio rice and toss to coat in the oil and butter. Sauté until the rice is very lightly browned. Add a ladleful of the hot stock and stir until the stock is absorbed, repeat. Serve immediately", 30, 45, "Italian", Region.Europe, "Risotto ai gamberi", 450, 4, 3.15, "https://tse4.mm.bing.net/th?id=OIP.BdFSK8nvF94Ja7GNydzISQHaLH&pid=Api&P=0");

            //add reviews for Stock's recipes
            var e46 = new Review {RecipeId = 16, Name = "Carlos", ReviewedOn = new DateTime(17/11/2021), Comment = "10/10 - would recommend", Rating = 10};
            svc.AddReview(e46);

            var e47 = new Review {RecipeId = 16, Name = "Kenny", ReviewedOn = new DateTime(19/11/2021), Comment = "The chicken was so tender. Sauce was great!", Rating = 9};
            svc.AddReview(e47);

            var e48 = new Review {RecipeId = 16, Name = "Coleen", ReviewedOn = new DateTime(12/12/2021), Comment = "What a fantastic recipe. Everyone loved it! ", Rating = 10};
            svc.AddReview(e48);

            var e49 = new Review {RecipeId = 17, Name = "Phyliss", ReviewedOn = new DateTime(07/01/2021), Comment = "A great asian dish!! Thank You!", Rating = 9};
            svc.AddReview(e49);

            var e50 = new Review {RecipeId = 17, Name = "Brenda", ReviewedOn = new DateTime(17/4/2021), Comment = "I enjoyed it. Other family members found chicken a little dry", Rating = 8};
            svc.AddReview(e50);

            var e51 = new Review {RecipeId = 17, Name = "James", ReviewedOn = new DateTime(09/12/2021), Comment = "Tasty!!!!", Rating = 8};
            svc.AddReview(e51);

            var e52 = new Review {RecipeId = 18, Name = "Aisling", ReviewedOn = new DateTime(16/03/2021), Comment = "A great recipe. Risotto is tricky to make but turned out great", Rating = 9};
            svc.AddReview(e52);

            var e53 = new Review {RecipeId = 18, Name = "Majella", ReviewedOn = new DateTime(17/03/2021), Comment = "Struggled a little with risotto consistency although tasted good", Rating = 6};
            svc.AddReview(e53);

            var e54 = new Review {RecipeId = 18, Name = "Isobel", ReviewedOn = new DateTime(07/01/2021), Comment = "Fabulous!", Rating = 9};
            svc.AddReview(e54);


            // Register Balsamic Member 
            var u7 = svc.AddUser("balsamic", "balsamic@mail.com", "balsamic123", Role.member, "French", "I am married with (2) boys, 8 & 6 , I work part-time at night.I Love to cook, my children are very picky eaters, and my Husband is a Health Nut- so I make food and take it to work for someone to enjoy it :)",  "https://tse2.mm.bing.net/th?id=OIP.QVZCL29lFq6hGOh2rLKhlAHaI-&pid=Api&P=0" );

            //add recipes for Balsamic
            var t19 = svc.CreateRecipe(u7.Id, "Balsamic Peppers", Diet.Omnivorous, MealType.Lunch, "Extra-virgin olive oil, 1 large red pepper, seeded and cut lengthwise into chunky slices,  large orange or yellow pepper, seeded and cut likewise, 2 tbsps balsamic vinegar, ground black pepper, salt", " In a large skillet, stir together the olive oil and peppers over medium heat. Sauté the peppers for 5-7 minutes, until they are tender but still firm. Stir in the balsamic vinegar, pepper, and salt; cook for an additional 1 minute. Transfer the peppers and sauce to a dish and serve hot", 20, 20, "French", Region.Europe, "Poivre Balsamique", 600, 4, 3.25, "https://tse3.mm.bing.net/th?id=OIP.SLTDY8MBsTOd7jdQ2KRCegHaLJ&pid=Api&P=0");
            var t20 = svc.CreateRecipe(u7.Id, "Hainanese Chicken Rice", Diet.Omnivorous, MealType.Dinner, "1 (3-1/2 pound) whole chicken, preferably free-range, Rock salt, for cleaning, 1/2 cup rice wine, 4 quarts chicken broth, 2 shallots, peeled and halved, 4 garlic cloves, smashed, 1-inch ginger root, scrubbed, 1 stalk lemongrass, white portion only, lightly pounded, 6 whole peppercorns, Salt, to taste, 3 cups chicken broth (reserved from poaching chicken), 2 cups long-grain rice, 2 tablespoons grated ginger, 2 tablespoons finely chopped scallions, 4 tablespoons peanut oil", "Rub the chicken all over with rock salt to remove impurities. Do this two to three times until you see that the skin is clean. Place the chicken in a pot deep enough to allow the chicken to be submerged in the cooking liquid. Pour in the rice wine and enough chicken broth so that there is at least an inch of liquid above the chicken. Bring to a boil, skimming off any scum that rises; then lower the heat so that the liquid is barely simmering. Add the shallots, garlic, ginger, lemongrass, peppercorns, and salt, if the broth is unsalted. Cover the pot and let the chicken poach—about 45 minutes. When the poaching time is finished, turn off the heat but leave the chicken in the pot, still covered, for another 10 minutes. strain the broth and measure 3 cups broth to cook the rice in. Let the broth cool. In a medium to large pot, add the cold broth to the rice and bring the mixture to a boil. Mix together the grated ginger, chopped scallions, peanut oil, and enough salt to taste.Cut the Chicken and Serve", 25, 80, "Singaporean", Region.Asia, "Nasi Ayam Hainan", 550, 4, 3.75, "https://tse1.mm.bing.net/th?id=OIP.5dMeTaEAxcIaJZ6eRZGcOgHaIr&pid=Api&P=0");
            var t21 = svc.CreateRecipe(u7.Id, "Shrimp Risotto", Diet.Omnivorous, MealType.Dinner, "3 tablespoons olive oil, 1 pound extra jumbo (16 to 20) shrimp, peeled and deveined, 1 teaspoon salt, 1/2 teaspoon freshly ground black pepper, 5 ounces (10 tablespoons) unsalted butter, divided, 6 cloves garlic, minced, 1 1/2 cups white wine, 1 1/2 tablespoons lemon juice, 2 tablespoons finely chopped parsley, 3 cups chicken stock, 2 tablespoons olive oil, 4 tablespoons unsalted butter, divided, 2 small shallots, minced, 3 clove garlic, minced, 1 cup Arborio rice, 1/2 cup shredded Parmesan cheese", "Sear the shrimp to golden brown on both sides. Remove the shrimp from the heat, Turn the heat to medium-low. Add 2 tablespoons of the butter to the pan and add the minced garlic. Sauté until fragrant, about 1 minute. Add the white wine and lemon juice to deglaze the pan. Allow the sauce to reduce by about a third. Whisk in the remaining butter and the parsley. Heat the olive oil and 2 tablespoons of the butter in the large skillet. Once the butter has melted, add the shallots and garlic. Add the Arborio rice and toss to coat in the oil and butter. Sauté until the rice is very lightly browned. Add a ladleful of the hot stock and stir until the stock is absorbed, repeat. Serve immediately", 30, 45, "Italian", Region.Europe, "Risotto ai gamberi", 450, 4, 3.15, "https://tse4.mm.bing.net/th?id=OIP.BdFSK8nvF94Ja7GNydzISQHaLH&pid=Api&P=0");

            //add reviews for Balsamic's recipes
            var e55 = new Review {RecipeId = 19, Name = "Kennedy", ReviewedOn = new DateTime(07/11/2021), Comment = "Nice Recipe!", Rating = 7};
            svc.AddReview(e55);

            var e56 = new Review {RecipeId = 19, Name = "Michael", ReviewedOn = new DateTime(19/11/2021), Comment = "Nicest Peppers I have ever tried", Rating = 9};
            svc.AddReview(e56);

            var e57 = new Review {RecipeId = 20, Name = "Stacey", ReviewedOn = new DateTime(04/10/2021), Comment = "What a fantastic recipe. Everyone loved it!", Rating = 10};
            svc.AddReview(e57);

            var e58 = new Review {RecipeId = 20, Name = "Yolanda", ReviewedOn = new DateTime(06/07/2021), Comment = "Delicious. Can not fault it at all. Will be a weekly favourite", Rating = 10};
            svc.AddReview(e58);

            var e59 = new Review {RecipeId = 21, Name = "Monique", ReviewedOn = new DateTime(17/04/2021), Comment = "Not a bad recipe - shrimp were a little chewy", Rating = 7};
            svc.AddReview(e59);

            var e60 = new Review {RecipeId = 21, Name = "Leon", ReviewedOn = new DateTime(09/02/2021), Comment = "Tasty!!!!", Rating = 7};
            svc.AddReview(e60);

            //Register Member Taco
            var u8 = svc.AddUser("Taco", "taco@mail.com", "taco123", Role.member, "Mexician", "I moved to DC last year from Mexico. I became a vegetarian when I was 14, and learned if I wanted to eat food I like then I better cook it myself! Thankfully, it turns out I like cooking a lot. I usually get food cravings and then have to eat that food for a week straight, which some of my relatives are this way too so I think it must be genetic. I think some of the best meals I have made are impromtu with only the ingredients I have on hand.", "https://tse2.mm.bing.net/th?id=OIP.i-7SOToQAjo7Mp9PKgEi8wHaJQ&pid=Api&P=0" );

            //Add Recipes for Taco
            var t22 = svc.CreateRecipe(u8.Id, "Spicy Black Bean Taco", Diet.Vegetarian, MealType.Lunch, "3 garlic cloves, 3 x 400g cans black beans, drained and rinsed, 3 tbsp cider vinegar, 1 ½ tbsp honey, 1 ½ tbsp smoked paprika, 1 ½ tbsp ground cumin. 8-12 corn or flour tortillas, chipotle or other hot sauce, soured cream or coconut yogurt", "In a large frying pan, heat the oil and add the garlic. Fry until golden, then add the beans. Pour in the cider vinegar, honey and spices along with 1 tsp or more of salt, to taste. Cook until warmed through, crushing gently with the back of your wooden spoon, then set aside. To serve, put 1-2 heaped tbsp of beans on a tortilla. Top with a big spoonful of guacamole and some salsa, hot sauce and a dollop of soured cream or yogurt.", 20, 20, "Mexician", Region.NorthAmerica, "taco de frijol picante", 500, 4, 2.25, "https://tse3.mm.bing.net/th?id=OIP.gSA_zxesOksqi2QTejR5ZAHaJ4&pid=Api&P=0");
            var t23 = svc.CreateRecipe(u8.Id, "Easy Vegan Tacos", Diet.Vegan, MealType.Dinner, "175g pack baby corn, 1 large red onion, 1 red pepper, ½ tsp cumin seeds, 2 tsp olive oil, 1large ripe kiwi, 1 large tomato, 100g wholemeal flour, 1 large garlic clove, 15g fresh coriander, 1 tsp vegan bouillon powder, ½ tsp smoked paprika, 85g red cabbage", "Pile the corn, red onion and pepper into a large shallow roasting tin and toss with the cumin seeds and oil. Remove the cooked tomato and kiwi from the tin and return the veg to the oven for 10 mins. Remove the skin from the kiwi and scoop the flesh into a bowl with the tomato, garlic, half the coriander, bouillon and paprika. Use a hand blender to blitz to a smooth salsa, Heat a large non-stick frying pan, without oil, and cook the tortillas one at a time for a minute on one side and about 10 seconds on the other, until you see them puff up a little. Spread a tortilla with some salsa, top with cabbage and roasted veg, then scatter with the remaining coriander. Add a spoonful more salsa and eat with your hands.", 10, 30, "Mexician", Region.NorthAmerica, "Taco Vegano Facil", 450, 2, 2.19, "https://tse3.mm.bing.net/th?id=OIP.Fufnun-gwNjEg-Jh3O_CDgHaLH&pid=Api&P=0");
            var t24 = svc.CreateRecipe(u8.Id, "Curried Tofu Wraps", Diet.Vegan, MealType.Dinner, "½ red cabbage, 4 heaped tbsp dairy-free yogurt, 3 tbsp mint sauce, 3 x 200g packs tofu , each cut into 15 cubes, 2 tbsp tandoori curry paste, 2 tbsp oil, 2 onions, 2 large garlic cloves, 8 chapatis, 2 limes , cut into quarters",  "Mix the cabbage, yogurt and mint sauce, season and set aside. Toss the tofu with the tandoori paste and 1 tbsp of the oil. Heat a frying pan and cook the tofu, in batches, for a few mins each side until golden. Remove from the pan with a slotted spoon and set aside. Add the remaining oil to the pan, stir in the onions and garlic, and cook for 8-10 mins until softened. Return the tofu to the pan and season well. Warm the chapatis following pack instructions, then top each one with some cabbage, followed by the curried tofu and a good squeeze of lime", 20, 25, "Mexician", Region.NorthAmerica, "Envolturas de tofu al curry", 350, 4, 3.15, "https://tse4.mm.bing.net/th?id=OIP.cxoiCyb2dl7qXaTDymtaNwHaJ4&pid=Api&P=0");

            //add reviews for tacos recipes
            var e61 = new Review {RecipeId = 22, Name = "Paula", ReviewedOn = new DateTime(17/09/2021), Comment = "What a fantastic recipe! So delicious!", Rating = 9};
            svc.AddReview(e61);

            var e62 = new Review {RecipeId = 22, Name = "Patricia", ReviewedOn = new DateTime(09/01/2021), Comment = "9/10 - tasty recipe", Rating = 9};
            svc.AddReview(e62);

            var e63 = new Review {RecipeId = 23, Name = "Heather", ReviewedOn = new DateTime(14/03/2021), Comment = "Easy vegan taco, easy vegan recipe! Thank you. ", Rating = 10};
            svc.AddReview(e63);

            var e64 = new Review {RecipeId = 23, Name = "Mateo", ReviewedOn = new DateTime(09/04/2021), Comment = "Delicious", Rating = 9};
            svc.AddReview(e64);

            var e65 = new Review {RecipeId = 24, Name = "Angelo", ReviewedOn = new DateTime(17/03/2021), Comment = "Real Good. Could have a few more ingredients", Rating = 7};
            svc.AddReview(e65);

            var e66 = new Review {RecipeId = 24, Name = "Liam", ReviewedOn = new DateTime(09/02/2021), Comment = "7/10 - I have tried better", Rating = 7};
            svc.AddReview(e66);

            //Register member Breadstick
            var u9 = svc.AddUser("Breadstick", "breadstick@mail.com", "breadstick123", Role.member,  "French", "I have loved to cook as long as I can remember. My mom always had me in the kitchen helping a learing. I am a hair stlylist, but my dream is to open a resturant :)", "https://tse4.mm.bing.net/th?id=OIP.tS1bVzkDgDwi6DmWMY1ofAHaJQ&pid=Api&P=0" );

            //Add recipes for Breadstick
            var t25 = svc.CreateRecipe(u9.Id, "Niçoise stuffed baguette", Diet.Omnivorous, MealType.Lunch, "3 large eggs, 130g can tuna in olive oil, oil reserved, 1 large flute or baguette measuring approx 54cm, 2 tbsp mayonnaise, 3 tomatoes , 12-24 basil leaves, 12 pitted Kalamata olives, 8 anchovy fillets", "Bring a small pan of water to the boil. Add the eggs and boil for 10 mins. Drain, then run the eggs under the cold tap to cool quickly. Carefully shell and cut the eggs into wedge-shaped quarters. Meanwhile, mix all the ingredients for the shallot vinaigrette with seasoning and stir in the oil from the tuna. Slice the loaf in half lengthways, but not all the way through, so it opens up like a book. Use your fingers to pull out any bread that easily comes away from the top half to hollow the loaf a little. On the bottom half of the loaf, drizzle over the vinaigrette. Stir the mayonnaise into the tuna and spread on top. Now layer in the tomatoes, basil, olives, eggs and anchovies. Tightly roll up in baking parchment and secure down the length with elastic bands or string. Press really well all the way down the loaf, then chill overnight. Cut into slices if feeding a crowd, or into 4 lengths", 10, 10, "French", Region.Europe, "Baguette Farcie Niçoise", 200, 4, 1.45, "https://tse2.mm.bing.net/th?id=OIP.lGAoA57yJ9gBkW-OCc6VPwHaLH&pid=Api&P=0");
            var t26 = svc.CreateRecipe(u9.Id, "Mozzarella & salami picnic baguette", Diet.Omnivorous, MealType.Lunch, "1 white or brown baguette, 3 tbsp fresh green pesto, 1 beef tomato, 1 ball mozzarella, 2 handfuls baby spinach leaves, handful basil leaves, 6 slices salami", "Slice the baguette in half lengthways and hollow out (make crumbs from the bread centre and save for another recipe). Spread the bottom half with the pesto. Slice the tomato and layer it over the pesto. Slice the mozzarella and add in a layer over the tomato. Finish with layers of spinach and basil, plus the salami, folded in half if necessary to fit the width of the baguette", 10, 10, "French", Region.Europe, "Baguette pique-nique mozzarella & salami", 550, 4, 2.00, "https://tse3.mm.bing.net/th?id=OIP.IWPTXvpGEWT8IUvJsZ60IwAAAA&pid=Api&P=0");
            var t27 = svc.CreateRecipe(u9.Id, "Cheesy Garlic Baguette", Diet.Vegan,  MealType.Snack, "125g mozzarella ball, 140g taleggio cheese, 100g butter, 3 garlic cloves, handful parsley leaves, 1 tsp fresh marjoram leaves, 1 long baguette, large pinch of paprika", "Light the barbecue. Chop the mozzarella and taleggio into small chunks and tip into a bowl with the butter, garlic, herbs and some salt and pepper. If you want, you can mix everything together with a wooden spoon, but I prefer to use my hands. Using a bread knife, cut diagonal slices along the loaf about three quarters of the way into the bread – don’t cut all the way through. If it looks like the bread won’t fit on the barbecue, cut it in half and make two smaller ones.", 10, 10, "French", Region.Europe, "Baguette au fromage et à l'ail", 650, 4, 1.95, "https://tse3.mm.bing.net/th?id=OIP.87dpiO54yLUV1TeEFtD3GgDIE4&pid=Api&P=0&w=300&h=300");

            //add reviews for breadstick's recipes
            var e67 = new Review {RecipeId = 25, Name = "Angela", ReviewedOn = new DateTime(24/02/2021), Comment = "We love this picnic recipe, no need no alter it in any way", Rating = 9};
            svc.AddReview(e67);

            var e68 = new Review {RecipeId = 25, Name = "Bernie", ReviewedOn = new DateTime(20/12/2021), Comment = "Love this! I added cheese and de-seed the tomatoes. Great for picnic and late lunch", Rating = 9};
            svc.AddReview(e68);

            var e69 = new Review {RecipeId = 26, Name = "Leslie", ReviewedOn = new DateTime(10/03/2021), Comment = "The mozzerella was completely over powered by the pesto and again the use of both spinach and basil seemed pointless as i only tastes the basil.", Rating = 6};
            svc.AddReview(e69);

            var e70 = new Review {RecipeId = 26, Name = "Karen", ReviewedOn = new DateTime(17/10/2021), Comment = "Did not enjoy too much, little too many clashes of flavours", Rating = 5};
            svc.AddReview(e70);

            var e71 = new Review {RecipeId = 27, Name = "Garett", ReviewedOn = new DateTime(18/03/2021), Comment = "Very easy and tasty. Cooked in the oven for 8 minutes and was lovely", Rating = 8};
            svc.AddReview(e71);

            var e72 = new Review {RecipeId = 27, Name = "Kathleen", ReviewedOn = new DateTime(09/02/2021), Comment = "Very easy to make and with great results!", Rating = 7};
            svc.AddReview(e72);

            //Register member Hummus
            var u10 = svc.AddUser("Hummus", "hummus@mail.com", "hummus123", Role.member,  "Morrocan", "I have many interests including cooking, eating, hiking, gardening, collecting recipes and cookbooks, and reading. Both of may grandmothers were excellent cooks with different ethnic backgrounds and styles.", "https://tse4.mm.bing.net/th?id=OIP.5MEBZoEzPTxAFnfCGkct9QHaGs&pid=Api&P=0" );
            
            //add recipes for hummus
            var t28 = svc.CreateRecipe(u10.Id, "Classic Hummus", Diet.Vegan, MealType.Snack, "200g/7oz canned chickpeas, 2 tbsp lemon juice, 2 garlic cloves, 1 tsp ground cumin, pinch salt, 1 tbsp tahini, 4 tbsp water, 2 tbsp extra virgin olive oil, 1 tsp paprika, 4 rounds of pitta bread", "Drain the chickpeas and rinse. Reserve a few whole chick peas for serving. Combine the chickpeas, lemon juice, garlic, cumin, salt, tahini, and water in a food processor, and blend to a creamy purée. Add more lemon juice, garlic, cumin or salt to taste. Turn out into a dinner plate, and make smooth with the back of a spoon. Drizzle with extra virgin olive oil and scatter with the reserved chickpeas. Sprinkle with paprika and serve with pita bread, warmed in a moderate oven for three minutes, and cut into quarters.", 30, 10, "Mediterranean", Region.MiddleEast, "Alhimas/ho͝oməs", 200, 10, 0.69, "https://tse2.mm.bing.net/th?id=OIP.54gMLZ17TyAZlLvvm_N21AHaLM&pid=Api&P=0");
            var t29 = svc.CreateRecipe(u10.Id, "Roasted Red Pepper Hummus", Diet.Vegan, MealType.Snack, "3 large red peppers, 1 red chilli, 1 tsp olive oil, 1 small onion, 1/2 tsp ground coriander, 1 tsp ground cumin, 1 x 400g/14oz can chickpeas, ½ garlic clove, ½ unwaxed lemon, 1 tbsp pomegranate molasses, ½ tsp sea salt, freshly ground black pepper, to taste", "Grill the peppers for 10-15 minutes or until the skins are black all over. With a pair of tongs, transfer the hot peppers to a bowl and cover tightly with cling film. The steam will help finish cooking the peppers and loosen their skins. Leave to cool for 10 minutes or so. Meanwhile heat the olive oil in a small frying pan. Add the chopped onion and fry over a medium heat for five minutes, or until softened, stirring occasionally. Stir in the ground coriander and ground cumin, then leave to cool for five minutes.", 30, 30, "Moroccan", Region.MiddleEast, "hims bialfilfil al'ahmar almuhamas", 350, 10, 0.99, "https://tse3.mm.bing.net/th?id=OIP.Mjd20BFB08_kezOf7X7hSwHaLH&pid=Api&P=0");
            var t30 = svc.CreateRecipe(u10.Id, "Beetroot Hummus", Diet.Vegan,  MealType.Snack, "1 tsp cumin seeds, 250g/9oz cooked beetroot, 400g tin chickpeas, 1 garlic clove, 1 tsp ground coriander, ½ tsp flaked sea salt, 2 tbsp extra virgin olive oil, 2 tbsp fresh lemon juice, ground black pepper", "Toast the cumin seeds gently in a small dry frying pan for 2 minutes, stirring occasionally, then remove from the heat. Put the beetroot, chickpeas, garlic, coriander, salt and olive oil in a food processor. Add the cumin seeds and lemon juice and season well with freshly ground black pepper. Blitz until smooth. Check the seasoning to taste, adding a little more salt, pepper or lemon juice if needed, and blitz again. Use the hummus as a spread for sandwiches and wraps or as a dip. Keep covered in the fridge for up to 3 days, or freeze.", 25, 5, "Metiterranean", Region.MiddleEast, "hims shamandar", 250, 8, 0.95, "https://tse2.mm.bing.net/th?id=OIP.iJmTib--EL9dpWnhM3ORPQHaLH&pid=Api&P=0");

            //Add reviews for hummus's recipes
            var e73 = new Review {RecipeId = 28, Name = "Olivia", ReviewedOn = new DateTime(24/04/2021), Comment = "Basic recipe but very good hummus", Rating = 9};
            svc.AddReview(e73);

            var e74 = new Review {RecipeId = 28, Name = "Newton", ReviewedOn = new DateTime(29/12/2021), Comment = "Simple and tasty!", Rating = 9};
            svc.AddReview(e74);

            var e75 = new Review {RecipeId = 29, Name = "John", ReviewedOn = new DateTime(10/06/2021), Comment = "Very good, thank you. Will never buy from store again ", Rating = 9};
            svc.AddReview(e75);

            var e76 = new Review {RecipeId = 29, Name = "Travis", ReviewedOn = new DateTime(05/06/2021), Comment = "Good hummus, little bit more salt needed perhaps", Rating = 7};
            svc.AddReview(e76);

            var e77 = new Review {RecipeId = 30, Name = "Gerard", ReviewedOn = new DateTime(18/03/2021), Comment = "Family party favourite. DELICIOUS",  Rating = 10};
            svc.AddReview(e77);

            var e78 = new Review {RecipeId = 30, Name = "Kitty", ReviewedOn = new DateTime(19/04/2021), Comment = "Enjoyed the recipe. Made a few chances", Rating = 7};
            svc.AddReview(e78);

            //Register Burger member
            var u11 = svc.AddUser("Burger", "burger@mail.com", "burger123", Role.member,  "American", "I'm an everyday American man who has a passion for cooking I grew up in a family of 6. I started cooking at a young age, and as time has gone by, my interest has developed into a passion. I enjoy cooking and baking, and one of my recent ventures has been into the arena of cake decorating. I find cooking and baking a very worthwhile activity to pursue, I view baking and cooking as a labour of love. While I do enjoy tweaking recipes, I will always make it as originally stated, it really amuses me when people massacre recipes and then rate them so low, so I make it a point to always try the recipe as written the first time around! Sadly my blog is dormant, but you can follow me on Instagram: @ilygourmet", "https://tse2.mm.bing.net/th?id=OIP.hSKZ32Bq0CJxXUT3T12_iwHaJU&pid=Api&P=0");

            //add recipes for burger
            var t31 = svc.CreateRecipe(u11.Id, "Perfect American Burger", Diet.Omnivorous, MealType.Dinner, "1 large egg, ½ teaspoon salt, ½ teaspoon ground black pepper, 1 pound ground beef, ½ cup fine dry bread crumbs", "Preheat an outdoor grill for high heat and lightly oil grate. Whisk together egg, salt, and pepper in a medium bowl. Add ground beef and bread crumbs and mix with your hands or a fork until well blended. Form into four 3/4-inch-thick patties. Place patties on the preheated grill. Cover and cook 6 to 8 minutes per side, or to desired doneness. An instant-read thermometer inserted into the center should read at least 160 degrees", 5, 15, "American", Region.CentralAmerica, "", 200, 4, 1.25, "https://tse4.mm.bing.net/th?id=OIP.YeSGawDErkXmQocnADt_0QHaJ9&pid=Api&P=0");
            var t32 = svc.CreateRecipe(u11.Id, "Veggie Burger", Diet.Vegetarian, MealType.Dinner, "1 shallot or ½ onion, 1 stick of celery, parsley, 400g can chickpeas, 1-2 tsp garam masala, 1 tbsp tomato purée, 2 tbsp plain flour, 1 tbsp polenta , couscous, or dried breadcrumbs", "Whizz the shallot, celery, parsley and most of the chickpeas to a coarse paste. Don’t overdo this, you want a texture slightly rougher than hummus. Mash the remaining chickpeas and stir them into the paste with the garam masala, tomato purée, flour and polenta. Season well. Shape the mixture into four patties. Let them rest for at least 30 mins – you can leave them overnight in the fridge if you like. The polenta needs time to absorb any extra liquid.", 10, 10, "American", Region.CentralAmerica, "", 350, 2, 1.25, "https://tse2.mm.bing.net/th?id=OIP.5vcS3lzAiTZhe73vL9Mk9AHaLH&pid=Api&P=0");
            var t33 = svc.CreateRecipe(u11.Id, "Really Easy Beef Burger", Diet.Omnivorous,  MealType.Dinner, "500g pack lean minced beef, 1 tsp mild chilli powder, 4 slices mild cheddar, 4 burger buns, choice of lettuce , cucumber, gherkin, tomato and red onion, ketchup or mayonnaise , or both", "Fry the burgers on a hot griddle or grill them outside on the barbecue for 5 mins on each side, turning them carefully with a metal spatula. Take care as hot fat from the meat may spit a little. Top with cheese and toast the buns: If you want to make cheeseburgers, put a slice of cheese on top of the burgers when you turn them over and let it melt while the other side cooks. When they are ready, cut the burger baps in half and warm them in the toaster or on the barbecue - take care that you don’t burn them.",  20, 25, "American", Region.CentralAmerica, "", 350, 4, 1.95, "https://tse3.mm.bing.net/th?id=OIP.tjk9EAWUiTUou3bcKag7-gHaJQ&pid=Api&P=0");

            //add reviews for burgers 
            var e79 = new Review {RecipeId = 31, Name = "Christine", ReviewedOn = new DateTime(24/04/2021), Comment = "Basic recipe but very good", Rating = 9};
            svc.AddReview(e79);

            var e80 = new Review {RecipeId = 31, Name = "Kelly", ReviewedOn = new DateTime(29/12/2021), Comment = "Simple and tasty!", Rating = 9};
            svc.AddReview(e80);

            var e81 = new Review {RecipeId = 32, Name = "John", ReviewedOn = new DateTime(10/06/2021), Comment = "Very good, thank you! ", Rating = 9};
            svc.AddReview(e81);

            var e82 = new Review {RecipeId = 32, Name = "Mary", ReviewedOn = new DateTime(05/06/2021), Comment = "Little bit more salt needed perhaps", Rating = 7};
            svc.AddReview(e82);

            var e83 = new Review {RecipeId = 33, Name = "Gerrard", ReviewedOn = new DateTime(18/03/2021), Comment = "Family BBQ favourite. DELICIOUS",  Rating = 10};
            svc.AddReview(e83);

            var e84 = new Review {RecipeId = 33, Name = "Kathleen", ReviewedOn = new DateTime(19/04/2021), Comment = "Enjoyed the recipe. Made a few chances", Rating = 7};
            svc.AddReview(e84);

            //Reguster Seabass member
            var u12 = svc.AddUser("Seabass", "seabass@mail.com", "seabass123", Role.member, "Spanish", "I received my culinary degree from Paul Smith's College, NY, in 1983. After 15 plus years in the food industry, I was hired as a Chef Instructor at the prestigious California Culinary Academy. After five successful years of teaching, I left to follow my dream of teaching a larger audience online", "https://tse3.mm.bing.net/th?id=OIP.GUA4cD2RI2IM8bA0M820QQHaJF&pid=Api&P=0" );

            //Add recipes for Seabass
            var t34 = svc.CreateRecipe(u12.Id, "Ginger and Chilli Seabass", Diet.Vegetarian, MealType.Dinner, "6 x sea bass fillets, about 140g/5oz each, about 3 tbsp sunflower oil, large knob of ginger, 3 garlic cloves, 3 fat, fresh red chillies, bunch spring onion, 1 tbsp soy sauce", "Once hot, fry the sea bass fillets, skin-side down, for 5 mins or until the skin is very crisp and golden. The fish will be almost cooked through. Turn over, cook for another 30 seconds - 1 minute, then transfer to a serving plate and keep warm. You’ll need to fry the sea bass fillets in 2 batches", 15, 10, "Mediterranaen", Region.Europe, "lubina con chile y jengibre", 400, 4, 1.25, "https://tse1.mm.bing.net/th?id=OIP.9G043S8I_owHGuiWt8PvTwHaLH&pid=Api&P=0");
            var t35 = svc.CreateRecipe(u12.Id, "Lemon Caper Seabass", Diet.Vegetarian, MealType.Dinner, "4 x 100g/4oz sea bass fillets, olive oil, For the caper dressing: 3 tbsp extra virgin olive oil, grated zest 1 lemon, plus 2 tbsp juice, 2 tbsp small capers, 2 tsp gluten-free Dijon mustard, 2 tbsp chopped flat-leaf parsley", "Heat the oven to 220C/200C fan/gas 7. Line a baking tray with baking parchment and put the fish, skin-side up, on top. Brush the skin with oil and sprinkle with some flaky salt. Bake for 7 mins or until the flesh flakes when tested with a knife. Arrange the fish on warm serving plates, spoon over the dressing and scatter with extra parsley leaves, if you like.", 10, 10, "Mediterranean", Region.Europe, "lubina alcaparras limón", 350, 4, 1.25, "https://tse3.mm.bing.net/th?id=OIP.1DOvqGwcrNEcshd0Z9-B1AHaLL&pid=Api&P=0");
            var t36 = svc.CreateRecipe(u12.Id, "Fennel Seabass", Diet.Vegetarian,  MealType.Dinner, "2 small sea bass, 1 fennel bulb, 1 lemon, handful basil leaves, small handful black olives, 1 tbsp olive oil", "Rinse and dry the fish. Season all over, then stuff the cavity with some fennel slices, lemon and basil. Scatter the olives and any leftover fennel, basil and lemon into a roasting tin. Place the sea bass on top. Drizzle each fish with the oil and bake for about 30 mins or until cooked through and starting to brown.",  15, 30, "Mediterranean", Region.Europe, "lubina al hinojo al horno", 350, 4, 3.95, "https://tse1.mm.bing.net/th?id=OIP.CEsdJw4tE9yBezLXah0FHgHaHa&pid=Api&P=0&w=300&h=300");

            //Add reviews for seabass's recipes
            var e85 = new Review {RecipeId = 34, Name = "Nadine", ReviewedOn = new DateTime(24/04/2021), Comment = "The nicest seabass I have ever eaten", Rating = 10};
            svc.AddReview(e85);

            var e86= new Review {RecipeId = 34, Name = "Cillian", ReviewedOn = new DateTime(29/12/2021), Comment = "Simple but tasty!", Rating = 9};
            svc.AddReview(e86);

            var e87 = new Review {RecipeId = 35, Name = "Anna", ReviewedOn = new DateTime(10/06/2021), Comment = "Would not be a big fan of capers but it was delicious", Rating = 9};
            svc.AddReview(e87);

            var e88 = new Review {RecipeId = 35, Name = "Mary", ReviewedOn = new DateTime(05/06/2021), Comment = "Little bit more salt needed perhaps", Rating = 8};
            svc.AddReview(e88);

            var e89 = new Review {RecipeId = 36, Name = "Angelo", ReviewedOn = new DateTime(18/03/2021), Comment = "easy, one pan dish. great for all the family",  Rating = 10};
            svc.AddReview(e89);

            var e90 = new Review {RecipeId = 36, Name = "Mateo", ReviewedOn = new DateTime(19/04/2021), Comment = "Enjoyed the recipe. Made a few chances", Rating = 8};
            svc.AddReview(e90);

            //Register Chicken member
            var u13 = svc.AddUser("Chicken", "chicken@mail.com", "chicken123", Role.member, "Scottish", "I love making people happy with good food. I really enjoy good wine or a great martini", "https://tse1.mm.bing.net/th?id=OIP.80sQGt-bdTXixTVotmtDpwHaJI&pid=Api&P=0" );

            //Add recipes for chicken
            var t37 = svc.CreateRecipe(u13.Id, "Chicken and Sweet Potato Curry", Diet.Omnivorous, MealType.Dinner, "500g sweet potato, 1 tbsp olive oil, 4 skinless chicken thigh fillets, 1 large red onion, 2 tbsp rogan josh curry paste, 2 large tomatoes, roughly chopped, 125g spinach", "Cook the sweet potatoes in boiling, salted water for 5-7 mins until just tender. Drain well, then set aside. Meanwhile, heat the oil in a large frying pan, then add the chicken and onion. Cook for 5-6 mins until the chicken is browned and cooked through. Stir in the curry paste, cook for 1 min, add the tomatoes, then cook for another min.", 10, 20, "Indian", Region.Asia, "shakarakand chikan karee/Cilagaḍadumpa ciken kūra", 400, 4, 2.25, "https://tse3.mm.bing.net/th?id=OIP.4XyiUcluvuSytpouVtsaLAHaLH&pid=Api&P=0");
            var t38 = svc.CreateRecipe(u13.Id, "Lemon and Herb Chicken", Diet.Omnivorous, MealType.Dinner, "800g potatoes, 3 tbsp olive oil, 1 red onion, 4 garlic cloves, 400g can tomatoes, 2 x 400g cans butter beans, 1 tsp mixed dried herbs, 1kg skin-on, 1 lemon", "ake the wedges and chicken traybake in the oven at 180C/160C fan/gas 4 for 45 mins until the chicken is cooked through. Check the potatoes after about 30 mins, shaking them around in the tray – depending on the size of the wedges, they may already be cooked through.", 10, 10, "Mediterranean", Region.Europe, "pollo a la hierba de limon", 350, 4, 1.25, "https://tse1.mm.bing.net/th?id=OIP.x9cZtZlC2Gewfysx0zREOQHaLH&pid=Api&P=0");
            var t39 = svc.CreateRecipe(u13.Id, "Asian Chicken Rice", Diet.Omnivorous,  MealType.Dinner, "1/4 cup rice vinegar, 1 green onion, minced, 2 tablespoons reduced-sodium soy sauce, 1 tablespoon toasted sesame seeds, 1 tablespoon sesame oil, 1 tablespoon honey", "For dressing, whisk together first 7 ingredients. Cook rice according to package directions. Divide among 4 bowls. In a large bowl, toss coleslaw mix and chicken with half of the dressing. Serve edamame and slaw mixture over rice; drizzle with remaining dressing.",  15, 30, "Asian", Region.Asia, "Yàzhōu jī fàn", 450, 4, 2.95, "https://tse4.mm.bing.net/th?id=OIP.XuTGDOKH2k5W23JmDe74XAHaLH&pid=Api&P=0");

            //add reviews for chicken's recipes
            var e91 = new Review {RecipeId = 37, Name = "Amy", ReviewedOn = new DateTime(24/04/2021), Comment = "Super Tasty - a great hit any time of the year", Rating = 9};
            svc.AddReview(e85);

            var e92= new Review {RecipeId = 37, Name = "Saoirse", ReviewedOn = new DateTime(29/12/2021), Comment = "Simple to make - tastes great. Thank You!", Rating = 9};
            svc.AddReview(e86);

            var e93 = new Review {RecipeId = 38, Name = "Ashling", ReviewedOn = new DateTime(10/06/2021), Comment = "Delicious!!!!", Rating = 9};
            svc.AddReview(e87);

            var e94 = new Review {RecipeId = 38, Name = "Annette", ReviewedOn = new DateTime(05/06/2021), Comment = "Great recipe. Will make again!", Rating = 8};
            svc.AddReview(e88);

            var e95 = new Review {RecipeId = 39, Name = "Monique", ReviewedOn = new DateTime(18/03/2021), Comment = "easy, one pan dish. great for all the family",  Rating = 10};
            svc.AddReview(e89);

            var e96 = new Review {RecipeId = 39, Name = "Mateo", ReviewedOn = new DateTime(19/04/2021), Comment = "Enjoyed the recipe. Made a few chances", Rating = 8};
            svc.AddReview(e90);
    
            //Register Beef member
            var u14 = svc.AddUser("Beef", "beef@mail.com", "beef123", Role.member, "Portuguese", "I'm a stay at home cooking biker chick. Been riding my own motorcycle since I was 18. I love to cook, bake especially, and I love to ride my Harley Davidson Sportster. My other half rides a Harley Davidson Fatboy and A Triumph Sports Bike. We've got 1 daughter and 5 grandkids ranging from ages 11 to 21. We're known as the coolest, youngest grandparents around!!!", "https://tse1.mm.bing.net/th?id=OIP.gMVhsmglSQVX8KTj56qeRwHaE8&pid=Api&P=0");

            //Add recipes for beef member
            var t40 = svc.CreateRecipe(u14.Id, "Beef Broccoli Noodles ", Diet.Omnivorous, MealType.Dinner, "3 blocks egg noodles, 1 head broccoli , 1 tbsp sesame oil, 400g pack beef stir-fry strips, sliced spring onion", "Start by making up the sauce. Mix the ingredients together in a small bowl. Boil the noodles according to pack instructions. A minute before they are ready, tip in broccoli. Meanwhile, heat the oil in a wok until very hot, then stir-fry the beef for 2-3 mins until well browned. Tip in the sauce, give it a stir, let it simmer for a moment, then turn off the heat. Drain the noodles, stir into the beef and serve straight away, scattered with spring onions.", 10, 10, "Asian", Region.Asia, "Goḍḍu mānsaṁ mariyu brōkalī nūḍuls", 400, 4, 2.25, "https://tse1.mm.bing.net/th?id=OIP.zjjtJiWEvUjksSb7CyxabwHaKX&pid=Api&P=0");
            var t41 = svc.CreateRecipe(u14.Id, "Beef Stroganaff", Diet.Omnivorous, MealType.Dinner, "1 tbsp olive oil, 1 clove of garlic, 1 tbsp butter, 250g mushrooms, 1 tbsp plain flour, 500g fillet steak, 150g crème fraîche, 1 tsp English mustard, 100ml beef stock, ½ small pack of parsley, chopped", "Heat 1 tbsp olive oil in a non-stick frying pan then add 1 sliced onion and cook on a medium heat until completely softened, around 15 mins, adding a little splash of water if it starts to stick", 10, 35, "Russian", Region.Europe, "befstroganov", 450, 4, 2.25, "https://tse3.mm.bing.net/th?id=OIP.7rIzNaYnV0mDmPEo-WSx0QHaKx&pid=Api&P=0");
            var t42 = svc.CreateRecipe(u14.Id, "Easy Roast Beef", Diet.Omnivorous,  MealType.Dinner, "1 tsp plain flour, 1 tsp mustard powder, 950g beef top rump joint, 1 onion, cut into 8 wedges, 500g carrots, halved lengthways", "",  15, 60, "British", Region.Europe, "", 650, 6, 5.95, "https://tse4.mm.bing.net/th?id=OIP.k5p08y50g0410aABG9ua8AHaLI&pid=Api&P=0");

            //Add reviews for beef's recipes
            var e97 = new Review {RecipeId = 40, Name = "Theo", ReviewedOn = new DateTime(24/04/2021), Comment = "Super Tasty - a great hit any time of the year", Rating = 7};
            svc.AddReview(e97);

            var e98= new Review {RecipeId = 40, Name = "Thomas", ReviewedOn = new DateTime(29/12/2021), Comment = "Simple to make - tastes great. Thank You!", Rating = 7};
            svc.AddReview(e98);

            var e99 = new Review {RecipeId = 41, Name = "Lola", ReviewedOn = new DateTime(10/06/2021), Comment = "Delicious!!!!", Rating = 9};
            svc.AddReview(e99);

            var e100 = new Review {RecipeId = 41, Name = "Ann", ReviewedOn = new DateTime(05/06/2021), Comment = "Great recipe. Will make again!", Rating = 8};
            svc.AddReview(e100);

            var e101 = new Review {RecipeId = 42, Name = "Yolanda", ReviewedOn = new DateTime(18/03/2021), Comment = "British Favourite - really good!",  Rating = 10};
            svc.AddReview(e101);

            var e102 = new Review {RecipeId = 42, Name = "William", ReviewedOn = new DateTime(19/04/2021), Comment = "Sensational!!!!! ", Rating = 10};
            svc.AddReview(e102);
    
            //Register Fish member
            var u15 = svc.AddUser("Fish", "fish@mail.com", "fish123", Role.member, "Greek", "Love to cook I grew up in my mother's restaurant, and some of my childhood memories include helping to peel potatoes with the prep cooks after school! I've always loved food, and making recipes with pure and wholesome ingredients is very important to me.", "https://tse2.mm.bing.net/th?id=OIP.zOXwKbQfHdJEOyMSiy7_iAHaJQ&pid=Api&P=0" );

            //Add Recipes for Fish
            var t43 = svc.CreateRecipe(u15.Id, "Curried Cod", Diet.Vegetarian, MealType.Dinner, "1 tbsp oil, 1 onion, 2 tbsp medium curry powder, thumb-sized piece ginger, 3 garlic cloves, 2 x 400g cans chopped tomatoes, 400g can chickpeas, 4 cod fillets, zest 1 lemon, handful coriander, roughly chopped", "Heat the oil in a large, lidded frying pan. Cook the onion over a high heat for a few mins, then stir in the curry powder, ginger and garlic. Cook for another 1-2 mins until fragrant, then stir in the tomatoes, chickpeas and some seasoning.", 10, 40, "Indian", Region.Asia, "Kūra kāḍ/ikan tongkol kari", 400, 4, 2.25, "https://tse2.mm.bing.net/th?id=OIP.d-tyFMzOUiydKQblakpv-gHaKf&pid=Api&P=0");
            var t44 = svc.CreateRecipe(u15.Id, "Chorizo Haddock", Diet.Vegetarian, MealType.Dinner, "1 tbsp extra-virgin olive oil , 50g chorizo , 450g salad or new potatoes , 4 tbsp dry sherry , 2 skinless haddock, good handful cherry tomatoes , 20g bunch parsley , crusty bread", "Season the fish well. Give the potatoes another stir, add the cherry tomatoes and most of the chopped parsley to the pan, then lay the fish on top. Splash over 1 tbsp sherry, put the lid on again, then leave to cook for 5 mins, or until the fish has turned white and is flaky when prodded in the middle. Scatter the whole dish with a little more parsley and drizzle with more extra virgin oil. Serve straight away with crusty bread", 10, 30, "Mediterranean", Region.Europe, "eglefino con chorizo", 350, 4, 2.25, "https://tse3.mm.bing.net/th?id=OIP.DB1Ml8ehNXyiz99adX59jwHaJ4&pid=Api&P=0");
            var t45 = svc.CreateRecipe(u15.Id, "Tuna Pasta Bake", Diet.Vegetarian,  MealType.Dinner, "600g rigatoni, 50g butter, 50g plain flour, 600ml milk, 250g strong cheddar, grated, 2 x 160g cans tuna steak in spring water, drained, 330g can sweetcorn, drained, large handful chopped parsley", "Drain the pasta, mix with the white sauce, two 160g drained cans tuna, one 330g drained can sweetcorn and a large handful of chopped parsley, then season. Transfer to a baking dish and top with the rest of the grated cheddar. Bake for 15-20 mins until the cheese on top is golden and starting to brown.",  15, 30, "Italian", Region.Europe, "pasta al tonno", 450, 4, 2.95, "https://tse4.mm.bing.net/th?id=OIP.rxG4u4gV0TAGYCInL0Pd5AHaLH&pid=Api&P=0");
            
            //Add Reviews for fish's recipes
            var e103 = new Review {RecipeId = 43, Name = "Marcella", ReviewedOn = new DateTime(24/04/2021), Comment = "Paired with some crsuty bread - perfect", Rating = 7};
            svc.AddReview(e103);

            var e104= new Review {RecipeId = 43, Name = "Alana", ReviewedOn = new DateTime(29/12/2021), Comment = "Made with pumpkin instead - delicious", Rating = 7};
            svc.AddReview(e104);

            var e105 = new Review {RecipeId = 44, Name = "Deborah", ReviewedOn = new DateTime(10/06/2021), Comment = "A great recipe - fish was great!!!!", Rating = 9};
            svc.AddReview(e105);

            var e106 = new Review {RecipeId = 44, Name = "Carol", ReviewedOn = new DateTime(05/06/2021), Comment = "Great recipe. Will make again!", Rating = 8};
            svc.AddReview(e106);

            var e107 = new Review {RecipeId = 45, Name = "Abi", ReviewedOn = new DateTime(18/03/2021), Comment = "Reminds me of my Mother - Thank You",  Rating = 10};
            svc.AddReview(e107);

            var e108 = new Review {RecipeId = 45, Name = "Dale", ReviewedOn = new DateTime(19/04/2021), Comment = "Reminds me of my childhood! Superb!", Rating = 10};
            svc.AddReview(e108);

            //Register an administrator 
            var u16 = svc.AddUser("Admin", "admin@mail.com", "admin", Role.admin, "Spanish", "", "https://tse4.mm.bing.net/th?id=OIP.5jGag5iSzz-Cdsy1FEsd2QHaJC&pid=Api&P=0");

        }
    }
}
