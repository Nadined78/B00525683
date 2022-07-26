// using System;
// using System.Text;
// using System.Collections.Generic;
// using SMS.Data.Models;

// namespace SMS.Data.Services
// {
//     public static class FoodServiceSeeder
//     {
//         // seeding the database with dummy test data using an IFoodService 
//         public static void Seed(IFoodService svc)
//         {
//             // wipe and recreate the database
//             svc.Initialise();

//             // register pasta
//             var u1 = svc.Register("Pasta", "pasta@mail.com", "pasta123", Role.member, "Italian",  "https://tse3.mm.bing.net/th?id=OIP.HIBwLtEXMnop_y4pGUVbQwHaLH&pid=Api&P=0&w=109&h=163" );
           
//             // add recipes for pasta
//             var r1 = svc.CreateRecipe(u1.Id, "Cajun Chicken Pasta", Diet.Omnivorous, MealType.Dinner, "chicken, onion, peppers, cajun spice, pasta, double cream", "Marninate Chicken breast fillets in Cajun Spices over night, fry on a low heat in olive oil until cooked. remove chicken from pan and set aside", 20, 18, "Italian", "Italy", "Cajun Pollo Pasta", 470, 2, "https://tse1.mm.bing.net/th?id=OIP.iw_7gH8lF80C5RcIhVWlLQHaLH&pid=Api&P=0&w=102&h=153");
//             var r2 = svc.CreateRecipe(u1.Id, "Spaghetti Bolognese", Diet.Omnivorous, MealType.Dinner, "Lean mince beef, tomato puree, passata, onion, bacon, red wine", "fry off onion for 5 minutes, season mince and fry until browned, add tablespoon puree, carton of passata, cup of red wine, boil pasta", 15, 60, "Italian", "Italy", "Spaghetti Alla Bolognese", 500, 4, "https://tse2.mm.bing.net/th?id=OIP.lzO82PYyrudX9qcEnqS28wHaKN&pid=Api&P=0&w=117&h=161" );
//             var r3 = svc.CreateRecipe(u1.Id, "Chicken and Bacon Carbonara", Diet.Omnivorous, MealType.Dinner, "pasta, onion, chicken, parmasean, egg yolk, bacon", "cook pasta, fry onion, add bacon until browned, add egg yolk and parmesan to bowl and mix to a thick consistency, lower heat to lowest setting, add mix to pan with half a cup of pasta water and bring together", 20, 45, "Italian", "Italy", "pancetta di pollo carbonara", 375, 2, "https://tse1.mm.bing.net/th?id=OIP.REMYdE2c1UbI5QUQXS3FqQHaJQ&pid=Api&P=0&w=136&h=170" );
            
//             // add reviews for pasta's recipes 
//             var e1 = new Review { RecipeId = 1, Name = "Michael", ReviewedOn = new DateTime(08/07/2022), Comment = "Delicious Recipe, a must-try!!!", Rating = 10 };
//             svc.AddReview(e1);
            
//             var e2 = new Review { RecipeId = 1, Name = "Cillian", ReviewedOn = new DateTime(17/10/22), Comment = "The chicken was beautiful. Thank You", Rating = 9 };
//             svc.AddReview(e2);

//             var e3 = new Review { RecipeId= 1, Name = "Conor", ReviewedOn = new DateTime(24/02/21), Comment = "I added some chorizo and it was great!", Rating = 9 };
//             svc.AddReview(e3);

//             var e4 = new Review { RecipeId= 2, Name = "Carolina", ReviewedOn = new DateTime(20/12/2021), Comment = "Tasty!" , Rating = 8};
//             svc.AddReview(e4);

//             var e5 = new Review { RecipeId= 2, Name = "Monica", ReviewedOn = new DateTime(25/03/2022), Comment = "Sauce was a little watery. Will try again as flavour was great", Rating = 7};
//             svc.AddReview(e5);

//             var e6 = new Review { RecipeId= 2, Name = "Roberta", ReviewedOn = new DateTime(30/04/2022), Comment = "Kids loved it!", Rating = 8};
//             svc.AddReview(e6);

//             var e7 = new Review { RecipeId= 3, Name = "Alana", ReviewedOn = new DateTime(04/09/2021), Comment = "Added some red peppers and it was Delicious", Rating = 9 };
//             svc.AddReview(e7);

//             var e8 = new Review { RecipeId= 3, Name = "Stephen", ReviewedOn = new DateTime(01/01/2021), Comment = "Nice Recipe!!!", Rating = 6 };
//             svc.AddReview(e8);

//             var e9 = new Review { RecipeId= 3, Name = "Isabella Lazio", ReviewedOn = new DateTime(05/07/2021), Comment = "Added Cherry Tomatoes, be sure to save enough pasta water. Will make again", Rating = 8};
//             svc.AddReview(e9);

