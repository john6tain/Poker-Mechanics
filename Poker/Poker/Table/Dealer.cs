using Poker.Enumerations;
using Poker.GameConstants;
using Poker.Interfacees;
using Poker.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.Character;


namespace Poker.Table
{
    public class Dealer : IDealer
    {
        private const double HighCardBehaviourPower = -1;
        private const double ThreeOfAKindBehaviourPower = 3;
        private const double OnePairBehaviourPower = 1;
        private const double TwoPairsBehaviourPower = 2;
        private const double FullHouseBehaviourPower = 6;
        private const double FourOfAKindBehaviourPower = 7;
        private const double LittleStraightFlushBehaviourPower = 8;
        private const double BigStraightFlushBehaviourPower = 9;
        private const double BigFlushBehaviourPower = 5.5;
        private const double LittleFlushBehaviourPower = 5;
        private const double StraightBehaviourPower = 4;


        private static Label playerStatus;

        public static readonly PictureBox[] Holder = new PictureBox[52];

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

        //Finish fields
        private static int bigBlind = 500;
        private static double type;
        private static double firstBotPower;
        private static double secondBotPower;
        private static double thirdBotPower;
        private static double fourthBotPower;
        private static double fifthBotPower;
        private static double playerPower;
        private static double playerType = -1;
        private static double firstBotType = -1;
        private static double secondBotType = -1;
        private static double thirdBotType = -1;
        private static double fourthBotType = -1;
        private static double fifthBotType = -1;
        private static bool B1turn;
        private static bool B2turn;
        private static bool B3turn;
        private static bool B4turn;
        private static bool B5turn;
        private static bool playerFolded;
        private static bool botOneFolded;
        private static bool botTwoFolded;
        private static bool botThreeFolded;
        private static bool b4Folded;
        private static bool b5Folded;
        private static bool isRaising;
        private static int height;
        private static int width;
        private static int winners;
        private static int Flop = 1;
        private static int Turn = 2;
        private static int River = 3;
        private static int End = 4;
        private static int maxLeft = 6;
        private static int last = 123;
        private static int raisedTurn = 1;
        private static Label fifthBotStatus;
        private static Label fourthBotStatus;
        private static Label thirdBotStatus;
        private static Label firstBotStatus;
        private static Label secondBotStatus;
        private static int Chips = 10000;

        

