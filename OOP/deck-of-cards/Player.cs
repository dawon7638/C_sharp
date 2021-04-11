using System.Collections.Generic;

namespace deck_of_cards
{
    public class Player
    {

        //  Create a class called "Player"

        //  [x]  Give the Player class a name property.
        public string Name { get; set; }

        //  [x]  Give the Player a hand property that is a List of type Card.
        public List<Card> Hand { get; set; } = new List<Card>();

        //  [x]  Note this method will require reference to a deck object
        //  [x]  Give the Player a draw method of which draws a card from a deck, adds it to the player's hand and returns the Card.
        public Card Draw(Deck deck)
        {
            Card dealtCard = deck.Deal();
            if (dealtCard != null)
            {
                Hand.Add(dealtCard);

            }
            return dealtCard;
        }
        //  []  Give the Player a discard method which discards the Card at the specified index from the player's hand and returns this Card or null if the index does not exist.
        public Card Discard(int card)
        {
            if (Hand[card] != null)
            {
                Card toDiscard = Hand[card];
                Hand.Remove(toDiscard);
                return toDiscard;
            }
            return null;
        }




    }
}