//             // register pizza member
//             var u2 = svc.Register("Pizza", "pizza@mail.com", "pizza123", Role.member, "Italian", "https://tse3.mm.bing.net/th?id=OIP.Gi-aQfdYcOTWE_x7zGz7YQHaI2&pid=Api&P=0");

//             // // add recipes for pizza
//             var t4 = svc.CreateRecipe(u2.Id, "Chicken and Pepperoni Pizza", Diet.Omnivorous, MealType.Dinner, "Chicken, pepperoni, pizza dough, tomato based sauce, mozzarella, cheddar cheese", "Method", 30, 45, "Italian", "Europe", "Pizza peperoni di pollo", 450, 2, "https://tse4.mm.bing.net/th?id=OIP.1YJoRwA972tJg76PfTJ22wHaLH&pid=Api&P=0&w=110&h=165" );
//             var t5 = svc.CreateRecipe(u2.Id, "Mushroom Pizza", Diet.Vegetarian, MealType.Dinner, "Mushroom, pizza dough, tomato based sauce, mozzarella, cheddar cheese", "Method", 15, 15, "Italian", "Europe", "Pizza ai Funghi", 350, 2, "https://tse2.mm.bing.net/th?id=OIP.bEMl9MFoe6hpZcNkwfDoQwHaLH&pid=Api&P=0&w=105&h=157" );
//             var t6 = svc.CreateRecipe(u2.Id, "Margherita Pizza", Diet.Vegetarian, MealType.Dinner, "Basil, Mozzarella, tomatoes, pizza dough, tomato based sauce", "Method", 20, 20, "Italian", "Europe", "Margherita Pizza", 300, 2, "https://tse4.mm.bing.net/th?id=OIP.VcalYhLe9cc0_fhlNFxE5QHaJQ&pid=Api&P=0&w=151&h=188" ); 
            
           
//             // add reviews for pizza's recipes 
//             var e10 = new Review { RecipeId = 4, Name = "Sarah", ReviewedOn = new DateTime(08/07/2022), Comment = "Very flavorful", Rating = 9 };
//             svc.AddReview(e10);
            
//             var e11 = new Review { RecipeId = 4, Name = "Bacarat", ReviewedOn = new DateTime(17/10/22), Comment = "Thank You, Very Tasty", Rating = 9 };
//             svc.AddReview(e10);

//             var e12 = new Review { RecipeId= 4, Name = "Shokod", ReviewedOn = new DateTime(24/02/21), Comment = "So delicious. I sauteed a sweet onion and garlic cloves in olive oil and added on top", Rating = 9 };
//             svc.AddReview(e12);

//             var e13 = new Review { RecipeId= 5, Name = "PLZNRC", ReviewedOn = new DateTime(20/12/2021), Comment = "Tasty!" , Rating = 8};
//             svc.AddReview(e13);

//             var e14 = new Review { RecipeId= 5, Name = "Lizanne", ReviewedOn = new DateTime(25/03/2022), Comment = "Found the flavours a little bland. Maybe some more ingredients needed. I will add more next time. Would try again. ", Rating = 6};
//             svc.AddReview(e14);

//             var e15 = new Review { RecipeId= 5, Name = "Erin", ReviewedOn = new DateTime(30/04/2022), Comment = "My husband is a vegetarian and he loved this! We added some tomatoes. Thank you!", Rating = 8};
//             svc.AddReview(e15);

//             var e16 = new Review { RecipeId= 6, Name = "Gitano", ReviewedOn = new DateTime(04/09/2021), Comment = "Added some peppers and it was Delicious", Rating = 9 };
//             svc.AddReview(e16);

//             var e17 = new Review { RecipeId= 6, Name = "Izzy", ReviewedOn = new DateTime(01/01/2021), Comment = "Easy to make, but it definitely needs a lot more flavours/ingredients!!!", Rating = 6 };
//             svc.AddReview(e17);

//             var e18 = new Review { RecipeId= 6, Name = "Cruz", ReviewedOn = new DateTime(03/09/2021), Comment = "This is great, the only thing I did differently was add the fresh basil to the tomato mixture just before serving.", Rating = 7};
//             svc.AddReview(e18);
            

//             // Register curry member
//             var u3 = svc.Register("Curry", "curry@mail.com", "curry123", Role.member, "Indian", "" );

