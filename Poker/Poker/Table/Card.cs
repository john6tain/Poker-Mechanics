using System.Drawing;
using Poker.Enumerations;
using Poker.Interfacees;

namespace Poker.Table
{
    public class Card:ICard
    {
        public Card(CardSuit suit, CardRank rank, Image frontImage)
        {
            this.Suit = suit;
            this.Rank = rank;
            this.FrontImage = frontImage;
            //Can we make it to private readonly or const?
            this.BackCardPath = "..\\..\\Resources\\Cards\\Back.png";
            this.BackImage = Image.FromFile(BackCardPath);
        }

        public bool IsVisible { get; set; }
        private string BackCardPath { get; }
        public Image FrontImage { get; }
        public Image BackImage { get; }
        public CardSuit Suit { get; }
        public CardRank Rank { get; }
    }
}