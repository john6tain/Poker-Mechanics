using Poker.Enumerations;
using Poker.Interfacees;

namespace Poker.Table
{
    public class Card:ICard
    {
        public Card(CardSuit suit, CardRank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public bool isVisible { get; set; }
        public CardSuit Suit { get; set; }
        public CardRank Rank { get; set; }
    }
}