        public async Task SetupGame(IDatabase database, ICharacter player, ICharacter bot1, ICharacter bot2, ICharacter bot3, ICharacter bot4, ICharacter bot5, ITable table, Control.ControlCollection Controls)
        {

            IList<ICard> shuffledDeck = database.Deck.ToList();

            ShuffleCards(shuffledDeck);

            DealCards(shuffledDeck, player, bot1, bot2, bot3, bot4, bot5, table, Controls);



            #region Code to be assesed and removed...



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
            //for (index = ImgLocation.Length; index > 0; index--)
            //{
            //    var cardIndex = random.Next(index);
            //    var card = ImgLocation[cardIndex];
            //    ImgLocation[cardIndex] = ImgLocation[index - 1];
            //    ImgLocation[index - 1] = card;
            //}

            //draw 17 cards 
            for (index = 0; index < 17; index++)
            {
                Deck[index] = Image.FromFile(ImgLocation[index]); // database.Deck[index].Image
                var charsToRemove = new[] { "Assets\\Cards\\", ".png" };

                //parse name of the card
                foreach (var c in charsToRemove)
                {
                    ImgLocation[index] = ImgLocation[index].Replace(c, string.Empty);
                }

                Reserve[index] = int.Parse(ImgLocation[index]) - 1;
                Holder[index] = new PictureBox(); // // database.Deck[index].PictureBox
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
                ///////
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

            #endregion
        }

        private void DealCards(IList<ICard> shuffledDeck, ICharacter player, ICharacter bot1, ICharacter bot2, ICharacter bot3, ICharacter bot4, ICharacter bot5, ITable table, Control.ControlCollection Controls)
        {
            #region Player

            player.CharacterCardsCollection.Clear();

            

            GiveCard(player, 0, shuffledDeck, 0, Controls);
            GiveCard(player, 1, shuffledDeck, 1, Controls);


            #endregion

            #region Bots


            DealCardsToBot(bot1, 2, 3, shuffledDeck, Controls);
            DealCardsToBot(bot2, 4, 5, shuffledDeck, Controls);
            DealCardsToBot(bot3, 6, 7, shuffledDeck, Controls);
            DealCardsToBot(bot4, 8, 9, shuffledDeck, Controls);
            DealCardsToBot(bot5, 10, 11, shuffledDeck, Controls);

            #endregion

            #region Table

            DealCardsToTable(table, 12, shuffledDeck, Controls);

            #endregion
        }

        private void GiveCard(ICharacter character, int handCardIndex, IList<ICard> shuffledDeck, int deckCardIndex, Control.ControlCollection controls)
        {
            character.CharacterCardsCollection.Add(shuffledDeck[deckCardIndex]);

            character.CharacterCardsCollection[handCardIndex].CardPictureBox.Height = Constants.CardHeight;
            character.CharacterCardsCollection[handCardIndex].CardPictureBox.Width = Constants.CardWidth;


            if (character.CharacterCardsCollection[handCardIndex].IsVisible)
            {
                character.CharacterCardsCollection[handCardIndex].CardPictureBox.Image =  character.CharacterCardsCollection[0].FrontImage;
            }
            else
            {
                character.CharacterCardsCollection[handCardIndex].CardPictureBox.Image = character.CharacterCardsCollection[0].BackImage;
            }
        

            if (handCardIndex == 0)
            {
                character.CharacterCardsCollection[handCardIndex].CardPictureBox.Location = character.FirstCardLocation;
            }
            else
            {
                character.CharacterCardsCollection[handCardIndex].CardPictureBox.Location = character.SecondCardLocation;
            }
            

            controls.Add(character.CharacterCardsCollection[handCardIndex].CardPictureBox);

        }

        private void DealCardsToTable(ITable table, int startingDeckCardIndex, IList<ICard> shuffledDeck, Control.ControlCollection Controls)
        {
            int currentTableX = Constants.TableCoordinateX;
            int currentTableY = Constants.TableCoordinateY;

            int distanceBetweenCards = Constants.CardWidth + (Constants.CardWidth / 2);

            int numberOfCardsOnTable = 5;
            int endingCardDeckIndex = startingDeckCardIndex + numberOfCardsOnTable;

            table.TableCardsCollection.Clear();

            for (int i = startingDeckCardIndex; i < endingCardDeckIndex; i++)
            {
                table.TableCardsCollection.Add(shuffledDeck[i]);
            }

            for (int tableCardIndex = 0; tableCardIndex < table.TableCardsCollection.Count; tableCardIndex++)
            {
                table.TableCardsCollection[tableCardIndex].CardPictureBox.Height = Constants.CardHeight;
                table.TableCardsCollection[tableCardIndex].CardPictureBox.Width = Constants.CardWidth;

                table.TableCardsCollection[tableCardIndex].IsVisible = false;
                table.TableCardsCollection[tableCardIndex].CardPictureBox.Image = table.TableCardsCollection[tableCardIndex].BackImage;

                table.TableCardsCollection[tableCardIndex].CardPictureBox.Location = new Point(currentTableX, currentTableY);
                currentTableX += distanceBetweenCards;

                Controls.Add(table.TableCardsCollection[tableCardIndex].CardPictureBox);
            }
        }

        private void DealCardsToBot(ICharacter bot, int firstDeckCardIndex, int secondDeckCardIndex, IList<ICard> shuffledDeck, Control.ControlCollection Controls)
        {      
            bot.CharacterCardsCollection.Clear();
            GiveCard(bot, 0, shuffledDeck, firstDeckCardIndex, Controls);
            GiveCard(bot, 1, shuffledDeck, secondDeckCardIndex, Controls);
            #region backup Code
            //bot.CharacterCardsCollection.Add(shuffledDeck[firstDeckCardIndex]);
            //bot.CharacterCardsCollection[0].CardPictureBox.Height = Constants.CardHeight;
            //bot.CharacterCardsCollection[0].CardPictureBox.Width = Constants.CardWidth;
            //bot.CharacterCardsCollection[0].CardPictureBox.Image = bot.CharacterCardsCollection[0].BackImage;
            //bot.CharacterCardsCollection[0].CardPictureBox.Location = bot.FirstCardLocation;
            //Controls.Add(bot.CharacterCardsCollection[0].CardPictureBox

            //bot.CharacterCardsCollection.Add(shuffledDeck[secondDeckCardIndex]);
            //bot.CharacterCardsCollection[1].CardPictureBox.Height = Constants.CardHeight;
            //bot.CharacterCardsCollection[1].CardPictureBox.Width = Constants.CardWidth;
            //bot.CharacterCardsCollection[1].CardPictureBox.Image = bot.CharacterCardsCollection[0].BackImage;
            //bot.CharacterCardsCollection[1].CardPictureBox.Location = bot.SecondCardLocation;
            //Controls.Add(bot.CharacterCardsCollection[1].CardPictureBox);
            #endregion
        }

        private void ShuffleCards(IList<ICard> deckToBeShuffled)
        {
            Random random = new Random();
            int timesToShuffle = 10;

            for (int i = 0; i <= timesToShuffle; i++)
            {
                for (int cardIndex = 0; cardIndex < deckToBeShuffled.Count; cardIndex++)
                {
                    int randomCardIndex = random.Next(deckToBeShuffled.Count - 1);
                    ICard temporaryCard = (ICard)deckToBeShuffled[randomCardIndex];
                    deckToBeShuffled[randomCardIndex] = deckToBeShuffled[cardIndex];
                    deckToBeShuffled[cardIndex] = temporaryCard;
                }
            }
        }

        public static async Task Finish(int n)
        {
            if (n == 2)
            {
                //FixWinners();
            }
            playerPanel.Visible = false;
            firstBotPanel.Visible = false;
            secondBotPanel.Visible = false;
            thirdBotPanel.Visible = false;
            fourthBotPanel.Visible = false;
            fifthBotPanel.Visible = false;

            call = bigBlind;
            raise = 0;
            foldedPlayers = 5;
            type = 0;
            rounds = 0;

            firstBotPower = 0;
            secondBotPower = 0;
            thirdBotPower = 0;
            fourthBotPower = 0;
            fifthBotPower = 0;
            playerPower = 0;

            playerType = -1;
            raise = 0;

            firstBotType = -1;
            secondBotType = -1;
            thirdBotType = -1;
            fourthBotType = -1;
            fifthBotType = -1;

            B1turn = false;
            B2turn = false;
            B3turn = false;
            B4turn = false;
            B5turn = false;
            botOneFirstTurn = false;
            botTwoFirstTurn = false;
            botThreeFirstTurn = false;
            botFourFirstTurn = false;
            botFiveFirstTurn = false;

            playerFolded = false;
            botOneFolded = false;
            botTwoFolded = false;
            botThreeFolded = false;
            b4Folded = false;
            b5Folded = false;

            PlayerFirstTurn = false;
            playerTurn = true;
            restart = false;
            isRaising = false;

            playerCall = 0;
            firstBotCall = 0;
            secondBotCall = 0;
            thirdBotCall = 0;
            fourthBotCall = 0;
            fifthBotCall = 0;

            playerRise = 0;
            firstBotRise = 0;
            secondBotRise = 0;
            thirdBotRise = 0;
            fourthBotRise = 0;
            fifthBotRise = 0;

            height = 0;
            width = 0;

            winners = 0;

            Flop = 1;
            Turn = 2;
            River = 3;
            End = 4;
            maxLeft = 6;

            last = 123;
            raisedTurn = 1;

            bools.Clear();
            //CheckWinners.Clear();
            //ints.Clear();
            //Win.Clear();
            //sorted.Current = 0;
            //sorted.Power = 0;
            //potChips.Text = "0";

            t = 60;
            up = 10000000;
            turnCount = 0;

            playerStatus.Text = "";
            firstBotStatus.Text = "";
            secondBotStatus.Text = "";
            thirdBotStatus.Text = "";
            fourthBotStatus.Text = "";
            fifthBotStatus.Text = "";

            if (Chips <= 0)
            {

                /* var f2 = new AddChips();
                 f2.ShowDialog();
                 if (f2.a != 0)
                 {
                     Chips = f2.a;
                     firstBotChips += f2.a;
                     secondBotChips += f2.a;
                     thirdBotChips += f2.a;
                     fourthBotChips += f2.a;
                     fifthBotChips += f2.a;
                     PlayerFirstTurn = false;
                     playerTurn = true;
                     raiseButton.Enabled = true;
                     foldButton.Enabled = true;
                     checkButton.Enabled = true;
                     raiseButton.Text = "raise";
                 }*/
            }

            ImgLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);
            for (var os = 0; os < 17; os++)
            {
                Holder[os].Image = null;
                Holder[os].Invalidate();
                Holder[os].Visible = false;
            }
            //await SetupGame();
            //await Turns();
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

        public void SetGameRules(
            IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection,
            ICharacter character)
        {
            if (!playerStatus.Contains(new Control("Fold")))
            {
                CheckForOnePair(charactersCardsCollection, tableCardsCollection, character, false);

                CheckForTwoPairs(charactersCardsCollection, tableCardsCollection, character);

                CheckForThreeOfAKind(charactersCardsCollection, tableCardsCollection, character);

                CheckForStraight(charactersCardsCollection, tableCardsCollection, character);

                CheckForFlush(charactersCardsCollection, tableCardsCollection, character);

                CheckForFullHouse(charactersCardsCollection, tableCardsCollection, character);

                CheckForFourOfAKind(charactersCardsCollection, tableCardsCollection, character);

                CheckForStraightFlushOfSpades(charactersCardsCollection, tableCardsCollection, character);
                CheckForStraightFlushOfDiamonds(charactersCardsCollection, tableCardsCollection, character);
                CheckForStraightFlushOfHearts(charactersCardsCollection, tableCardsCollection, character);
                CheckForStraightFlushOfClubs(charactersCardsCollection, tableCardsCollection, character);

                CheckForHighCard(charactersCardsCollection, tableCardsCollection, character);
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
        private bool CheckForStraightFlushOfClubs(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character)
        {
            bool hasStraightFlush = false;

            List<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            List<ICard> straightFlushCardsCollection = joinedCardCollection.Where(c => c.Suit == CardSuit.Clubs).ToList();

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
        private bool CheckForStraightFlushOfDiamonds(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character)
        {
            bool hasStraightFlush = false;

            List<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            List<ICard> straightFlushCardsCollection = joinedCardCollection.Where(c => c.Suit == CardSuit.Diamonds).ToList();

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
        private bool CheckForStraightFlushOfHearts(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character)
        {
            bool hasStraightFlush = false;

            List<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            List<ICard> straightFlushCardsCollection = joinedCardCollection.Where(c => c.Suit == CardSuit.Hearts).ToList();

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
        private bool CheckForStraightFlushOfSpades(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character)
        {
            bool hasStraightFlush = false;

            List<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            List<ICard> straightFlushCardsCollection = joinedCardCollection.Where(c => c.Suit == CardSuit.Spades).ToList();

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
        /// This method checks if the character has card combination "Straight"
        /// </summary>
        /// <param name="charactersCardsCollection">The collection of cards in the characters hand.</param>
        /// <param name="tableCardsCollection">The collection of cards on the table.</param>
        /// <param name="character">The character that holds the cards.</param>
        /// <returns><c>true</c> if the character has a Straight, <c>false</c> if they don't.</returns>     
        private bool CheckForStraight(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection,
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

                RegisterCombination(character, power, straightCombinationCards,
                    theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.Straight,
                    Constants.StraightBehaviourPower);
            }

            return hasStraight;

        }


        /// <summary>
        /// This method checks if the character has card combination "Flush"
        /// </summary>
        /// <param name="charactersCardsCollection">The collection of cards in the characters hand.</param>
        /// <param name="tableCardsCollection">The collection of cards on the table.</param>
        /// <param name="character">The character that holds the cards.</param>
        /// <returns><c>true</c> if the character has a Flush, <c>false</c> if they don't.</returns>
        private bool CheckForFlush(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection,
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

                    RegisterCombination(character, power, cardsThatMakeUpFlush, theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.Flush, currentFlushBehaviourPower);

                }
            }
            return hasFlush;
        }


        /// <summary>
        /// Checks if the cards on the table make a flush without the cards from the characters hand.
        /// </summary>
        /// <param name="charactersCardsCollection">The cards in the characters hand.</param>
        /// <param name="tableCardsThatMakeUpFlush">The table cards that make up flush.</param>
        /// <param name="joinedCardCollection">The collection of all table cards and the character's hand cards.</param>
        /// <param name="character">The character.</param>
        /// <returns><c>true</c> if the table cards make a Flush, <c>false</c> if they dont.</returns>    
        private bool CheckForFlushIfTableCardsMakeFlush(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsThatMakeUpFlush, IList<ICard> joinedCardCollection, ICharacter character)
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
            RegisterCombination(character, power, cardsThatMakeUpFlush, theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.Flush, currentFlushBehaviourPower);

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
        private bool CheckForFourOfAKind(
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

                    RegisterCombination(character, power, sameRankCardsCollection, theOtherCardsFromTheHandNotIncludedInTheCombination, CombinationType.FourOfAKind, Constants.FourOfAKindBehavourPower);

                    return true;
                }
            }

            return false;
        }



        /// <summary>
        /// This method checks if the character has card combination "Full House"
        /// </summary>
        /// <param name="charactersCardsCollection">The collection of cards in the characters hand.</param>
        /// <param name="tableCardsCollection">The collection of cards on the table.</param>
        /// <param name="character">The character that holds the cards.</param>
        /// <returns><c>true</c> if the character has a Full House, <c>false</c> if they don't.</returns>
        private bool CheckForFullHouse(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection,
            ICharacter character)
        {
            bool hasFullHouse = false;

            IList<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            bool characterHasThreeOfAKind = CheckForThreeOfAKind(charactersCardsCollection, tableCardsCollection,
                character);

            IList<ICard> threeOfAKindCards = new List<ICard>();

            int threeOfAKindRank = -1;

            if (characterHasThreeOfAKind)
            {
                threeOfAKindRank = GetThreeOfAKindCardRank(charactersCardsCollection, tableCardsCollection);

                //removes the three-of-a-kind cards from the joinedCardCollection (hand+table cards)
                // and adds them to the threeOfAKindCards list
                for (int i = 0; i < joinedCardCollection.Count; i++)
                {
                    if ((int)joinedCardCollection[i].Rank == threeOfAKindRank)
                    {
                        threeOfAKindCards.Add(joinedCardCollection[i]);
                        joinedCardCollection.RemoveAt(i);
                        i--;
                    }
                }


                //checks if there is a pair in the remaining collection
                //if yes -> the player has a full house combination
                int maxPairRank = -1;
                foreach (ICard card in joinedCardCollection)
                {
                    IList<ICard> remainingEqualRankCards =
                        joinedCardCollection.Where(x => x.Rank == card.Rank).ToList();

                    if (remainingEqualRankCards.Count == 2)
                    {
                        hasFullHouse = true;

                        //This is a check for multiple pairs in the remaining cards
                        //If there is more than one pair, the highest one is taken
                        maxPairRank = Math.Max(maxPairRank, (int)card.Rank); //  take the one with the higher rank

                        IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                            joinedCardCollection.Where(x => x != remainingEqualRankCards[0]).ToList();

                        IList<ICard> fullHouseCards = threeOfAKindCards;
                        fullHouseCards = fullHouseCards.Union(remainingEqualRankCards).ToList();


                        double power = maxPairRank * 2 + FullHouseBehaviourPower * 100;

                        if (character.CardsCombination == null ||
                            character.CardsCombination.Type < CombinationType.FullHouse)
                        {
                            character.CardsCombination = new Combination(power, CombinationType.FullHouse, Constants.FullHouseBehaviourPower, fullHouseCards, theOtherCardsFromTheHandNotIncludedInTheCombination);
                        }

                    }
                }
            }

            return hasFullHouse;
        }

        //This method gets the rank (number) of the cards that make up a three-of-a-kind
        private int GetThreeOfAKindCardRank(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection)
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

        /// <summary>
        /// Checks if the character has "Three-of-a-kind" card combination.
        /// </summary>
        /// <param name="charactersCardsCollection"></param>
        /// <param name="tableCardsCollection"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool CheckForThreeOfAKind(IEnumerable<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection, ICharacter character)
        {
            IList<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            foreach (var element in joinedCardCollection)
            {
                IList<ICard> sameRankCardsCollection = joinedCardCollection.Where(x => x.Rank == element.Rank).ToList();

                if (sameRankCardsCollection.Count == 3)
                {
                    double power = (int)sameRankCardsCollection[0].Rank * 3 + ThreeOfAKindBehaviourPower * 100;

                    IList<ICard> nonCombinationCardsCollection = joinedCardCollection.Where(x => !sameRankCardsCollection.Contains(x)).ToList();

                    RegisterCombination(character, power, sameRankCardsCollection, nonCombinationCardsCollection, CombinationType.ThreeOfAKind, Constants.ThreeOfAKindBehaviourPower);

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Registers the combination which is found to the character.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="power"></param>
        /// <param name="combinationCardsCollection"></param>
        /// <param name="nonCombinationCardsCollection"></param>
        /// <param name="combinationType"></param>
        /// <param name="behaviourPower"></param>
        private void RegisterCombination(ICharacter character, double power, IList<ICard> combinationCardsCollection,
            IList<ICard> nonCombinationCardsCollection, CombinationType combinationType, double behaviourPower)
        {
            IList<ICard> kickersCollection = new List<ICard>();

            if (character.CardsCombination == null || character.CardsCombination.Type < combinationType || character.CardsCombination.Power < power)
            {
                if (combinationCardsCollection.Count < 5)
                {
                    int nonCombinationCardsSize = 5 - combinationCardsCollection.Count;

                    nonCombinationCardsCollection = nonCombinationCardsCollection.OrderByDescending(x => x.Rank).ToList();

                    kickersCollection = nonCombinationCardsCollection.Take(nonCombinationCardsSize).ToList();
                }

                character.CardsCombination = new Combination(power, combinationType, behaviourPower, combinationCardsCollection, kickersCollection);
            }
        }


        /// <summary>
        /// Checks for a "High card" combination
        /// </summary>
        /// <param name="charactersCardsCollection"></param>
        /// <param name="tableCardsCollection"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool CheckForHighCard(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection, ICharacter character)
        {
            double power = Math.Max((double)charactersCardsCollection[0].Rank, (double)charactersCardsCollection[1].Rank);

            IList<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).OrderByDescending(x => x.Rank).ToList();

            IList<ICard> combinationCardsCollection = new List<ICard>();
            combinationCardsCollection.Add(joinedCardCollection[0]);

            IList<ICard> nonCombinationCards = joinedCardCollection.Where(x => !combinationCardsCollection.Contains(x)).ToList();

            RegisterCombination(character, power, combinationCardsCollection, nonCombinationCards, CombinationType.HighCard, Constants.HighCardBehaviourPower);

            return true;
        }

        /// <summary>
        /// Checks if the two character's cards make a "Pair" or if one of the character's cards makes a "Pair" with one card from the table.
        /// </summary>
        /// <param name="charactersCardsCollection"></param>
        /// <param name="tableCardsCollection"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool CheckForOnePair(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection, ICharacter character, bool isCheckingForASecondPair)
        {
            IList<ICombination> combinationsCollection = new List<ICombination>();

            bool foundOnePair = false;
            bool foundASecondPair = false;

            IList<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.IsVisible)).ToList();

            FindAllOnePairCombinations(joinedCardCollection, combinationsCollection);

            combinationsCollection = combinationsCollection.OrderByDescending(x => x.Power).ToList();

            if (isCheckingForASecondPair)
            {
                if (combinationsCollection.Count >= 1)
                {
                    foundASecondPair = true;
                }

                if (foundASecondPair)
                {
                    RegisterTwoPairs(character, combinationsCollection);
                }
            }
            else
            {
                if (combinationsCollection.Count >= 1)
                {
                    foundOnePair = true;
                    RegisterOnePair(character, combinationsCollection);
                }
            }

            bool foundAPairOrPairs = foundOnePair || foundASecondPair;

            return foundAPairOrPairs;
        }

        private void RegisterOnePair(ICharacter character, IList<ICombination> combinationsCollection)
        {
            double power = combinationsCollection[0].Power;

            IList<ICard> sameRankCardsCollection = combinationsCollection[0].CombinationCardsCollection;
            IList<ICard> nonCombinationCardsCollection =
                combinationsCollection[0].KickersCollection;

            RegisterCombination(character, power, sameRankCardsCollection, nonCombinationCardsCollection,
                CombinationType.OnePair, OnePairBehaviourPower);
        }

        private void RegisterTwoPairs(ICharacter character, IList<ICombination> combinationsCollection)
        {
            IList<ICard> sameRankCardsCollection =
                character.CardsCombination.CombinationCardsCollection.Union(
                    combinationsCollection[0].CombinationCardsCollection).ToList();

            IList<ICard> nonCombinationCardsCollection =
                combinationsCollection[0].KickersCollection.Where(
                    x => !character.CardsCombination.CombinationCardsCollection.Contains(x)).ToList();
            double power = DetermineTwoPairsPower(character, sameRankCardsCollection);

            RegisterCombination(character, power, sameRankCardsCollection, nonCombinationCardsCollection,
                CombinationType.TwoPair, TwoPairsBehaviourPower);
        }

        private void FindAllOnePairCombinations(IList<ICard> joinedCardCollection, IList<ICombination> combinationsCollection)
        {
            foreach (var element in joinedCardCollection)
            {
                IList<ICard> sameRankCardsCollection = joinedCardCollection.Where(x => x.Rank == element.Rank).ToList();

                if (sameRankCardsCollection.Count == 2)
                {
                    double power = (int)sameRankCardsCollection[0].Rank * 2 + OnePairBehaviourPower * 100;

                    IList<ICard> nonCombinationCardsCollection =
                        joinedCardCollection.Where(x => !sameRankCardsCollection.Contains(x)).ToList();

                    combinationsCollection.Add(new Combination(power, CombinationType.OnePair, OnePairBehaviourPower,
                        sameRankCardsCollection, nonCombinationCardsCollection));
                }
            }
        }

        /// <summary>
        /// Checks if the character has two pairs.
        /// </summary>
        /// <param name="charactersCardsCollection"></param>
        /// <param name="tableCardsCollection"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool CheckForTwoPairs(IList<ICard> charactersCardsCollection,
        IList<ICard> tableCardsCollection, ICharacter character)
        {
            bool hasOnePair = CheckForOnePair(charactersCardsCollection, tableCardsCollection, character, false);

            bool hasASecondPair = false;

            if (hasOnePair)
            {
                IList<ICard> nonCombinationCards = charactersCardsCollection.Union(tableCardsCollection).Where(x => !character.CardsCombination.CombinationCardsCollection.Contains(x)).ToList();

                IList<ICard> emptyCollection = new List<ICard>();

                hasASecondPair = CheckForOnePair(nonCombinationCards, emptyCollection, character, true);
            }


            return hasASecondPair;
        }

        /// <summary>
        /// Determines the power of the hand in case of two pairs.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="sameRankCardsCollection"></param>
        /// <returns></returns>
        private double DetermineTwoPairsPower(ICharacter character, IList<ICard> sameRankCardsCollection)
        {
            double power = 0;

            if (character.CardsCombination.CombinationCardsCollection[0].Rank == CardRank.Ace)
            {
                power = (int)sameRankCardsCollection[0].Rank * 4 +
                        (int)sameRankCardsCollection[1].Rank * 2 +
                        TwoPairsBehaviourPower * 100;
            }
            else if (character.CardsCombination.CombinationCardsCollection[1].Rank == CardRank.Ace)
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

        public void DeclareWinner(IList<ICharacter> gameCharacters, int pot)
        {
            string winMessage = DetermineTheWinner(gameCharacters, pot);

            if (winMessage.Contains(","))
            {
                PrintSeveralWinnersMessage(winMessage);
            }
            else
            {
                PrintOneWinnerMessage(winMessage);
            }

        }

        private void PrintSeveralWinnersMessage(string winMessage)
        {
            MessageBox.Show("The winners are:" + winMessage);
        }

        /// <summary>
        /// After all cards are down, this method chooses the winner
        /// </summary>
        /// <param name="gameCharacters">All particialnts in the game.</param>
        /// <param name="pot">The pot chips.</param>
        private string DetermineTheWinner(IList<ICharacter> gameCharacters, int pot)
        {
            IList<ICharacter> activeParticiapnts = gameCharacters.Where(x => !x.HasFolded).ToList();

            activeParticiapnts = activeParticiapnts.OrderByDescending(x => x.CardsCombination.Type).ToList();

            IList<ICharacter> topCombinationCharactersCollection = activeParticiapnts.Where(x => x.CardsCombination.Type == activeParticiapnts[0].CardsCombination.Type).ToList();

            //If there is only 1 participant with the highest combination, he/she wins.
            if (topCombinationCharactersCollection.Count == 1)
            {
                ICharacter winner = topCombinationCharactersCollection[0];

                string winMessage = winner.Name + " " + winner.CardsCombination.Type;

                PayPrizeToTheWinner(pot, winner);

                return winMessage;
            }
            else
            {
                bool equalScore = true;

                equalScore = DetermineIfEqual(topCombinationCharactersCollection, equalScore);

                if (equalScore)
                {
                    //All participants who have the top combination, have all equal cards. Therefore, all of them are winners.
                    PayPrizeToTheWinners(pot, topCombinationCharactersCollection);

                    string winMessage = ConstructWinnersMessage(topCombinationCharactersCollection);

                    return winMessage;
                }
                else
                {
                    ICharacter winner = ChooseTheWinnerByTheCardsRank(topCombinationCharactersCollection);
                    string winMessage = winner.Name + " " + winner.CardsCombination.Type;

                    PayPrizeToTheWinner(pot, winner);

                    return winMessage;
                }
            }
        }

        private void PrintOneWinnerMessage(string winMessage)
        {
            MessageBox.Show("The winner is:" + winMessage);
        }

        /// <summary>
        /// Chooses the winner, comparing the ranks.
        /// </summary>
        /// <param name="topCombinationCharactersCollection"></param>
        /// <returns></returns>
        private ICharacter ChooseTheWinnerByTheCardsRank(IList<ICharacter> topCombinationCharactersCollection)
        {
            topCombinationCharactersCollection =
                topCombinationCharactersCollection.OrderByDescending(x => x.CardsCombination.Hand[0].Rank).
                    ThenByDescending(x => x.CardsCombination.Hand[1].Rank).
                    ThenByDescending(x => x.CardsCombination.Hand[2].Rank).
                    ThenByDescending(x => x.CardsCombination.Hand[3].Rank).
                    ThenByDescending(x => x.CardsCombination.Hand[4].Rank).ToList();

            ICharacter winner = topCombinationCharactersCollection[0];

            return winner;
        }

        /// <summary>
        /// Gets the names of the winners.
        /// </summary>
        /// <param name="topCombinationCharactersCollection"></param>
        private string ConstructWinnersMessage(IList<ICharacter> topCombinationCharactersCollection)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < topCombinationCharactersCollection.Count; i++)
            {
                sb.Append(topCombinationCharactersCollection[i].Name);
                sb.Append(", ");
            }

            string winnersParameters = sb.ToString().Substring(0, sb.Length - 2);

            return winnersParameters;
        }

