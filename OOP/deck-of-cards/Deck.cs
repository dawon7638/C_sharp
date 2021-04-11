using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    public class Deck
    {

        // Create a class called "Deck"

        // [x]  Give the Deck class a property called "cards" which is a list of Card objects.
        public List<Card> Cards { get; set; } = new List<Card>();

        // [x]  When initializing the deck, make sure that it has a list of 52 unique cards as its "cards" property.
        public Deck()
        {
            Reset();
        }
        // []  Give the Deck a reset method that resets the cards property to contain the original 52 cards.
        public void Reset()
        {
            Cards = new List<Card>();
            string[] suits = new string[4]
        {
            "Hearts",
            "Diamonds",
            "Clubs",
            "Spades"
        };

            Dictionary<int, string> cardNamesTable = new Dictionary<int, string>()
            {
                {1 ,"Ace"},
                {11 ,"Jack"},
                {12 ,"Queen"},
                {13 ,"King"}
            };

            foreach (string suit in suits)
            {
                for (int i = 1; i < 14; i++)
                {
                    string cardName = i.ToString();
                    if (cardNamesTable.ContainsKey(i))
                    {// Retrieve the card name from the dict.
                        cardName = cardNamesTable[i];
                    }
                    Card currentCard = new Card(cardName, suit, i);

                    Cards.Add(currentCard);
                }
            }
        }

        // [x]  Give the Deck a deal method that selects the "top-most" card, removes it from the list of cards, and returns the Card.
        public Card Deal()
        {
            if (Cards.Count == 0)
            {
                return null;
            }
            Card firstCard = Cards[0];
            Cards.RemoveAt(0);
            return firstCard;
        }

        // [x]  Give the Deck a shuffle method that randomly reorders the deck's cards.
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int randIdx = rand.Next(0, Cards.Count);
                Card temp = Cards[i];
                Cards[i] = Cards[randIdx];
                Cards[randIdx] = temp;
            }
        }
        public override string ToString()
        {
            string deckStr = "";
            foreach (Card card in Cards)
            {
                deckStr += "\n" + card;
            }
            return deckStr;
        }



    }
}