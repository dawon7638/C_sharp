using System;

namespace hungry_ninja
{
    class Program
    {
        static void Main(string[] args)
        {

            Ninja Dawon = new Ninja();
            Buffet OldCountry = new Buffet();


            while (Dawon.IsFull == false)
            {
                Dawon.Eat(OldCountry.Serve());
            }
            if (Dawon.IsFull)
            {
                Console.WriteLine("I'm stuffed!");
            }

        }
    }
}