        /// <summary>
        /// Increases the winner's chips with the pot.
        /// </summary>
        /// <param name="pot"></param>
        /// <param name="winner"></param>
        private void PayPrizeToTheWinner(int pot, ICharacter winner)
        {
            winner.Chips += pot;
        }

        /// <summary>
        /// Divides the pot equally between the winners. 
        /// </summary>
        /// <param name="pot"></param>
        /// <param name="topCombinationCharactersCollection"></param>
        private void PayPrizeToTheWinners(int pot, IList<ICharacter> topCombinationCharactersCollection)
        {
            int chipsPerCharacter = pot / topCombinationCharactersCollection.Count;

            foreach (var element in topCombinationCharactersCollection)
            {
                element.Chips += chipsPerCharacter;
            }

            //If there is a fraction part, it goes to the participant closer to the dealer.
            int fractionPart = pot % topCombinationCharactersCollection.Count;

            topCombinationCharactersCollection = topCombinationCharactersCollection.OrderByDescending(x => x.Name).ToList();

            topCombinationCharactersCollection[0].Chips += fractionPart;
        }

        /// <summary>
        /// Checks if the participants with the same top combination have alse the same 5 cards as ranks.
        /// </summary> 
        /// <param name="topCombinationCharactersCollection"></param>
        /// <param name="equalScore"></param>
        /// <returns></returns>
        private bool DetermineIfEqual(IList<ICharacter> topCombinationCharactersCollection, bool equalScore)
        {
            for (int cardNumber = 0; cardNumber < 5; cardNumber++)
            {
                for (int characterNumber = 0; characterNumber < topCombinationCharactersCollection.Count - 1; characterNumber++)
                {
                    if (topCombinationCharactersCollection[characterNumber].CardsCombination.Hand[cardNumber].Rank !=
                        topCombinationCharactersCollection[characterNumber + 1].CardsCombination.Hand[cardNumber].Rank)
                    {
                        equalScore = false;
                    }
                }
            }
            return equalScore;
        }


    }
}