//             // // add recipes for curry 
//             var t7 = svc.CreateRecipe(u3.Id, "Chicken Madras", Diet.Omnivorous, MealType.Dinner, "1 onion, peeled and quartered, 2 garlic cloves, thumb-sized chunk of ginger, peeled red chilli, 1 tbsp vegetable oil, 1 tsp turmeric, 1 tsp ground cumin, 1 tsp ground coriander, 1-2 tsp hot chilli powder (depending on how spicy you like your curry), 4 chicken breasts, cut into chunks,400g can chopped tomatoes, small pack coriander, chopped rice, naan and mango chutney, to serve", "Blitz 1 quartered onion, 2 garlic cloves, a thumb-sized chunk of ginger and ½ red chilli together in a food processor until it becomes a coarse paste. Heat 1 tbsp vegetable oil in a large saucepan and add the paste, fry for 5 mins, until softened. If it starts to stick to the pan at all, add a splash of water, Tip in ½ tsp turmeric, 1 tsp ground cumin, 1 tsp ground coriander and 1-2 tsp hot chilli powder and stir well, cook for a couple of mins to toast them a bit, then add 4 chicken breasts, cut into chunks. Stir and make sure everything is covered in the spice mix. Cook until the chicken begins to turn pale, adding a small splash of water if it sticks to the base of the pan at all. Pour in 400g can chopped tomatoes, along with a big pinch of salt, cover and cook on a low heat for 30 mins, until the chicken is tender. Stir through small pack of coriander and serve with rice, naan and a big dollop of mango chutney.", 30, 35,  "Indian", "India", "Ciken madrās/Kōḻi meṭrās", 373, 4, "https://tse1.mm.bing.net/th?id=OIP.ZPko7gRxk0cgNcrmqDkqxwHaLH&pid=Api&P=0" );
//             var t8 = svc.CreateRecipe(u3.Id, "Lamb Jalfrezi", Diet.Omnivorous, MealType.Dinner, "30ml (1 tbsp) ghee, 800g (2lbs) lamb shoulder, cubed, 30ml (2 tbsp) ground turmeric, 500ml (2 cups) curry base sauce, 30ml (2 tbsp) vegetable oil, 2 onions, peeled and chopped, 5 garlic cloves, peeled and crushed, 2.5cm (1in) fresh ginger, peeled and finely diced, 2 red peppers, washed and chopped, 2 green chilli peppers, peeled and finely chopped, 60ml (4 tbsp) fresh coriander stalks, washed and finely chopped, 60ml (4 tbsp) tomato puree, 2 tomatoes, washed and quartered, 10ml (2 tsp) garam masala, 60ml (4 tbsp) fresh coriander leaves, washed and chopped", "Heat the ghee in a large ovenproof casserole. Cover the lamb with turmeric and brown on all sides in the casserole. Pour in the curry base sauce, stir and cover with a lid. Simmer on a low heat until the meat is cooked and tender. In this case, it took about 90 minutes. Heat the oil in a large frying pan. Fry the onions at a high heat for 2 minutes. Add the garlic, ginger, coriander stalks, peppers and chillies. Continue to fry for another 2 minutes. Pour in the stewed lamb and all its sauce to the frying pan. Stir in the tomato puree, tomatoes and garam masala. Let the curry bubble away for 5 minutes. Serve immediately, topped with fresh coriander leaves, with your favourite Indian accompaniments. Enjoy!", 20, 90, "Indian", "India", "Gorre jalphrējī/Āṭṭukkuṭṭi jālḥprēci", 609, 4, "https://tse3.mm.bing.net/th?id=OIP.MXFjogPItv_zacF_h6qgKAAAAA&pid=Api&P=0" );
//             var t9 = svc.CreateRecipe(u3.Id, "Vegatable Rogan Josh", Diet.Vegan, MealType.Dinner, "1 pouch Basmati rice, 150g baby new potatoes, diced 150g cauliflower florets, 150g baby carrots, halved, 2 tbsps oil, 1 onion, finely chopped, 1 clove garlic, crushed, 1 thumb ginger, grated, 3 tbsps rogan josh paste, 1/2 tsp toasted black onion seeds, 200g canned chopped tomatoes, 200ml water, 100g chickpeas drained, 1 large tomato cut into quarters, Salt and black pepper to season", "", 30, 60, "Indian", "India", "Kūragāyala rōgan jōṣ/Kāykaṟi rōkaṉ jōṣ", 470, 2, "https://tse4.mm.bing.net/th?id=OIP.ac0lFXRBocYbHUG3af-njwHaKn&pid=Api&P=0" ); 

//             var e19 = new Review { RecipeId = 7, Name = "Bill", ReviewedOn= new DateTime(19/01/2020), Comment = "This is a lovely Chicken curry recipe - the balance of spices is wonderful and I imagine it would be gorgeous with naan or any kind of flatbread!", Rating = 10};
//             svc.AddReview(e19);

//             var e20 = new Review {RecipeId = 7, Name = "Frankie", ReviewedOn= new DateTime(24/02/2021), Comment = "Delicious. Well Done on a tasty recipe", Rating = 9};
//             svc.AddReview(e20);

//             var e21= new Review {RecipeId = 7, Name = "Rosette", ReviewedOn= new DateTime(09/08/20), Comment = "As good as the restaurant near my home!", Rating = 10};
//             svc.AddReview(e21);

