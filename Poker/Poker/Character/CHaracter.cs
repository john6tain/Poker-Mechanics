// ***********************************************************************
// Assembly         : Poker
// Class Author     : Alex
//
// Last Modified By : Alex
// Last Modified On : 28 Jan 2016
// ***********************************************************************
// <copyright file="Character.cs" team="Currant">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************


using Poker.CustomException;

namespace Poker.Character
{
    using Interfacees;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Table;

    public abstract class Character : ICharacter
    {

        private readonly Panel playerPanel = new Panel();
        private readonly Panel firstBotPanel = new Panel();
        private readonly Panel secondBotPanel = new Panel();
        private readonly Panel thirdBotPanel = new Panel();
        private readonly Panel fourthBotPanel = new Panel();
        private readonly Panel fifthBotPanel = new Panel();
        private readonly List<int> playerChips = new List<int>();
        private readonly List<bool?> characterTurn = new List<bool?>();

        private int chips;
        private string name;
        private bool hasFolded;
        private bool isOnTurn;
        private ICombination cardsCombination;
        private IList<ICard> characterCardsCollection;
        private Point firstCardLocation;
        private Point secondCardLocation;

        protected Character(Point firstCardLocation, int cardWidth)
        {
            this.CharacterCardsCollection = new List<ICard>();
            this.FirstCardLocation = firstCardLocation;
            this.SecondCardLocation = GetSecondCardLocation(firstCardLocation, cardWidth);
            this.Name = "neshto";
            this.ChipsLabel = new Label();
            this.ChipsLabel.Text = "none";
            this.ChipsLabel.Location = GetChipsLabelLocation(firstCardLocation, cardWidth);
        }


        public Label StatusLabel { get; set; }
        public Label ChipsLabel { get; set; }


