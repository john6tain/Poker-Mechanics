using Poker.Enumerations;
using Poker.GameConstants;
using Poker.Interfacees;
using Poker.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Poker.Table
{
    public static class Dealer
    {
        private const double HighCardBehaviourPower = -1;
        private const double ThreeOfAKindBehaviourPower = 3;
        private const double PairFromTableBehaviourPower = 0;
        private const double PairFromHandBehaviourPower = 1;
        private const double TwoPairsBehaviourPower = 2;
        private const double FullHouseBehaviourPower = 6;
        private const double FourOfAKindBehaviourPower = 7;
        private const double LittleStraightFlushBehaviourPower = 8;
        private const double BigStraightFlushBehaviourPower = 9;
        private const double BigFlushBehaviourPower = 5.5;
        private const double LittleFlushBehaviourPower = 5;
        private const double StraightBehaviourPower = 4;


        private static readonly int[] AllCardsOnTable = new int[16];

        private static Label playerStatus;

        public static readonly PictureBox[] Holder = new PictureBox[52];

        #region Tsvetelin

        private static readonly List<bool?> bools = new List<bool?>();

        private static string[] ImgLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);

        private static readonly Image[] Deck = new Image[52];

        private static readonly int[] Reserve = new int[17];

        private static readonly Timer timer = new Timer();

        private static ProgressBar progressBarTimer;

        private static bool PlayerFirstTurn;
        private static bool botOneFirstTurn;
        private static bool botTwoFirstTurn; //botTwoTurn
        private static bool botThreeFirstTurn;
        private static bool botFourFirstTurn;
        private static bool botFiveFirstTurn;
        private static bool botSixFirstTurn;
        private static bool restart;
        private static bool playerTurn = true;

        private static Button foldButton;
        private static Button checkButton;
        private static Button callButton;
        private static Button raiseButton;

        private static readonly Panel playerPanel = new Panel();
        private static readonly Panel firstBotPanel = new Panel();
        private static readonly Panel secondBotPanel = new Panel();
        private static readonly Panel thirdBotPanel = new Panel();
        private static readonly Panel fourthBotPanel = new Panel();
        private static readonly Panel fifthBotPanel = new Panel();

        private static int playerChips = 10000;
        private static int firstBotChips = 10000;
        private static int secondBotChips = 10000;
        private static int thirdBotChips = 10000;
        private static int fourthBotChips = 10000;
        private static int fifthBotChips = 10000;
        private static int playerCall;
        private static int firstBotCall;
        private static int secondBotCall;
        private static int thirdBotCall;
        private static int fourthBotCall;
        private static int fifthBotCall;
        private static int playerRise;
        private static int firstBotRise;
        private static int secondBotRise;
        private static int thirdBotRise;
        private static int fourthBotRise;
        private static int fifthBotRise;
        private static int foldedPlayers = 5;
        private static int call = 500;
        private static int t = 60;
        private static int up = 10000000;
        private static int turnCount;

        private static double rounds;
        private static double raise;

        public static async Task Shuffle()
        {
            bools.Add(PlayerFirstTurn);
            bools.Add(botOneFirstTurn);
            bools.Add(botTwoFirstTurn);
            bools.Add(botThreeFirstTurn);
            bools.Add(botFourFirstTurn);
            bools.Add(botFiveFirstTurn);
            callButton.Enabled = false;
            raiseButton.Enabled = false;
            foldButton.Enabled = false;
            checkButton.Enabled = false;
            //MaximizeBox = false;
            //MinimizeBox = false;
            var check = false;
            var backImage = new Bitmap("Assets\\Back\\Back.png");
            int horizontal = 580;
            int vertical = 480;
            var random = new Random();
            int index;

            //shuffle all cards
            for (index = ImgLocation.Length; index > 0; index--)
            {
                var cardIndex = random.Next(index);
                var card = ImgLocation[cardIndex];
                ImgLocation[cardIndex] = ImgLocation[index - 1];
                ImgLocation[index - 1] = card;
            }

            //draw 17 cards 
            for (index = 0; index < 17; index++)
            {
                Deck[index] = Image.FromFile(ImgLocation[index]);
                var charsToRemove = new[] { "Assets\\Cards\\", ".png" };

                //parse name of the card
                foreach (var c in charsToRemove)
                {
                    ImgLocation[index] = ImgLocation[index].Replace(c, string.Empty);
                }

                Reserve[index] = int.Parse(ImgLocation[index]) - 1;
                Holder[index] = new PictureBox();
                Holder[index].SizeMode = PictureBoxSizeMode.StretchImage;
                Holder[index].Height = 130;
                Holder[index].Width = 80;
                //Controls.Add(Holder[index]);
                Holder[index].Name = "pb" + index;
                await Task.Delay(200);

                #region Throwing Cards

                if (index < 2)
                {
                    if (Holder[0].Tag != null)
                    {
                        Holder[1].Tag = Reserve[1];
                    }

                    Holder[0].Tag = Reserve[0];
                    Holder[index].Image = Deck[index];
                    Holder[index].Anchor = AnchorStyles.Bottom;
                    //Holder[index].Dock = DockStyle.Top;
                    Holder[index].Location = new Point(horizontal, vertical);
                    horizontal += Holder[index].Width;
                    //Controls.Add(playerPanel);
                    playerPanel.Location = new Point(Holder[0].Left - 10, Holder[0].Top - 10);
                    playerPanel.BackColor = Color.DarkBlue;
                    playerPanel.Height = 150;
                    playerPanel.Width = 180;
                    playerPanel.Visible = false;
                }

                if (firstBotChips > 0)
                {
                    foldedPlayers--;

                    if (index >= 2 && index < 4)
                    {
                        if (Holder[2].Tag != null)
                        {
                            Holder[3].Tag = Reserve[3];
                        }

                        Holder[2].Tag = Reserve[2];

                        if (!check)
                        {
                            horizontal = 15;
                            vertical = 420;
                        }

                        check = true;
                        Holder[index].Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                        Holder[index].Image = backImage;
                        //Holder[index].Image = Deck[index];
                        Holder[index].Location = new Point(horizontal, vertical);
                        horizontal += Holder[index].Width;
                        Holder[index].Visible = true;
                        //Controls.Add(firstBotPanel);
                        firstBotPanel.Location = new Point(Holder[2].Left - 10, Holder[2].Top - 10);
                        firstBotPanel.BackColor = Color.DarkBlue;
                        firstBotPanel.Height = 150;
                        firstBotPanel.Width = 180;
                        firstBotPanel.Visible = false;

                        if (index == 3)
                        {
                            check = false;
                        }
                    }
                }

                if (secondBotChips > 0)
                {
                    foldedPlayers--;

                    if (index >= 4 && index < 6)
                    {
                        if (Holder[4].Tag != null)
                        {
                            Holder[5].Tag = Reserve[5];
                        }

                        Holder[4].Tag = Reserve[4];

                        if (!check)
                        {
                            horizontal = 75;
                            vertical = 65;
                        }

                        check = true;
                        Holder[index].Anchor = AnchorStyles.Top | AnchorStyles.Left;
                        Holder[index].Image = backImage;
                        //Holder[index].Image = Deck[index];
                        Holder[index].Location = new Point(horizontal, vertical);
                        horizontal += Holder[index].Width;
                        Holder[index].Visible = true;
                        //Controls.Add(secondBotPanel);
                        secondBotPanel.Location = new Point(Holder[4].Left - 10, Holder[4].Top - 10);
                        secondBotPanel.BackColor = Color.DarkBlue;
                        secondBotPanel.Height = 150;
                        secondBotPanel.Width = 180;
                        secondBotPanel.Visible = false;

                        if (index == 5)
                        {
                            check = false;
                        }
                    }
                }

                if (thirdBotChips > 0)
                {
                    foldedPlayers--;

                    if (index >= 6 && index < 8)
                    {
                        if (Holder[6].Tag != null)
                        {
                            Holder[7].Tag = Reserve[7];
                        }

                        Holder[6].Tag = Reserve[6];

                        if (!check)
                        {
                            horizontal = 590;
                            vertical = 25;
                        }

                        check = true;
                        Holder[index].Anchor = AnchorStyles.Top;
                        Holder[index].Image = backImage;
                        //Holder[index].Image = Deck[index];
                        Holder[index].Location = new Point(horizontal, vertical);
                        horizontal += Holder[index].Width;
                        Holder[index].Visible = true;
                        //Controls.Add(thirdBotPanel);
                        thirdBotPanel.Location = new Point(Holder[6].Left - 10, Holder[6].Top - 10);
                        thirdBotPanel.BackColor = Color.DarkBlue;
                        thirdBotPanel.Height = 150;
                        thirdBotPanel.Width = 180;
                        thirdBotPanel.Visible = false;

                        if (index == 7)
                        {
                            check = false;
                        }
                    }
                }

                if (fourthBotChips > 0)
                {
                    foldedPlayers--;

                    if (index >= 8 && index < 10)
                    {
                        if (Holder[8].Tag != null)
                        {
                            Holder[9].Tag = Reserve[9];
                        }

                        Holder[8].Tag = Reserve[8];

                        if (!check)
                        {
                            horizontal = 1115;
                            vertical = 65;
                        }

                        check = true;
                        Holder[index].Anchor = AnchorStyles.Top | AnchorStyles.Right;
                        Holder[index].Image = backImage;
                        //Holder[index].Image = Deck[index];
                        Holder[index].Location = new Point(horizontal, vertical);
                        horizontal += Holder[index].Width;
                        Holder[index].Visible = true;
                        //Controls.Add(fourthBotPanel);
                        fourthBotPanel.Location = new Point(Holder[8].Left - 10, Holder[8].Top - 10);
                        fourthBotPanel.BackColor = Color.DarkBlue;
                        fourthBotPanel.Height = 150;
                        fourthBotPanel.Width = 180;
                        fourthBotPanel.Visible = false;

                        if (index == 9)
                        {
                            check = false;
                        }
                    }
                }

                if (fifthBotChips > 0)
                {
                    foldedPlayers--;

                    if (index >= 10 && index < 12)
                    {
                        if (Holder[10].Tag != null)
                        {
                            Holder[11].Tag = Reserve[11];
                        }

                        Holder[10].Tag = Reserve[10];

                        if (!check)
                        {
                            horizontal = 1160;
                            vertical = 420;
                        }
                        check = true;
                        Holder[index].Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                        Holder[index].Image = backImage;
                        //Holder[index].Image = Deck[index];
                        Holder[index].Location = new Point(horizontal, vertical);
                        horizontal += Holder[index].Width;
                        Holder[index].Visible = true;
                        //Controls.Add(fifthBotPanel);
                        fifthBotPanel.Location = new Point(Holder[10].Left - 10, Holder[10].Top - 10);
                        fifthBotPanel.BackColor = Color.DarkBlue;
                        fifthBotPanel.Height = 150;
                        fifthBotPanel.Width = 180;
                        fifthBotPanel.Visible = false;

                        if (index == 11)
                        {
                            check = false;
                        }
                    }
                }

                if (index >= 12)
                {
                    Holder[12].Tag = Reserve[12];
                    if (index > 12) Holder[13].Tag = Reserve[13];
                    if (index > 13) Holder[14].Tag = Reserve[14];
                    if (index > 14) Holder[15].Tag = Reserve[15];

                    if (index > 15)
                    {
                        Holder[16].Tag = Reserve[16];
                    }

                    if (!check)
                    {
                        horizontal = 410;
                        vertical = 265;
                    }

                    check = true;

                    if (Holder[index] != null)
                    {
                        Holder[index].Anchor = AnchorStyles.None;
                        Holder[index].Image = backImage;
                        //Holder[index].Image = Deck[index];
                        Holder[index].Location = new Point(horizontal, vertical);
                        horizontal += 110;
                    }
                }

                #endregion

                if (firstBotChips <= 0)
                {
                    botOneFirstTurn = true;
                    Holder[2].Visible = false;
                    Holder[3].Visible = false;
                }
                else
                {
                    botOneFirstTurn = false;

                    if (index == 3)
                    {
                        if (Holder[3] != null)
                        {
                            Holder[2].Visible = true;
                            Holder[3].Visible = true;
                        }
                    }
                }

                if (secondBotChips <= 0)
                {
                    botTwoFirstTurn = true;
                    Holder[4].Visible = false;
                    Holder[5].Visible = false;
                }
                else
                {
                    botTwoFirstTurn = false;

                    if (index == 5)
                    {
                        if (Holder[5] != null)
                        {
                            Holder[4].Visible = true;
                            Holder[5].Visible = true;
                        }
                    }
                }

                if (thirdBotChips <= 0)
                {
                    botThreeFirstTurn = true;
                    Holder[6].Visible = false;
                    Holder[7].Visible = false;
                }
                else
                {
                    botThreeFirstTurn = false;

                    if (index == 7)
                    {
                        if (Holder[7] != null)
                        {
                            Holder[6].Visible = true;
                            Holder[7].Visible = true;
                        }
                    }
                }

                if (fourthBotChips <= 0)
                {
                    botFourFirstTurn = true;
                    Holder[8].Visible = false;
                    Holder[9].Visible = false;
                }
                else
                {
                    botFourFirstTurn = false;

                    if (index == 9)
                    {
                        if (Holder[9] != null)
                        {
                            Holder[8].Visible = true;
                            Holder[9].Visible = true;
                        }
                    }
                }

                if (fifthBotChips <= 0)
                {
                    botFiveFirstTurn = true;
                    Holder[10].Visible = false;
                    Holder[11].Visible = false;
                }
                else
                {
                    botFiveFirstTurn = false;

                    if (index == 11)
                    {
                        if (Holder[11] != null)
                        {
                            Holder[10].Visible = true;
                            Holder[11].Visible = true;
                        }
                    }
                }

                if (index == 16)
                {
                    if (!restart)
                    {
                        //MaximizeBox = true;
                        //MinimizeBox = true;
                    }
                    timer.Start();
                }
            }

            if (foldedPlayers == 5)
            {
                var dialogResult = MessageBox.Show("Would You Like To Play Again ?", "You Won , Congratulations ! ",
                    MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else
            {
                foldedPlayers = 5;
            }

            if (index == 17)
            {
                raiseButton.Enabled = true;
                callButton.Enabled = true;
                foldButton.Enabled = true;
                //can be deleted, code repetition
                //raiseButton.Enabled = true;
                //raiseButton.Enabled = true;             
            }
        }

        private static void FixCall(Label status, ref int cCall, ref int cRaise, int options)
        {
            if (rounds != 4)
            {
                if (options == 1)
                {
                    if (status.Text.Contains("raise"))
                    {
                        var changeRaise = status.Text.Substring(6);
                        cRaise = int.Parse(changeRaise);
                    }
                    if (status.Text.Contains("Call"))
                    {
                        var changeCall = status.Text.Substring(5);
                        cCall = int.Parse(changeCall);
                    }
                    if (status.Text.Contains("Check"))
                    {
                        cRaise = 0;
                        cCall = 0;
                    }
                }
                if (options == 2)
                {
                    if (cRaise != raise && cRaise <= raise)
                    {
                        call = Convert.ToInt32(raise) - cRaise;
                    }
                    if (cCall != call || cCall <= call)
                    {
                        call = call - cCall;
                    }
                    if (cRaise == raise && raise > 0)
                    {
                        call = 0;
                        callButton.Enabled = false;
                        callButton.Text = "Callisfuckedup";
                    }
                }
            }
        }

        #endregion

        public static void SetGameRules(
            int card1,
            int card2,
            string playerName,
            ref double currentCardsValue,
            ref double power,
            bool foldedTurn,
            IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection,
            ICharacter character)
        {

            if (!foldedTurn || card1 == 0 && card2 == 1 && playerStatus.Text.Contains("Fold") == false)
            {
                #region Variables

                bool done = false;
                bool vf = false;

                int[] littleStraight = new int[5];
                int[] bigStraight = new int[7];

                bigStraight[0] = AllCardsOnTable[card1];
                bigStraight[1] = AllCardsOnTable[card2];
                littleStraight[0] = bigStraight[2] = AllCardsOnTable[12];
                littleStraight[1] = bigStraight[3] = AllCardsOnTable[13];
                littleStraight[2] = bigStraight[4] = AllCardsOnTable[14];
                littleStraight[3] = bigStraight[5] = AllCardsOnTable[15];
                littleStraight[4] = bigStraight[6] = AllCardsOnTable[16];

                int[] straightOfClubs = bigStraight.Where(o => o % 4 == 0).ToArray();
                int[] straightOfDiamonds = bigStraight.Where(o => o % 4 == 1).ToArray();
                int[] straightOfHearts = bigStraight.Where(o => o % 4 == 2).ToArray();
                int[] straightOfSpades = bigStraight.Where(o => o % 4 == 3).ToArray();

                int[] straightOfClubsValue = straightOfClubs.Select(o => o / 4).Distinct().ToArray();
                int[] straightOfDiamondsValue = straightOfDiamonds.Select(o => o / 4).Distinct().ToArray();
                int[] straightOfHeartsValue = straightOfHearts.Select(o => o / 4).Distinct().ToArray();
                int[] straightOfSpadesValue = straightOfSpades.Select(o => o / 4).Distinct().ToArray();

                Array.Sort(bigStraight);
                Array.Sort(straightOfClubsValue);
                Array.Sort(straightOfDiamondsValue);
                Array.Sort(straightOfHeartsValue);
                Array.Sort(straightOfSpadesValue);

                #endregion

                for (int i = 0; i < AllCardsOnTable.Length; i++)
                {
                    if (AllCardsOnTable[i] == int.Parse(Holder[card1].Tag.ToString()) &&
                        AllCardsOnTable[i + 1] == int.Parse(Holder[card2].Tag.ToString()))
                    {
                        //Pair from Hand curentCardsValue = 1
                        //CheckForPairFromHand(ref curentCardsValue, ref power);

                        //Pair or Two Pairs from Table curentCardsValue = 2 || 0
                        //CheckForPairTwoPair(ref curentCardsValue, ref power);

                        //Two Pairs curentCardsValue = 2
                        //CheckForTwoPair(ref curentCardsValue, ref power);

                        //Three of a kind curentCardsValue = 3
                        CheckForThreeOfAKind(charactersCardsCollection, tableCardsCollection, character);

                        //Straight curentCardsValue = 4
                        //rStraight(ref curentCardsValue, ref power, bigStraight);

                        //Flush curentCardsValue = 5 || 5.5
                        //rFlush(ref curentCardsValue, ref power, ref vf, littleStraight);

                        //Full House curentCardsValue = 6
                        //rFullHouse(ref curentCardsValue, ref power, ref done, bigStraight);

                        //Four of a Kind curentCardsValue = 7
                        //rFourOfAKind(ref curentCardsValue, ref power, bigStraight);

                        //Straight Flush curentCardsValue = 8 || 9
                        CheckForStraightFlushOfSpades(charactersCardsCollection, tableCardsCollection, character);
                        CheckForStraightFlushOfDiamonds(charactersCardsCollection, tableCardsCollection, character);
                        CheckForStraightFlushOfHearts(charactersCardsCollection, tableCardsCollection, character);
                        CheckForStraightFlushOfClubs(charactersCardsCollection, tableCardsCollection, character);

                        //High Card curentCardsValue = -1
                        CheckForHighCard(charactersCardsCollection, tableCardsCollection, character);
                    }
                }
            }
        }

        /// <summary>
        /// This method determins if straight flush of clubs combination is available 
        /// </summary>
        /// <param name="charactersCardsCollection">
        /// Player's cards
        /// </param>
        /// <param name="tableCardsCollection">
        /// All cards visible on the table
        /// </param>
        /// <param name="character">
        /// current player
        /// </param>
        /// <returns></returns>
        private static bool CheckForStraightFlushOfClubs(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character)
        {
            bool hasStraightFlush = false;

            List<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            List<ICard> straightFlushCardsCollection = (List<ICard>)joinedCardCollection.Where(c => c.Suit == CardSuit.Clubs).ToList();

            straightFlushCardsCollection = new List<ICard>(straightFlushCardsCollection.OrderByDescending(c => c.Rank));

            if (straightFlushCardsCollection.Count < 5)
            {
                return false;
            }
            else
            {
                straightFlushCardsCollection = straightFlushCardsCollection.Take(5).ToList();

                double power = 0;
                for (int i = 0; i < straightFlushCardsCollection.Count - 1; i++)
                {
                    if ((int)straightFlushCardsCollection[i].Rank - 1 != (int)straightFlushCardsCollection[i + 1].Rank)
                    {
                        return false;
                    }


                }

                if (straightFlushCardsCollection[0].Rank == CardRank.Ace)
                {
                    power = (int)straightFlushCardsCollection[0].Rank + BigStraightFlushBehaviourPower * 100;
                }

                else
                {
                    power = (int)straightFlushCardsCollection[0].Rank + LittleStraightFlushBehaviourPower * 100;
                }

                IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination = joinedCardCollection.Where(x => !straightFlushCardsCollection.Contains(x)).ToList();

                if (character.CardsCombination == null || character.CardsCombination.Type < CombinationType.StraightFlush)
                {
                    character.CardsCombination = new Combination(
                        power,
                        CombinationType.StraightFlush,
                        LittleStraightFlushBehaviourPower,
                        straightFlushCardsCollection,
                        theOtherCardsFromTheHandNotIncludedInTheCombination);
                }

                hasStraightFlush = true;
            }

            return hasStraightFlush;
        }

        /// <summary>
        /// This method determins if straight flush of diamonds combination is available 
        /// </summary>
        /// <param name="charactersCardsCollection">
        /// Player's cards
        /// </param>
        /// <param name="tableCardsCollection">
        /// All cards visible on the table
        /// </param>
        /// <param name="character">
        /// current player
        /// </param>
        /// <returns></returns>
        private static bool CheckForStraightFlushOfDiamonds(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character)
        {
            bool hasStraightFlush = false;

            List<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            List<ICard> straightFlushCardsCollection = (List<ICard>)joinedCardCollection.Where(c => c.Suit == CardSuit.Diamonds).ToList();

            straightFlushCardsCollection = new List<ICard>(straightFlushCardsCollection.OrderByDescending(c => c.Rank));

            if (straightFlushCardsCollection.Count < 5)
            {
                return false;
            }
            else
            {
                straightFlushCardsCollection = straightFlushCardsCollection.Take(5).ToList();

                double power = 0;
                for (int i = 0; i < straightFlushCardsCollection.Count - 1; i++)
                {
                    if ((int)straightFlushCardsCollection[i].Rank - 1 != (int)straightFlushCardsCollection[i + 1].Rank)
                    {
                        return false;
                    }


                }

                if (straightFlushCardsCollection[0].Rank == CardRank.Ace)
                {
                    power = (int)straightFlushCardsCollection[0].Rank + BigStraightFlushBehaviourPower * 100;
                }

                else
                {
                    power = (int)straightFlushCardsCollection[0].Rank + LittleStraightFlushBehaviourPower * 100;
                }

                IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination = joinedCardCollection.Where(x => !straightFlushCardsCollection.Contains(x)).ToList();

                if (character.CardsCombination == null || character.CardsCombination.Type < CombinationType.StraightFlush)
                {
                    character.CardsCombination = new Combination(
                        power,
                        CombinationType.StraightFlush,
                        LittleStraightFlushBehaviourPower,
                        straightFlushCardsCollection,
                        theOtherCardsFromTheHandNotIncludedInTheCombination);
                }

                hasStraightFlush = true;
            }

            return hasStraightFlush;
        }

        /// <summary>
        /// This method determins if straight flush of hearts combination is available 
        /// </summary>
        /// <param name="charactersCardsCollection">
        /// Player's cards
        /// </param>
        /// <param name="tableCardsCollection">
        /// All cards visible on the table
        /// </param>
        /// <param name="character">
        /// current player
        /// </param>
        /// <returns></returns>
        private static bool CheckForStraightFlushOfHearts(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character)
        {
            bool hasStraightFlush = false;

            List<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            List<ICard> straightFlushCardsCollection = (List<ICard>)joinedCardCollection.Where(c => c.Suit == CardSuit.Hearts).ToList();

            straightFlushCardsCollection = new List<ICard>(straightFlushCardsCollection.OrderByDescending(c => c.Rank));

            if (straightFlushCardsCollection.Count < 5)
            {
                return false;
            }
            else
            {
                straightFlushCardsCollection = straightFlushCardsCollection.Take(5).ToList();

                double power = 0;
                for (int i = 0; i < straightFlushCardsCollection.Count - 1; i++)
                {
                    if ((int)straightFlushCardsCollection[i].Rank - 1 != (int)straightFlushCardsCollection[i + 1].Rank)
                    {
                        return false;
                    }


                }

                if (straightFlushCardsCollection[0].Rank == CardRank.Ace)
                {
                    power = (int)straightFlushCardsCollection[0].Rank + BigStraightFlushBehaviourPower * 100;
                }

                else
                {
                    power = (int)straightFlushCardsCollection[0].Rank + LittleStraightFlushBehaviourPower * 100;
                }

                IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination = joinedCardCollection.Where(x => !straightFlushCardsCollection.Contains(x)).ToList();

                if (character.CardsCombination == null || character.CardsCombination.Type < CombinationType.StraightFlush)
                {
                    character.CardsCombination = new Combination(
                        power,
                        CombinationType.StraightFlush,
                        LittleStraightFlushBehaviourPower,
                        straightFlushCardsCollection,
                        theOtherCardsFromTheHandNotIncludedInTheCombination);
                }

                hasStraightFlush = true;
            }

            return hasStraightFlush;
        }

        /// <summary>
        /// This method determins if straight flush of spades combination is available 
        /// </summary>
        /// <param name="charactersCardsCollection">
        /// Player's cards
        /// </param>
        /// <param name="tableCardsCollection">
        /// All cards visible on the table
        /// </param>
        /// <param name="character">
        /// current player
        /// </param>
        /// <returns></returns>
        private static bool CheckForStraightFlushOfSpades(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character)
        {
            bool hasStraightFlush = false;

            List<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            List<ICard> straightFlushCardsCollection = (List<ICard>)joinedCardCollection.Where(c => c.Suit == CardSuit.Spades).ToList();

            straightFlushCardsCollection = new List<ICard>(straightFlushCardsCollection.OrderByDescending(c => c.Rank));

            if (straightFlushCardsCollection.Count < 5)
            {
                return false;
            }
            else
            {
                straightFlushCardsCollection = straightFlushCardsCollection.Take(5).ToList();

                double power = 0;
                for (int i = 0; i < straightFlushCardsCollection.Count - 1; i++)
                {
                    if ((int)straightFlushCardsCollection[i].Rank - 1 != (int)straightFlushCardsCollection[i + 1].Rank)
                    {
                        return false;
                    }
                }

                if (straightFlushCardsCollection[0].Rank == CardRank.Ace)
                {
                    power = (int)straightFlushCardsCollection[0].Rank + BigStraightFlushBehaviourPower * 100;
                }

                else
                {
                    power = (int)straightFlushCardsCollection[0].Rank + LittleStraightFlushBehaviourPower * 100;
                }

                IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination = joinedCardCollection.Where(x => !straightFlushCardsCollection.Contains(x)).ToList();

                if (character.CardsCombination == null || character.CardsCombination.Type < CombinationType.StraightFlush)
                {
                    character.CardsCombination = new Combination(
                        power,
                        CombinationType.StraightFlush,
                        LittleStraightFlushBehaviourPower,
                        straightFlushCardsCollection,
                        theOtherCardsFromTheHandNotIncludedInTheCombination);
                }

                hasStraightFlush = true;
            }

            return hasStraightFlush;
        }

        private static bool CheckForStraight(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection,
            ICharacter character)
        {
            List<ICard> joinedCardCollection =
                charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();
            joinedCardCollection = new List<ICard>(joinedCardCollection.OrderByDescending(x => x.Rank));
            List<int> distinctCardRanks = joinedCardCollection.Select(x => (int)x.Rank).Distinct().OrderByDescending(x => x).ToList();

            int endBorderOfStraight = 4; // if a number is the beginning of a straight, then the end is '4' numbers later (straight must be 5 cards))
            bool hasStraight = false;
            double power = 0;

            for (int currentCardIndex = 0; currentCardIndex < distinctCardRanks.Count - endBorderOfStraight; currentCardIndex++)
            {
                if (distinctCardRanks[currentCardIndex] - endBorderOfStraight == distinctCardRanks[currentCardIndex + endBorderOfStraight])
                {
                    hasStraight = true;
                    int highestCardInStraight = distinctCardRanks[currentCardIndex];
                    power = highestCardInStraight + Constants.StraightBehaviourPower * 100;
                    break;
                }
            }

            if (hasStraight)
            {
                List<ICard> straightCombinationCards = new List<ICard>();

                foreach (int distinctRank in distinctCardRanks)
                {
                    ICard cardToBeAdded = joinedCardCollection.Find(card => (int)card.Rank == distinctRank);
                    straightCombinationCards.Add(cardToBeAdded);
                }
                IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                    joinedCardCollection.Where(x => !straightCombinationCards.Contains(x)).ToList();

                RegisterCombinationToCharacter(character, power, straightCombinationCards,
                    theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.Straight,
                    Constants.StraightBehaviourPower);
            }

            return hasStraight;

        }


        private static bool CheckForFlush(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection,
            ICharacter character)
        {
            List<ICard> joinedCardCollection =
                charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            bool hasFlush = false;
            int requiredCardsForFlush = 5;

            List<ICard> cardsThatMakeUpFlush = new List<ICard>();

            foreach (ICard card in joinedCardCollection)
            {
                List<ICard> sameSuitCardsCollection = joinedCardCollection.Where(x => x.Suit == card.Suit).ToList();

                if (sameSuitCardsCollection.Count >= requiredCardsForFlush)
                {
                    hasFlush = true;
                    cardsThatMakeUpFlush = sameSuitCardsCollection;
                    break;
                }
            }
            if (hasFlush)
            {
                List<ICard> tableCardsThatMakeUpFlush = cardsThatMakeUpFlush;

                tableCardsThatMakeUpFlush.RemoveAll(x => charactersCardsCollection.Contains(x));

                if (tableCardsThatMakeUpFlush.Count == requiredCardsForFlush)
                {
                    return CheckForFlushIfTableCardsMakeFlush(charactersCardsCollection, tableCardsThatMakeUpFlush, joinedCardCollection,
                        character);
                }
                else
                {
                    if (cardsThatMakeUpFlush.Count > requiredCardsForFlush)
                    {
                        int lowestCardInFlush = (int)cardsThatMakeUpFlush.Min(x => x.Rank);
                        cardsThatMakeUpFlush.RemoveAll(x => (int)x.Rank == lowestCardInFlush);
                    }

                    int highestCardInFlush = (int)cardsThatMakeUpFlush.Max(x => x.Rank);
                    double currentFlushBehaviourPower = Constants.LittleFlushBehaviourPower;

                    //Check if character has Ace in his hand that is part of the flush
                    //If they do -> the behaviour power is different (greater)
                    foreach (ICard card in charactersCardsCollection)
                    {
                        if (card.Suit == cardsThatMakeUpFlush[0].Suit && card.Rank == CardRank.Ace)
                        {
                            currentFlushBehaviourPower = Constants.BigFlushBehaviourPower;
                        }
                    }

                    double power = highestCardInFlush + currentFlushBehaviourPower * 100;
                    List<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                        joinedCardCollection.Where(x => !cardsThatMakeUpFlush.Contains(x)).ToList();

                    RegisterCombinationToCharacter(character, power, cardsThatMakeUpFlush, theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.Flush, currentFlushBehaviourPower);
                }
            }
            return hasFlush;
        }

        private static bool CheckForFlushIfTableCardsMakeFlush(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsThatMakeUpFlush, IList<ICard> joinedCardCollection, ICharacter character)
        {
            List<ICard> characterCardsInFlush =
                charactersCardsCollection.Where(x => x.Suit == tableCardsThatMakeUpFlush[0].Suit).ToList();
            List<ICard> cardsThatMakeUpFlush = characterCardsInFlush.Union(tableCardsThatMakeUpFlush).ToList();
            int maxCharaterCardInFlushRank = 0;

            //Check if the cards in the character's hand are the same suit as the flush suit
            //If yes -> get the bigger one (if both are same suit) or only the one that is the same suit
            if (characterCardsInFlush.Count == 0)
            {
                return false;
            }
            else if (characterCardsInFlush.Count == 2)
            {
                maxCharaterCardInFlushRank = ((int)characterCardsInFlush[0].Rank > (int)characterCardsInFlush[1].Rank)
                    ? (int)characterCardsInFlush[0].Rank
                    : (int)characterCardsInFlush[1].Rank;
            }
            else
            {
                maxCharaterCardInFlushRank = (int)characterCardsInFlush[0].Rank;
            }

            int lowestCardInTableFlush = (int)tableCardsThatMakeUpFlush.Min(x => x.Rank);
            double currentFlushBehaviourPower = Constants.LittleFlushBehaviourPower;
            double power = 0;

            if (maxCharaterCardInFlushRank > lowestCardInTableFlush)
            {
                if (maxCharaterCardInFlushRank == (int)CardRank.Ace)
                {
                    currentFlushBehaviourPower = Constants.BigFlushBehaviourPower;
                }
                power = maxCharaterCardInFlushRank + currentFlushBehaviourPower * 100;
            }
            else
            {
                power = lowestCardInTableFlush + currentFlushBehaviourPower * 100;
            }

            while (cardsThatMakeUpFlush.Count > 5)
            {
                int lowestCardInFlush = (int)cardsThatMakeUpFlush.Min(x => x.Rank);
                cardsThatMakeUpFlush.RemoveAll(x => (int)x.Rank == lowestCardInFlush);
            }

            List<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                       joinedCardCollection.Where(x => !cardsThatMakeUpFlush.Contains(x)).ToList();
            RegisterCombinationToCharacter(character, power, cardsThatMakeUpFlush, theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.Flush, currentFlushBehaviourPower);

            return true;
        }



        /// <summary>
        /// This method cheks for forur of a kind combination
        /// </summary>
        /// <param name="charactersCardsCollection">
        /// Cards in player's hand
        /// </param>
        /// <param name="tableCardsCollection">
        /// Cards on table
        /// </param>
        /// <param name="character">
        /// player whose cards are checked
        /// </param>
        /// <returns></returns>
        private static bool CheckForFourOfAKind(
            IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection,
            ICharacter character)
        {
            IList<ICard> joinedCardCollection =
                charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            foreach (var element in joinedCardCollection)
            {
                IList<ICard> sameRankCardsCollection = joinedCardCollection.Where(x => x.Rank == element.Rank).ToList();

                if (sameRankCardsCollection.Count == 4)
                {
                    double power = (int)sameRankCardsCollection[0].Rank * 4 + FourOfAKindBehaviourPower * 100;

                    IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                        joinedCardCollection.Where(x => !sameRankCardsCollection.Contains(x)).ToList();

                    RegisterCombinationToCharacter(character, power, sameRankCardsCollection, theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.FourOfAKind, Constants.FourOfAKindBehavourPower);

                    return true;
                }
            }

            return false;
        }


        //This method checks if the character has card combination "Full House"
        private static bool CheckForFullHouse(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection,
            ICharacter character)
        {
            bool hasFullHouse = false;

            List<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            bool characterHasThreeOfAKind = CheckForThreeOfAKind(charactersCardsCollection, tableCardsCollection,
                character);

            List<ICard> threeOfAKindCards = new List<ICard>();

            int threeOfAKindRank = -1;

            if (characterHasThreeOfAKind)
            {
                threeOfAKindRank = GetThreeOfAKindCardRank(charactersCardsCollection, tableCardsCollection);

                //removes the three-of-a-kind cards from the joinedCardCollection (hand+table cards)
                // and adds them to the threeOfAKindCards list
                foreach (ICard card in joinedCardCollection)
                {
                    if ((int)card.Rank == threeOfAKindRank)
                    {
                        threeOfAKindCards.Add(card);
                        joinedCardCollection.Remove(card);
                    }
                }

                //checks if there is a pair in the remaining collection
                //if yes -> the player has a full house combination
                int maxPairRank = -1;
                foreach (ICard card in joinedCardCollection)
                {
                    List<ICard> remainingEqualRankCards =
                        joinedCardCollection.Where(x => x.Rank == card.Rank).ToList();

                    if (remainingEqualRankCards.Count == 2)
                    {
                        hasFullHouse = true;

                        //This is a check for multiple pairs in the remaining cards
                        //If there is more than one pair, the highest one is taken
                        maxPairRank = Math.Max(maxPairRank, (int)card.Rank); //  take the one with the higher rank

                        List<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                            joinedCardCollection.Where(x => x != remainingEqualRankCards[0]).ToList();

                        List<ICard> fullHouseCards = threeOfAKindCards;
                        fullHouseCards.AddRange(remainingEqualRankCards);

                        double power = 0;  //TODO: figure how to calculate power...

                        if (character.CardsCombination == null ||
                            character.CardsCombination.Type < CombinationType.FullHouse)
                        {
                            character.CardsCombination = new Combination(power, CombinationType.FullHouse, FullHouseBehaviourPower, fullHouseCards, theOtherCardsFromTheHandNotIncludedInTheCombination);
                        }

                    }
                }
            }

            return hasFullHouse;
        }

        //This method gets the rank (number) of the cards that make up a three-of-a-kind
        private static int GetThreeOfAKindCardRank(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection)
        {
            int cardRank = -1;

            IList<ICard> joinedCardCollection =
                charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            foreach (var element in joinedCardCollection)
            {
                IList<ICard> sameRankCardsCollection = joinedCardCollection.Where(x => x.Rank == element.Rank).ToList();

                if (sameRankCardsCollection.Count == 3)
                {
                    cardRank = (int)element.Rank;
                }
            }

            return cardRank;
        }


        //This method checks if the character has card combination "Three of a kind"
        private static bool CheckForThreeOfAKind(IEnumerable<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection, ICharacter character)
        {
            IList<ICard> joinedCardCollection =
                charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            foreach (var element in joinedCardCollection)
            {
                IList<ICard> sameRankCardsCollection = joinedCardCollection.Where(x => x.Rank == element.Rank).ToList();

                if (sameRankCardsCollection.Count == 3)
                {
                    double power = (int)sameRankCardsCollection[0].Rank * 3 + ThreeOfAKindBehaviourPower * 100;

                    IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                        joinedCardCollection.Where(x => !sameRankCardsCollection.Contains(x)).ToList();

                    RegisterCombinationToCharacter(character, power, sameRankCardsCollection, theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.ThreeOfAKind, Constants.ThreeOfAKindBehaviourPower);

                    return true;
                }
            }

            return false;
        }

        private static void RegisterCombinationToCharacter(ICharacter character, double power, IList<ICard> combinationCardsCollection,
            IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType combinationType, double behaviourPower)
        {
            if (character.CardsCombination == null || character.CardsCombination.Type < combinationType || character.CardsCombination.Power < power)
            {
                character.CardsCombination = new Combination(power, combinationType, behaviourPower, combinationCardsCollection, theOtherCardsFromTheHandNotIncludedInTheCombination);
            }
        }


        //This method checks for a "High card" combination
        private static bool CheckForHighCard(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection, ICharacter character)
        {
            double power = Math.Max((double)charactersCardsCollection[0].Rank, (double)charactersCardsCollection[1].Rank);

            IList<ICard> joinedCardCollection =
    charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).OrderByDescending(x => x.Rank).ToList();

            IList<ICard> combinationCardsCollection = new List<ICard>();
            combinationCardsCollection.Add(joinedCardCollection[0]);

            IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination = joinedCardCollection.Where(x => !combinationCardsCollection.Contains(x)).ToList();

            RegisterCombinationToCharacter(character, power, combinationCardsCollection, theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.HighCard, Constants.HighCardBehaviourPower);

            return true;
        }

        //This method checks if the two cards which the character has make a pair or if one of the character's cards makes a pair with one card from the table.
        public static bool CheckForPairFromHand(IList<ICard> charactersCardsCollection,
    IList<ICard> tableCardsCollection, ICharacter character)
        {

            bool isHoldingAPairHand = CheckIfTheCharactersCardsMakeAPair(charactersCardsCollection, tableCardsCollection, character);

            bool theFirstCharactersCardMakesPairWithOneFromTheTable = false;
            bool theSecondCharactersCardMakesPairWithOneFromTheTable = false;

            foreach (var element in tableCardsCollection)
            {
                theFirstCharactersCardMakesPairWithOneFromTheTable = CheckIfTheFirstCharactersCardMakesAPairWithOneFromTheTable(charactersCardsCollection, tableCardsCollection, character, element);

                theSecondCharactersCardMakesPairWithOneFromTheTable = CheckIfTheOtherCharactersCardMakesAPairWithOneFromTheTable(charactersCardsCollection, tableCardsCollection, character, element);
            }

            return isHoldingAPairHand || theFirstCharactersCardMakesPairWithOneFromTheTable || theSecondCharactersCardMakesPairWithOneFromTheTable;
        }

        private static bool CheckIfTheOtherCharactersCardMakesAPairWithOneFromTheTable(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character, ICard element)
        {
            bool theSecondCharactersCardMakesPairWithOneFromTheTable = false;

            if (charactersCardsCollection[1].Rank == element.Rank)
            {
                if (charactersCardsCollection[1].Rank == element.Rank)
                {
                    double power = (int)charactersCardsCollection[1].Rank * 4 + PairFromHandBehaviourPower * 100;

                    IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                        tableCardsCollection.Where(x => x != element).ToList();
                    theOtherCardsFromTheHandNotIncludedInTheCombination.Add(charactersCardsCollection[0]);

                    IList<ICard> combinationCardsCollection = new List<ICard>();
                    combinationCardsCollection.Add(element);
                    combinationCardsCollection.Add(charactersCardsCollection[1]);

                    RegisterCombinationToCharacter(character, power, combinationCardsCollection, theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.OnePair, Constants.PairFromHandBehaviourPower);
                }

                theSecondCharactersCardMakesPairWithOneFromTheTable = true;
            }
            return theSecondCharactersCardMakesPairWithOneFromTheTable;
        }

        private static bool CheckIfTheFirstCharactersCardMakesAPairWithOneFromTheTable(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character, ICard element)
        {
            bool theFirstCharactersCardMakesPairWithOneFromTheTable = false;

            if (charactersCardsCollection[0].Rank == element.Rank)
            {
                double power = (int)charactersCardsCollection[0].Rank * 4 + PairFromHandBehaviourPower * 100;

                IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                    tableCardsCollection.Where(x => x != element).ToList();
                theOtherCardsFromTheHandNotIncludedInTheCombination.Add(charactersCardsCollection[1]);

                IList<ICard> combinationCardsCollection = new List<ICard>();
                combinationCardsCollection.Add(element);
                combinationCardsCollection.Add(charactersCardsCollection[0]);

                RegisterCombinationToCharacter(character, power, combinationCardsCollection, theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.OnePair, Constants.PairFromHandBehaviourPower);


                theFirstCharactersCardMakesPairWithOneFromTheTable = true;
            }
            return theFirstCharactersCardMakesPairWithOneFromTheTable;
        }

        //This method checks if the character has two pairs and at least one of the cards is in their hand
        private static bool CheckForTwoPairsFromHand(IList<ICard> charactersCardsCollection,
     IList<ICard> tableCardsCollection, ICharacter character)
        {
            bool hasOnePairFromHand = false;
            bool hasTwoPairsFromHand = false;

            hasOnePairFromHand = CheckForPairFromHand(charactersCardsCollection, tableCardsCollection, character);

            if (hasOnePairFromHand)
            {
                IList<ICard> cardsOnTheTableNotIncludingThePair =
                    tableCardsCollection.Where(x => !character.CardsCombination.TheCombinationCards.Contains(x))
                        .ToList();

                foreach (var element in cardsOnTheTableNotIncludingThePair)
                {
                    IList<ICard> sameRankCardsCollection = character.CardsCombination.TheOtherCardsFromTheHandNotIncludedInTheCombination.Where(x => x.Rank == element.Rank).ToList();

                    if (sameRankCardsCollection.Count >= 2 && sameRankCardsCollection[0].Rank != character.CardsCombination.TheCombinationCards[0].Rank)
                    {
                        sameRankCardsCollection =
                            sameRankCardsCollection.OrderByDescending(x => x.Rank).Take(2).ToList();

                        var power = DetermineTheCombinationsCardsPowerInCaseOfTwoPairs(character, sameRankCardsCollection);

                        sameRankCardsCollection =
                            sameRankCardsCollection.Union(character.CardsCombination.TheCombinationCards)
                                .OrderByDescending(x => x.Rank)
                                .ToList();

                        IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                            character.CardsCombination.TheOtherCardsFromTheHandNotIncludedInTheCombination.Where(
                                x => !sameRankCardsCollection.Contains(x)).ToList();

                        RegisterCombinationToCharacter(character, power, sameRankCardsCollection,
                            theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.TwoPair,
                            TwoPairsBehaviourPower);

                        hasTwoPairsFromHand = true;

                        return hasTwoPairsFromHand;
                    }
                }
            }

            return hasTwoPairsFromHand;
        }

        //This method checks if there are two pairs in the cards on the table
        private static bool CheckForTwoPairsFromTable(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character)
        {
            bool hasTwoPairsFromHand = false;

            bool thereIsOnePairOnTheTable = CheckForPairFromTable(charactersCardsCollection, tableCardsCollection,
                character);

            if (thereIsOnePairOnTheTable)
            {

                IList<ICard> cardsOnTheTableNotIncludingThePair =
    tableCardsCollection.Where(x => !character.CardsCombination.TheCombinationCards.Contains(x))
        .ToList();

                foreach (var element in cardsOnTheTableNotIncludingThePair)
                {
                    IList<ICard> sameRankCardsCollection = cardsOnTheTableNotIncludingThePair.Where(x => x.Rank == element.Rank).ToList();

                    if (sameRankCardsCollection.Count >= 2 && sameRankCardsCollection[0].Rank != character.CardsCombination.TheCombinationCards[0].Rank)
                    {
                        sameRankCardsCollection =
                            sameRankCardsCollection.OrderByDescending(x => x.Rank).Take(2).ToList();

                        var power = DetermineTheCombinationsCardsPowerInCaseOfTwoPairs(character, sameRankCardsCollection);

                        sameRankCardsCollection =
                            sameRankCardsCollection.Union(character.CardsCombination.TheCombinationCards)
                                .OrderByDescending(x => x.Rank)
                                .ToList();

                        IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                            character.CardsCombination.TheOtherCardsFromTheHandNotIncludedInTheCombination.Where(
                                x => !sameRankCardsCollection.Contains(x)).ToList();

                        RegisterCombinationToCharacter(character, power, sameRankCardsCollection,
                            theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.TwoPair,
                            TwoPairsBehaviourPower);

                        hasTwoPairsFromHand = true;

                        return hasTwoPairsFromHand;
                    }
                }
            }

            return hasTwoPairsFromHand;

        }

        private static double DetermineTheCombinationsCardsPowerInCaseOfTwoPairs(ICharacter character,
    IList<ICard> sameRankCardsCollection)
        {
            double power = 0;

            if (character.CardsCombination.TheCombinationCards[0].Rank == CardRank.Ace)
            {
                power = (int)sameRankCardsCollection[0].Rank * 4 +
                        (int)sameRankCardsCollection[1].Rank * 2 +
                        TwoPairsBehaviourPower * 100;
            }
            else if (character.CardsCombination.TheCombinationCards[1].Rank == CardRank.Ace)
            {
                power = (int)sameRankCardsCollection[1].Rank * 4 +
                        (int)sameRankCardsCollection[0].Rank * 2 +
                        TwoPairsBehaviourPower * 100;
            }
            else
            {
                power = (int)sameRankCardsCollection[1].Rank * 2 +
                        (int)sameRankCardsCollection[0].Rank * 2 + TwoPairsBehaviourPower * 100;
            }
            return power;
        }

        //This method checks if there is one pair in the cards on the table
        private static bool CheckForPairFromTable(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection, ICharacter character)
        {
            IList<ICard> joinedCardCollection =
                charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            foreach (var element in tableCardsCollection)
            {
                IList<ICard> sameRankCardsCollection = joinedCardCollection.Where(x => x.Rank == element.Rank).ToList();

                if (sameRankCardsCollection.Count == 2)
                {
                    double power = 0;

                    if ((int)charactersCardsCollection[0].Rank >= (int)charactersCardsCollection[1].Rank)
                    {
                        power = (int)charactersCardsCollection[0].Rank + (int)sameRankCardsCollection[0].Rank * 100;
                    }
                    else
                    {
                        power = (int)charactersCardsCollection[1].Rank + (int)sameRankCardsCollection[0].Rank * 100;
                    }

                    IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                        joinedCardCollection.Where(x => !sameRankCardsCollection.Contains(x)).OrderByDescending(x => x.Rank).ToList();

                    RegisterCombinationToCharacter(character, power, sameRankCardsCollection, theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.OnePair, PairFromTableBehaviourPower);

                    return true;
                }
            }

            return false;
        }

        private static bool CheckIfTheCharactersCardsMakeAPair(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection,
            ICharacter character)
        {
            bool isHoldingAPairHand = false;

            if (charactersCardsCollection[0].Rank == charactersCardsCollection[1].Rank)
            {
                double power = (int)charactersCardsCollection[0].Rank * 4 + PairFromHandBehaviourPower * 100;

                IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination = tableCardsCollection;

                RegisterCombinationToCharacter(character, power, charactersCardsCollection, theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.OnePair, Constants.PairFromHandBehaviourPower);

                isHoldingAPairHand = true;
            }

            return isHoldingAPairHand;
        }

        private static void DetermineTheWinner(IList<ICharacter> gamePlayers)
        {
            gamePlayers = gamePlayers.OrderByDescending(x => x.CardsCombination.Type).ToList();

            IList<ICharacter> playersWithTheSameType = gamePlayers.Where(x => x.CardsCombination.Type == gamePlayers[0].CardsCombination.Type).ToList();

            if (playersWithTheSameType.Count == 1)
            {
                MessageBox.Show("" + "characterName" + " " + playersWithTheSameType[0].CardsCombination.Type);
            }
            else
            {
                bool equalScore = true;

                equalScore = DetermineIfEqual(playersWithTheSameType, equalScore);

                if (equalScore)
                {
                    //var winnerNames = playersWithTheSameType.All()
                    MessageBox.Show("Equal score" + "winners names" + playersWithTheSameType[0].CardsCombination.Type);
                }
                else
                {
                    playersWithTheSameType =
                        playersWithTheSameType.OrderByDescending(x => x.CardsCombination.Hand[0].Rank).
                            ThenByDescending(x => x.CardsCombination.Hand[1].Rank).
                            ThenByDescending(x => x.CardsCombination.Hand[2].Rank).
                            ThenByDescending(x => x.CardsCombination.Hand[3].Rank).
                            ThenByDescending(x => x.CardsCombination.Hand[4].Rank).ToList();

                    MessageBox.Show("" + "characterName" + " " + playersWithTheSameType[0].CardsCombination.Type);
                }
            }
        }


        private static bool DetermineIfEqual(IList<ICharacter> playersWithTheSameType, bool equalScore)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < playersWithTheSameType.Count - 1; j++)
                {
                    if (playersWithTheSameType[j].CardsCombination.Hand[i].Rank !=
                        playersWithTheSameType[j + 1].CardsCombination.Hand[i].Rank)
                    {
                        equalScore = false;
                    }
                }
            }
            return equalScore;
        }
    }
}