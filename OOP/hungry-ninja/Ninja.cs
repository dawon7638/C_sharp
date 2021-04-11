using System;
using System.Collections.Generic;

namespace hungry_ninja
{
    public class Ninja

    {
        //Properties
        private int calorieIntake;
        public List<Food> FoodHistory;

        /*  
        add a constructor
        
        [x] add a constructor that sets calorieIntake to 0 and creates a new, empty list of Food objects to FoodHistory 
        */
        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }

        /*
        add a public "getter" property called "IsFull"

        [x] add a public "getter" property called "IsFull" that returns a boolean based on if the Ninja's calorie intake is greater than 1200 calories
        */
        public bool IsFull
        {
            get
            {
                if (this.calorieIntake > 1200)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /*
        build out the Eat method

        [x] build out the Eat method that: if the Ninja is NOT full
            [x] adds calorie value to ninja's total calorieIntake
            [x] adds the randomly selected Food object to ninja's FoodHistory list
            [x] writes the Food's Name - and if it is spicy/sweet to the console

        if the Ninja IS full
            [x] issues a warning to the console that the ninja is full and cannot eat anymore

        */
        public void Eat(Food item)
        {

            calorieIntake += item.Calories;
            FoodHistory.Add(item);

            if (item.IsSpicy == true)
            {
                Console.WriteLine($"This {item.Name} was scorching!");
            }
            if (item.IsSweet == true)
            {
                Console.WriteLine($"This {item.Name} was sweet!");
            }
            else
            {
                Console.WriteLine($"This {item.Name} was ok");
            }

        }


    }
}