//             var e22 = new Review {RecipeId = 8, Name = "Buster", ReviewedOn= new DateTime(15/04/2021), Comment = "The lamb is fantastic. A Must try!", Rating = 9};
//             svc.AddReview(e22);

//             var e23 = new Review {RecipeId = 8, Name = "Ali", ReviewedOn = new DateTime(07/08/21), Comment = "A little Hot for me, but still a delicious recipe. Flavours are great", Rating= 9};
//             svc.AddReview(e23);

//             var e24 = new Review {RecipeId = 8, Name = "Veron", ReviewedOn = new DateTime(28/10/2021), Comment = "Allergic to Ginger so I removed. Still great!", Rating = 8};
//             svc.AddReview(e24);

//             var e25 = new Review {RecipeId = 9, Name = "Zayete", ReviewedOn = new DateTime(28/11/2021), Comment = "Great addition of baby potatoes, bulky dish that filled all the family!", Rating = 9};
//             svc.AddReview(e25);

//             var e26 = new Review {RecipeId = 9, Name = "Melissa", ReviewedOn = new DateTime(16/10/2021), Comment = "Great Recipe. flavours are 10/10!", Rating = 10};
//             svc.AddReview(e26);

//             var e27 = new Review {RecipeId = 9, Name = "Sedate", ReviewedOn = new DateTime(28/02/2021), Comment = "Added chicken, SUPERB!!", Rating = 10};
//             svc.AddReview(e27);


//             // Register Soup Member
//             var u4 = svc.Register("Soup", "Soup@mail.com", "soup123", Role.member,  "French", "https://tse3.mm.bing.net/th?id=OIP.jFCaOstaToQH90hXktCBGAAAAA&pid=Api&P=0" );

//             var t10 = svc.CreateRecipe(u4.Id, "French Onion Soup", Diet.Vegetarian, MealType.Lunch, "50g butter, 1 tbsp olive oil, 1kg onions, halved and thinly sliced, 1 tsp sugar, 4 garlic cloves, thinly sliced, 2 tbsp plain flour, 250ml dry white wine, 1.3l hot strongly-flavoured beef stock, 4-8 slices baguette (depending on size), 140g gruyère, finely grated", "Melt the butter with the olive oil in a large heavy-based pan. Add the onions and fry with the lid on for 10 mins until soft. Sprinkle in the sugar and cook for 20 mins more, stirring frequently, until caramelised. The onions should be really golden, full of flavour and soft when pinched between your fingers. Take care towards the end to ensure that they don’t burn. Add the garlic cloves for the final few minutes of the onions’ cooking time, then sprinkle in the plain flour and stir well. Increase the heat and keep stirring as you gradually add the wine, followed by the beef stock. Cover and simmer for 15-20 mins. To serve, turn on the grill, and toast the bread. Ladle the soup into heatproof bowls. Put a slice or two of toast on top of the bowls of soup, and pile on the gruyère. Grill until melted. Alternatively, you can cook the toasts under the grill, then add them to the soup to serve.", 15, 55, "French", "France", "Soupe à l'oignon", 618, 4, "https://tse1.mm.bing.net/th?id=OIP.TKCLor3jzONVXqWzwoj8RwHaHa&pid=Api&P=0");   
//             var t11 = svc.CreateRecipe(u4.Id, "French Garlic Soup", Diet.Omnivorous, MealType.Lunch, "1 litre or 2 pints of chicken stock, 8 cloves of garlic, minced, 75g or 3oz of duck fat, 2 eggs, separated, 1 bouquet garni, salt & pepper, 4 slices of stale bread toasted, 75g or 3oz of grated cheese", "Bring the stock to the boil, fry the garlic in the duck fat, then add to the stock, add the bouquet garni and simmer for 20 mins, remove the bouquet garni, beat the egg whites lightly and add to the soup, as soon as they have set remove from the heat, whisk some of the soup with the egg yolks a bit at a time, then pour into the rest of the soup, add salt and pepper to taste, put a slice of the stale, toasted bread in the bottom of the bowl, cover with grated cheese, pour on the soup, cut the egg whites into pieces if you like", 5, 30, "French", "France", "Soupe a l'ail", 590, 4, "https://tse1.mm.bing.net/th?id=OIP.zfyEeS6Rc61zwNNjHsHn_AHaE8&pid=Api&P=0");
//             var t12 = svc.CreateRecipe(u4.Id, "French Tomato Soup", Diet.Vegetarian, MealType.Lunch, "1 tablespoon butter, 1 large onion, chopped, 6 tomatoes, peeled and quartered, 1 large potato, peeled and quartered, 6 cups water, 1 bay leaf, 1 clove garlic, pressed, 1 teaspoon salt, ½ cup long-grain rice", "Melt butter in a large saucepan over medium heat. Saute onions in butter until tender and lightly browned, about 10 minutes. Add tomatoes, and continue cooking for 10 more minutes, stirring frequently. Add the potato, and 2 cups of water. Season with the bay leaf, garlic and salt. Bring to a boil, then reduce heat and simmer, covered, for about 20 minutes. Stir in the remaining water, and bring to a boil again. Discard bay leaf, and strain the solids from the broth, reserving both. Puree the vegetables in a food processor or blender, and stir them back into the broth. Bring to a boil, and add the rice. Cover and simmer over low heat for about 15 minutes, or until rice is tender. Serve hot", 20,75, "French", "France", "Soupe à la tomate française", 390, 6, "https://tse3.mm.bing.net/th?id=OIP.5kJBrHHS84Lc5rOWufhfpAHaLH&pid=Api&P=0");
            
