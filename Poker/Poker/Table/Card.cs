using System.Drawing;
using System.Windows.Forms;
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

        public Card(CardSuit suit, CardRank rank, Image frontImage) : this(suit, rank)
        {
            this.FrontImage = frontImage;
            //Can we make it to private readonly or const?
            this.BackCardPath = "..\\..\\Resources\\Cards\\Back.png";
            this.BackImage = Image.FromFile(BackCardPath);
            this.CardPictureBox = new PictureBox();
        }

        public bool IsVisible { get; set; }
        private string BackCardPath { get; }
        public Image FrontImage { get; }
        public Image BackImage { get; }
        public CardSuit Suit { get; }
        public CardRank Rank { get; set; }
        public PictureBox CardPictureBox { get; set; }
    }
}