namespace deck_of_cards
{
    public class Card
    {

        // Create a class called "Card"

        // [x] Give the Card class a property "stringVal" which will hold the value of the card ex. (Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King). This "val" should be a string.
        public string Name { get; set; }

        // [x] Give the Card a property "suit" which will hold the suit of the card(Clubs, Spades, Hearts, Diamonds).
        public string Suit { get; set; }

        // [x] Give the Card a property "val" which will hold the numerical value of the card 1-13 as integers.
        public int Val { get; set; }

        //Whenever creating a new constructor, the default empty constructor gets overwritten and must be added if you want to be able to create an empty instance: new Card()
        public Card() { }
        public Card(string name, string suit, int val)// card constructor
        {
            Name = name;
            Suit = suit;
            Val = val;
        }

        public override string ToString()
        {
            return $"{Name} of {Suit}";
        }

    }
}