//             var e28 = new Review {RecipeId = 10, Name = "Paula", ReviewedOn = new DateTime(08/02/2021), Comment = "Soup was very watery, would not rate. Recipe followed excately", Rating = 4};
//             svc.AddReview(e28);

//             var e29 = new Review {RecipeId = 10, Name = "Rachael", ReviewedOn = new DateTime(19/07/2021), Comment = "A nice recipe but could be improved a lot", Rating = 5};
//             svc.AddReview(e29);

//             var e30 = new Review {RecipeId = 10, Name = "Brigette", ReviewedOn = new DateTime(11/11/2021), Comment = "A little bland, I made a few little improvements and it turned out ok", Rating = 5};
//             svc.AddReview(e30);

//             var e31 = new Review {RecipeId = 11, Name = "Annette", ReviewedOn = new DateTime(27/12/2021), Comment = "Soup was Great!! Highly Recommend", Rating = 8};
//             svc.AddReview(e31);

//             var e32 = new Review {RecipeId = 11, Name = "Audrey", ReviewedOn = new DateTime(15/05/2021), Comment = "Velvety Smooth and full of Flavour", Rating = 10};
//             svc.AddReview(e32);

//             var e33 = new Review {RecipeId = 11, Name = "Albert", ReviewedOn = new DateTime(18/09/2021), Comment = "Bowl of Comfort. Thank You!", Rating = 9};
//             svc.AddReview(e33);

//             var e34 = new Review {RecipeId = 12, Name = "Alan", ReviewedOn = new DateTime(13/01/2020), Comment = "Bland Recipe - Added a lot of my own ingredients to avoid dumping", Rating = 3};
//             svc.AddReview(e34);

//             var e35 = new Review {RecipeId = 12, Name = "Chloe", ReviewedOn = new DateTime(03/05/2021), Comment = "Soup was very watery, would not rate. Recipe followed excately", Rating = 5};
//             svc.AddReview(e35);

//             var e36 = new Review {RecipeId = 12, Name = "Gabriel", ReviewedOn = new DateTime(11/11/2021), Comment = "Throughly enjoyed. Thank you!", Rating = 8};
//             svc.AddReview(e36);

//             // Register Thai Member
//             var u5 = svc.Register("Thai", "thai@mail.com", "thai123", Role.member, "Ethnic Thai" , "https://tse2.mm.bing.net/th?id=OIP.TN83udI5uc5Gvhvc8gSyoAHaLd&pid=Api&P=0" );
            
