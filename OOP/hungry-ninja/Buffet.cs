using System;
using System.Collections.Generic;

namespace hungry_ninja
{
    public class Buffet
    {
        public List<Food> menu;

        //  [x] add a constructor and set Menu to a hard coded list of 7 or more Food objects you instantiate manually
        public Buffet() //constructor
        {
            menu = new List<Food>()
            {
                new Food("Sushi",50,true,false),
                new Food("Pizza",100,false,false),
                new Food("Pasta",150,false,false),
                new Food("Chocolate Cake",90,false,true),
                new Food("Popcorn",60,false,false),
                new Food("Jelly Beans",30,false,true),
                new Food("Chili",80,true,false),
            };
        }
        //  [x] build out a Serve method that randomly selects a Food object from the Menu list and returns the Food object
        public Food Serve()
        {
            Random foodItem = new Random();
            int currentFoodItem = foodItem.Next(0, 7);
            return menu[currentFoodItem];
        }
    }
}