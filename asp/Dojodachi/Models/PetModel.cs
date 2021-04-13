namespace Dojodachi.Models
{
    public class PetModel
    {

        public int Fullness { get; set; }
        public int Happiness { get; set; }
        public int Meals { get; set; }
        public int Energy { get; set; }
        //[x] Your Dojodachi should start with 20 happiness, 20 fullness, 50 energy, and 3 meals.

        public PetModel()
        {
            Fullness = 20;
            Happiness = 20;
            Meals = 3;
            Energy = 50;

        }


    }
}