//             var t13 = svc.CreateRecipe(u5.Id, "Spicy Garlic and Pepper Shrimp", Diet.Omnivorous, MealType.Dinner, "2.5 tablespoons vegetable oil, quater cup water, 1 cup shredded cabbage, 1 tablespoon minced garlic, 8 large fresh shrimp, peeled and deveined, 2 teaspoons crushed red pepper flakes, 2 tablespoons sliced onion, 1 tablespoon chopped fresh cilantro, 1 tablespoon soy sauce", "Heat 1 tablespoon oil in a skillet over high heat. Add cabbage and 1 tablespoon water stir-fry for 30 seconds. Remove cabbage from skillet and place on a serving platter. Heat the remaining 1 1/2 tablespoons oil in the skillet over high heat. Place the garlic and shrimp in the skillet and stir until garlic is lightly browned and shrimp turns pink. Add pepper, onion, cilantro, soy sauce and remaining water to the skillet. Stir-fry for 10 seconds. Pour the hot mixture onto the cabbage.", 25, 10, "Thai", "Southeast Asia", "P̄hĕd kratheīym phrikthịy kûng", 460, 1, "https://tse2.mm.bing.net/th?id=OIP.GrG7iZLhsHcGoFazsbJpyAHaLH&pid=Api&P=0");
//             var t14 = svc.CreateRecipe(u5.Id, "Thai Mango Salad with Peanut Dressing", Diet.Vegetarian, MealType.Lunch, "One head (about 7 ounces) butter leaf lettuce or your greens of choice, chopped into bite-sized pieces, 1 red bell pepper, thinly sliced and then sliced across to make 1″ long pieces, 3 ripe champagne mangos, diced, ½ cup thinly sliced green onion (both green and white parts), ⅓ cup chopped roasted peanuts, ¼ cup chopped fresh cilantro, 1 medium jalapeño, seeds and membranes removed, finely chopped, Peanut dressing, ¼ cup creamy peanut butter, ¼ cup lime juice (about 2 to 3 limes), 1 tablespoon tamari or soy sauce, 1 tablespoon apple cider vinegar, 1 tablespoon honey or maple syrup, 1 teaspoon sesame oil, 2 cloves garlic, pressed or minced, Pinch of red pepper flakes (if you like spice)", "To assemble the salad, simply combine all of the salad ingredients in a large serving bowl. To prepare the dressing, combine all of the ingredients in a liquid measuring cup or bowl, and whisk until combined. When you’re ready to serve, drizzle the dressing over the salad, and toss to combine. Serve immediately", 20, 0, "Thai", "Southeast Asia", "Yả mam̀wng n̂ả s̄lạd t̄hạ̀w lis̄ng", 377, 4, "https://tse1.mm.bing.net/th?id=OIP.uJu-r9jm6XbmIbCDsgk58QHaLH&pid=Api&P=0");
//             var t15 = svc.CreateRecipe(u5.Id, "Easy Thai Chicken", Diet.Omnivorous, MealType.Dinner, "2 tablespoons unsalted butter, 8 bone-in, skin-on chicken thighs, 1/4 cup peanuts, chopped, 2 tablespoons chopped fresh cilantro leaves, 1/2 cup sweet chili sauce, 2 tablespoons reduced sodium soy sauce, 2 cloves garlic, minced, 1 tablespoon fish sauce, 1 tablespoon freshly grated ginger, Juice of 1 lime, 1 teaspoon Sriracha, or more, to taste", "Preheat oven to 400 degrees F. To make the sauce, whisk together chili sauce, soy sauce, garlic, fish sauce, ginger, lime juice and Sriracha in a small bowl; set aside. Melt butter in a large oven-proof skillet over medium high heat. Add chicken, skin-side down, and sear both sides until golden brown, about 2-3 minutes per side. Stir in chili sauce mixture. Place into oven and roast until completely cooked through, reaching an internal temperature of 165 degrees F, about 25-30 minutes. Then broil for 2-3 minutes, or until caramelized and slightly charred. Serve immediately, garnished with peanuts and cilantro, if desired", 10, 30, "Thai", "Southeast Asia", "Kị̀ thịy ng̀āy", 252, 8, "https://tse3.mm.bing.net/th?id=OIP.HFSuCjlgpXhyvpm7gKTNowHaLH&pid=Api&P=0");

//             var e37 = new Review {RecipeId = 13, Name = "Achara", ReviewedOn = new DateTime(01/12/2021), Comment = "This is one of my favorite recipes I have found online. Smashing!!", Rating = 10};
//             svc.AddReview(e37);

//             var e38 = new Review {RecipeId = 13, Name = "Lisa", ReviewedOn = new DateTime(19/01/2021), Comment = "Awesome, My husband and I love this.", Rating = 10};
//             svc.AddReview(e38);

//             var e39 = new Review {RecipeId = 13, Name = "Monique", ReviewedOn = new DateTime(11/09/2021), Comment = "LOVED this one! It was spicy and delicious!!!", Rating = 10};
//             svc.AddReview(e39);

//             var e40 = new Review {RecipeId = 14, Name = "Matthew", ReviewedOn = new DateTime(13/05/2022), Comment = "Beautiful salad!! Love the combo of sweet and spicy flavors!!!", Rating = 8};
//             svc.AddReview(e40);

//             var e41 = new Review {RecipeId = 14, Name = "James", ReviewedOn = new DateTime(17/10/2020), Comment = "Perfect on a hot day. Will continue to make for a long time", Rating = 9};
//             svc.AddReview(e41);

//             var e42 = new Review {RecipeId = 14, Name = "Linda", ReviewedOn = new DateTime(19/11/2021), Comment = "Enjoyed by the whole family. Thank you!", Rating = 9};
//             svc.AddReview(e42);

//             var e43= new Review {RecipeId = 15, Name = "Fern", ReviewedOn = new DateTime(02/09/2020), Comment = "Really Good - quick and easy", Rating = 8};
//             svc.AddReview(e43);

//             var e44= new Review {RecipeId = 15, Name = "Chai", ReviewedOn = new DateTime(11/10/2021), Comment = "Throughly enjoyed. Thank you!", Rating = 8};
//             svc.AddReview(e44);

//             var e45 = new Review {RecipeId = 15, Name = "Kannika", ReviewedOn = new DateTime(17/11/2021), Comment = "Fabulous! I used skinless thighs and it turned out great!", Rating = 9};
//             svc.AddReview(e45);