        public int Chips
        {
            get { return this.chips; }
            set
            {
                if (value < 0)
                {
                    throw new ChipsOutOfRangeException("Chips cannot be negative!");
                }
                if (value > int.MaxValue)
                {
                    this.chips = int.MaxValue;
                }
                this.chips = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Character name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public bool HasFolded
        {
            get { return this.hasFolded; }
            set { this.hasFolded = value; }
        }

        public bool IsOnTurn
        {
            get { return this.isOnTurn; }
            set { this.isOnTurn = value; }
        }

        public ICombination CardsCombination
        {
            get { return this.cardsCombination; }
            set { this.cardsCombination = value; }
        }

        public IList<ICard> CharacterCardsCollection
        {
            get { return this.characterCardsCollection; }
            set { this.characterCardsCollection = value; }
        }

        public Point FirstCardLocation
        {
            get { return this.firstCardLocation; }
            set
            {
                if (value == null)
                {
                    throw new FirstCardLocationException("First Card Location of Character cannot be null");
                }
                if (value.X < 0 || value.Y < 0)
                {
                    throw new FirstCardLocationException("First Card Coordinates of Character cannot be negative");
                }
                this.firstCardLocation = value;
            }
        }

        public Point SecondCardLocation
        {
            get { return this.secondCardLocation; }
            set
            {
                if (value == null)
                {
                    throw new FirstCardLocationException("Second Card Location of Character cannot be null");
                }
                if (value.X < 0 || value.Y < 0)
                {
                    throw new FirstCardLocationException("Second Card Coordinates of Character cannot be negative");
                }
                this.secondCardLocation = value;
            }
        }

        private void UpdateChipsLabels(TextBox searchedTextBox)
        {
            searchedTextBox.Text = this.Chips.ToString();
        }

        private void UpdateStatus(string statusText)
        {
            this.StatusLabel.Text = statusText;
        }

        public void Update(TextBox searchedTextBox)
        {
            UpdateChipsLabels(searchedTextBox);
        }

        private Point GetChipsLabelLocation(Point firstCardLocation, int cardWidth)
        {
            int labelX = firstCardLocation.X + (cardWidth / 2);
            int labelY = firstCardLocation.Y + 150;

            return new Point(labelX, labelY);
        }

        public abstract void Decide(ICharacter character, IList<ICard> cardCollection,
                                    int firstCard, int secondCard, int botChips,
                                    bool isFinalTurn, Label hasFolded, int botIndex,
                                    double botPower, double behaviourPower, int callSum);



        /// <summary>
        /// All characters can call an AllIn to play all the money they got
        /// </summary>
        /// <returns></returns>
        public async Task AllIn(TextBox potChips)
        {
            bool isWinning = false;
            Label playerStatus = new Label();
            if (this.Chips <= 0 && !isWinning)
            {
                if (playerStatus.Text.Contains("Raise") && playerStatus.Text.Contains("Call"))
                {
                    playerChips.Add(Chips);
                }
            }

            int firstBotChips = 10000;
            bool botOneFirstTurn = false;
            if (firstBotChips <= 0 && !botOneFirstTurn)
            {
                if (!isWinning)
                {
                    playerChips.Add(firstBotChips);
                }
            }

            int secondBotChips = 10000;
            bool botTwoTurn = false;
            if (secondBotChips <= 0 && !botTwoTurn)
            {
                if (!isWinning)
                {
                    playerChips.Add(secondBotChips);
                }
            }

            int thirdBotChips = 10000;
            bool botThreeFirstTurn = false;
            if (thirdBotChips <= 0 && !botThreeFirstTurn)
            {
                if (!isWinning)
                {
                    playerChips.Add(thirdBotChips);
                }
            }

            int fourthBotChips = 10000;
            bool botFourFirstTurn = false;
            if (fourthBotChips <= 0 && !botFourFirstTurn)
            {
                if (!isWinning)
                {
                    playerChips.Add(fourthBotChips);
                }
            }

            int fifthBotChips = 10000;
            bool botFiveFirstTurn = false;
            if (fifthBotChips <= 0 && !botFiveFirstTurn)
            {
                if (!isWinning)
                {
                    playerChips.Add(fifthBotChips);
                }
            }

            int maxLeft = 6;
            if (playerChips.ToArray().Length == maxLeft)
            {
                await Dealer.Finish(2);
            }
            else
            {
                playerChips.Clear();
            }

            var winner = characterTurn.Count(x => x == false);
            if (winner == 1)
            {
                var index = characterTurn.IndexOf(false);
                TextBox tableChips = new TextBox();
                if (index == 0)
                {
                    Chips += int.Parse(potChips.Text);
                    tableChips.Text = this.Chips.ToString();
                    playerPanel.Visible = true;
                    MessageBox.Show("Player Wins");
                }
                if (index == 1)
                {
                    firstBotChips += int.Parse(potChips.Text);
                    tableChips.Text = firstBotChips.ToString();
                    firstBotPanel.Visible = true;
                    MessageBox.Show("Bot 1 Wins");
                }
                if (index == 2)
                {
                    secondBotChips += int.Parse(potChips.Text);
                    tableChips.Text = secondBotChips.ToString();
                    secondBotPanel.Visible = true;
                    MessageBox.Show("Bot 2 Wins");
                }
                if (index == 3)
                {
                    thirdBotChips += int.Parse(potChips.Text);
                    tableChips.Text = thirdBotChips.ToString();
                    thirdBotPanel.Visible = true;
                    MessageBox.Show("Bot 3 Wins");
                }
                if (index == 4)
                {
                    fourthBotChips += int.Parse(potChips.Text);
                    tableChips.Text = fourthBotChips.ToString();
                    fourthBotPanel.Visible = true;
                    MessageBox.Show("Bot 4 Wins");
                }
                if (index == 5)
                {
                    fifthBotChips += int.Parse(potChips.Text);
                    tableChips.Text = fifthBotChips.ToString();
                    fifthBotPanel.Visible = true;
                    MessageBox.Show("Bot 5 Wins");
                }

                for (int cardIndex = 0; cardIndex <= 16; cardIndex++)
                {
                    Dealer.Holder[cardIndex].Visible = false;
                }
                await Dealer.Finish(1);
            }

            double rounds = 0;
            int end = 4;
            if (winner < 6 && winner > 1 && rounds >= end)
            {
                await Dealer.Finish(2);
            }
        }

        private bool isRaising;
        /// <summary>
        /// Fold tell us who is giving up
        /// </summary>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        public void Fold(Label hasFolded)
        {
            isRaising = false;
            hasFolded.Text = "Fold";
            this.IsOnTurn = false;
        }

        /// <summary>
        /// Changes the label status to checking.
        /// </summary>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="statusLabel">The status label.</param>
        public void ChangeStatusToChecking()
        {
            this.IsOnTurn = false;
            isRaising = false;
        }

        private int call = 500;
        /// <summary>
        /// You call the required amount of chips to continue playing the game
        /// </summary>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="characterStatusLabel">The status label.</param>
        public void Call(int callSum)
        {
            isRaising = false;
            this.IsOnTurn = false;
            this.Chips -= callSum;
        }

        private double raise = 0;
        /// <summary>
        /// Raises the bet.
        /// </summary>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="statusLabel">The status label.</param>
        public void RaiseBet(ref int botChips, ref bool isBotsTurn, Label statusLabel, TextBox potChips)
        {
            botChips -= Convert.ToInt32(raise);
            statusLabel.Text = "Raise " + raise;
            potChips.Text = (int.Parse(potChips.Text) + Convert.ToInt32(raise)).ToString();
            call = Convert.ToInt32(raise);
            isRaising = true;
            isBotsTurn = false;
        }

        public Point GetSecondCardLocation(Point firstCardLocation, int cardWidth)
        {
            Point secondCardLocation = new Point();

            secondCardLocation.Y = firstCardLocation.Y;
            secondCardLocation.X = (firstCardLocation.X + cardWidth);

            return secondCardLocation;
        }
    }
}