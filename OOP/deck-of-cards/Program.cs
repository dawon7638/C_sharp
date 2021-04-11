using System;

namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            myDeck.Shuffle();
            Console.WriteLine(myDeck);
            

        }
    }
}