//             // Register Stock Member
//             var u6 = svc.Register("Stock", "stock@mail.com", "stock123", Role.member,  "Irish" ,"" );

//             var t16 = svc.CreateRecipe(u6.Id, "Slow cooker honey mustard chicken", Diet.Omnivorous, MealType.Dinner, "1 tsp sunflower, vegetable or light olive oil, 6–8 chicken thighs, with skin and bone-in,300ml/10fl oz hot chicken stock, made with 1 stock cube, 2 tbsp mustard, English, wholegrain or a combination,2 tbsp runny honey, ½ tsp dried mixed herbs, 4 tbsp double cream, 1 tbsp cornflour mixed with 1 tbsp cold water, salt and freshly ground black pepper", "Heat the oil in a large non-stick frying pan over a medium-high heat. Season the chicken thighs on all sides with salt and freshly ground black pepper. Fry the chicken thighs, skin-side down, for 3–5 minutes or until crisp and golden. Turn and cook on the other side for 2 minutes. Frying the chicken will give it a lovely colour and render out some of the fat that sits just below the skin, but take care as it can spit a little as it fries. While the chicken is frying, pour the stock into the slow cooker and stir in the mustard, honey and herbs until thoroughly mixed. Add the chicken pieces to the slow cooker, skin-side up, cover and cook on high for 3–4 hours. Once the chicken is cooked, gently stir in the cream and cornflour mixture, cover and cook for a further 10 minutes or until the sauce thickens. (If your chicken releases lots of fat into the pot, you may want to spoon a little off before adding the cream.), Serve the chicken hot with the sauce and lots of freshly cooked vegetables, with potatoes or rice on the side.", 30, 120, "Traditional English", "Britain", "", 600, 4, "https://tse3.mm.bing.net/th?id=OIP.SLTDY8MBsTOd7jdQ2KRCegHaLJ&pid=Api&P=0");
//             var t17 = svc.CreateRecipe(u6.Id, "Hainanese Chicken Rice", Diet.Omnivorous, MealType.Dinner, "1 (3-1/2 pound) whole chicken, preferably free-range, Rock salt, for cleaning, 1/2 cup rice wine, 4 quarts chicken broth, 2 shallots, peeled and halved, 4 garlic cloves, smashed, 1-inch ginger root, scrubbed, 1 stalk lemongrass, white portion only, lightly pounded, 6 whole peppercorns, Salt, to taste, 3 cups chicken broth (reserved from poaching chicken), 2 cups long-grain rice, 2 tablespoons grated ginger, 2 tablespoons finely chopped scallions, 4 tablespoons peanut oil", "Rub the chicken all over with rock salt to remove impurities. Do this two to three times until you see that the skin is clean. Place the chicken in a pot deep enough to allow the chicken to be submerged in the cooking liquid. Pour in the rice wine and enough chicken broth so that there is at least an inch of liquid above the chicken. Bring to a boil, skimming off any scum that rises; then lower the heat so that the liquid is barely simmering. Add the shallots, garlic, ginger, lemongrass, peppercorns, and salt, if the broth is unsalted. Cover the pot and let the chicken poach—about 45 minutes. When the poaching time is finished, turn off the heat but leave the chicken in the pot, still covered, for another 10 minutes. strain the broth and measure 3 cups broth to cook the rice in. Let the broth cool. In a medium to large pot, add the cold broth to the rice and bring the mixture to a boil. Mix together the grated ginger, chopped scallions, peanut oil, and enough salt to taste.Cut the Chicken and Serve", 25, 80, "Singaporean", "Southeast Asia", "Nasi Ayam Hainan", 550, 4, "https://tse1.mm.bing.net/th?id=OIP.5dMeTaEAxcIaJZ6eRZGcOgHaIr&pid=Api&P=0");
//             var t18 = svc.CreateRecipe(u6.Id, "Shrimp Risotto", Diet.Omnivorous, MealType.Dinner, "3 tablespoons olive oil, 1 pound extra jumbo (16 to 20) shrimp, peeled and deveined, 1 teaspoon salt, 1/2 teaspoon freshly ground black pepper, 5 ounces (10 tablespoons) unsalted butter, divided, 6 cloves garlic, minced, 1 1/2 cups white wine, 1 1/2 tablespoons lemon juice, 2 tablespoons finely chopped parsley, 3 cups chicken stock, 2 tablespoons olive oil, 4 tablespoons unsalted butter, divided, 2 small shallots, minced, 3 clove garlic, minced, 1 cup Arborio rice, 1/2 cup shredded Parmesan cheese", "Sear the shrimp to golden brown on both sides. Remove the shrimp from the heat, Turn the heat to medium-low. Add 2 tablespoons of the butter to the pan and add the minced garlic. Sauté until fragrant, about 1 minute. Add the white wine and lemon juice to deglaze the pan. Allow the sauce to reduce by about a third. Whisk in the remaining butter and the parsley. Heat the olive oil and 2 tablespoons of the butter in the large skillet. Once the butter has melted, add the shallots and garlic. Add the Arborio rice and toss to coat in the oil and butter. Sauté until the rice is very lightly browned. Add a ladleful of the hot stock and stir until the stock is absorbed, repeat. Serve immediately", 30, 45, "Italian", "Italy", "Risotto ai gamberi", 450, 4, "https://tse4.mm.bing.net/th?id=OIP.BdFSK8nvF94Ja7GNydzISQHaLH&pid=Api&P=0");

