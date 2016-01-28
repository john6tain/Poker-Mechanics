using System;
using System.Drawing;
using System.Windows.Forms;
using Poker.Enumerations;
using Poker.Interfacees;

namespace Poker.Table
{
    public class Card : ICard
    {
        private CardRank rank;
        private bool isVisible;
        private string backCardPath;
        private Image frontImage;
        private Image backImage;
        private CardSuit suit;
        private PictureBox cardPictureBox;

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

        public bool IsVisible { get { return isVisible; } set { this.isVisible = value; } }
        private string BackCardPath { get { return this.backCardPath; }set { this.backCardPath = value; } }
        public Image FrontImage { get { return this.frontImage; } private set { this.frontImage = value; } }
        public Image BackImage { get { return this.backImage; } private set { this.backImage = value; } }
        public CardSuit Suit { get { return this.suit; } private set { this.suit = value; } }

        public CardRank Rank
        {
            get { return rank; }
            set
            {
                if (value != null)
                {
                    this.rank = value;
                }
                else
                {
                    //TODO : need Cumstom Exeption
                    throw new ArgumentException("It's null Man");
                }
            }

        }
        public PictureBox CardPictureBox
        {
            get { return cardPictureBox; }
            set
            {
                if (value != null)
                {
                    this.cardPictureBox = value;
                }
                else
                {
                    //TODO : need Cumstom Exeption
                    throw new ArgumentException("It's null Man");
                }
            }

        }

        public void Update(Control.ControlCollection controls)
        {
            if (this.IsVisible)
            {
                this.CardPictureBox.Image = this.FrontImage;
            }
            else
            {
                this.CardPictureBox.Image = this.BackImage;
            }

            controls.Add(this.CardPictureBox);
        }
    }
}