//             var e46 = new Review {RecipeId = 16, Name = "Carlos", ReviewedOn = new DateTime(17/11/2021), Comment = "10/10 - would recommend", Rating = 10};
//             svc.AddReview(e46);

//             var e47 = new Review {RecipeId = 16, Name = "Kenny", ReviewedOn = new DateTime(19/11/2021), Comment = "The chicken was so tender. Sauce was great!", Rating = 9};
//             svc.AddReview(e47);

//             var e48 = new Review {RecipeId = 16, Name = "Coleen", ReviewedOn = new DateTime(12/12/2021), Comment = "What a fantastic recipe. Everyone loved it! ", Rating = 10};
//             svc.AddReview(e48);

//             var e49 = new Review {RecipeId = 17, Name = "Phyliss", ReviewedOn = new DateTime(07/01/2021), Comment = "A great asian dish!! Thank You!", Rating = 9};
//             svc.AddReview(e49);

//             var e50 = new Review {RecipeId = 17, Name = "Brenda", ReviewedOn = new DateTime(17/-4/2021), Comment = "I enjoyed it. Other family members found chicken a little dry", Rating = 8};
//             svc.AddReview(e50);

//             var e51 = new Review {RecipeId = 17, Name = "James", ReviewedOn = new DateTime(09/12/2021), Comment = "Tasty!!!!", Rating = 8};
//             svc.AddReview(e51);

//             var e52 = new Review {RecipeId = 18, Name = "Aisling", ReviewedOn = new DateTime(16/03/2021), Comment = "A great recipe. Risotto is tricky to make but turned out great", Rating = 9};
//             svc.AddReview(e52);

//             var e53 = new Review {RecipeId = 18, Name = "Majella", ReviewedOn = new DateTime(17/03/2021), Comment = "Struggled a little with risotto consistency although tasted good", Rating = 6};
//             svc.AddReview(e53);

//             var e54 = new Review {RecipeId = 18, Name = "Isobel", ReviewedOn = new DateTime(07/01/2021), Comment = "Fabulous!", Rating = 9};
//             svc.AddReview(e54);





//             // Register Balsamic Member 
//             var u7 = svc.Register("balsamic", "balsamic@mail.com", "balsamic123", Role.member, "French", "" );


//             var u8 = svc.Register("Taco", "taco@mail.com", "taco123", Role.member, "Mexician", "" );
//             var u9 = svc.Register("Breadstick", "breadstick@mail.com", "breadstick123", Role.member,  "French", "" );
//             var u10 = svc.Register("Hummus", "hummus@mail.com", "hummus123", Role.member,  "Morrocan", "" );
//             var u11 = svc.Register("Pepperoni", "pepperoni@mail.com", "pepperoni123", Role.member, "Italian", "" );
//             var u12 = svc.Register("Burger", "burger@mail.com", "burger123", Role.member,  "American", "");
//             var u13 = svc.Register("Hotdog", "hotdog@mail.com", "hotdog123", Role.member,  "American" , "" );
//             var u14 = svc.Register("Spaghetti", "spaghetti@mail.com", "spaghetti123", Role.member,  "Italian", "" );
//             var u15 = svc.Register("Seabass", "seabass@mail.com", "seabass123", Role.member, "Spanish", "" );
//             var u16 = svc.Register("Chicken", "chicken@mail.com", "chicken123", Role.member, "Scottish", "" );
//             var u17 = svc.Register("Beef", "beef@mail.com", "beef123", Role.member, "Portuguese", "");
//             var u18 = svc.Register("Fish", "fish@mail.com", "fish123", Role.member, "Greek", "" );
//             var u19 = svc.Register("Pepper", "pepper@mail.com", "pepper123", Role.member, "German", "" );
//             var u20 = svc.Register("Onion", "onion@mail.com", "onion123", Role.member, "English", "" );
           
//             //Register an administrator 
//             var u21 = svc.Register("Admin", "admin@mail.com", "admin", Role.admin, "Spanish", "");
            
            
            


          
            
//             // // add recipes for curry
//             // var t5 = svc.CreateTicket(s3.Id, "No internet connection");
//             // var t6 = svc.CreateTicket(s3.Id, "Internet not working.");
        
  

//         }
//     }
// }
