// ***********************************************************************
// Assembly         : Poker
// Author           : Team "Currant"
// ***********************************************************************
// <copyright file="Poker" team="Currant">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //bools.Add(PlayerFirstTurn); bools.Add(botOneFirstTurn); bools.Add(botTwoTurn); bools.Add(botThreeFirstTurn); bools.Add(botFourFirstTurn); bools.Add(botFiveFirstTurn);
            call = bigBlind;
            MaximizeBox = false;
            MinimizeBox = false;

            Updates.Start();
            InitializeComponent();

            this.width = Width;
            this.height = Height;

            Shuffle();

            potChips.Enabled = false;
            tableChips.Enabled = false;
            tableBot1Chips.Enabled = false;
            tableBot2Chips.Enabled = false;
            tableBot3Chips.Enabled = false;
            tableBot4Chips.Enabled = false;
            tableBot5Chips.Enabled = false;

            tableChips.Text = "Chips : " + Chips;
            tableBot1Chips.Text = "Chips : " + firstBotChips;
            tableBot2Chips.Text = "Chips : " + secondBotChips;
            tableBot3Chips.Text = "Chips : " + thirdBotChips;
            tableBot4Chips.Text = "Chips : " + fourthBotChips;
            tableBot5Chips.Text = "Chips : " + fifthBotChips;
            timer.Interval = 1 * 1 * 1000;
            timer.Tick += timer_Tick;
            Updates.Interval = 1 * 1 * 100;
            Updates.Tick += Update_Tick;

            bigBlindSum.Visible = true;
            smallBlindSum.Visible = true;
            bigBlindButton.Visible = true;
            smallBlindButton.Visible = true;
            bigBlindSum.Visible = true;
            smallBlindSum.Visible = true;
            bigBlindButton.Visible = true;
            smallBlindButton.Visible = true;
            bigBlindSum.Visible = false;
            smallBlindSum.Visible = false;
            bigBlindButton.Visible = false;
            smallBlindButton.Visible = false;
            tbRaise.Text = (bigBlind * 2).ToString();

        }

        //this method is shuffling the cards
        private async Task Shuffle()
        {
            bools.Add(PlayerFirstTurn);
            bools.Add(botOneFirstTurn);
            bools.Add(botTwoTurn);
            bools.Add(botThreeFirstTurn);
            bools.Add(botFourFirstTurn);
            bools.Add(botFiveFirstTurn);
            callButton.Enabled = false;
            raiseButton.Enabled = false;
            foldButton.Enabled = false;
            checkButton.Enabled = false;
            MaximizeBox = false;
            MinimizeBox = false;
            var check = false;
            var backImage = new Bitmap("Assets\\Back\\Back.png");
            int horizontal = 580, vertical = 480;
            var r = new Random();

            for (i = ImgLocation.Length; i > 0; i--)
            {
                var j = r.Next(i);
                var k = ImgLocation[j];
                ImgLocation[j] = ImgLocation[i - 1];
                ImgLocation[i - 1] = k;
            }

            for (i = 0; i < 17; i++)
            {
                Deck[i] = Image.FromFile(ImgLocation[i]);
                var charsToRemove = new[] { "Assets\\Cards\\", ".png" };
                foreach (var c in charsToRemove)
                {
                    ImgLocation[i] = ImgLocation[i].Replace(c, string.Empty);
                }
                Reserve[i] = int.Parse(ImgLocation[i]) - 1;
                Holder[i] = new PictureBox();
                Holder[i].SizeMode = PictureBoxSizeMode.StretchImage;
                Holder[i].Height = 130;
                Holder[i].Width = 80;
                Controls.Add(Holder[i]);
                Holder[i].Name = "pb" + i;
                await Task.Delay(200);

                #region Throwing Cards

                if (i < 2)
                {
                    if (Holder[0].Tag != null)
                    {
                        Holder[1].Tag = Reserve[1];
                    }
                    Holder[0].Tag = Reserve[0];
                    Holder[i].Image = Deck[i];
                    Holder[i].Anchor = AnchorStyles.Bottom;
                    //Holder[i].Dock = DockStyle.Top;
                    Holder[i].Location = new Point(horizontal, vertical);
                    horizontal += Holder[i].Width;
                    Controls.Add(playerPanel);
                    playerPanel.Location = new Point(Holder[0].Left - 10, Holder[0].Top - 10);
                    playerPanel.BackColor = Color.DarkBlue;
                    playerPanel.Height = 150;
                    playerPanel.Width = 180;
                    playerPanel.Visible = false;
                }
                if (firstBotChips > 0)
                {
                    foldedPlayers--;
                    if (i >= 2 && i < 4)
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
                        Holder[i].Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                        Holder[i].Image = backImage;
                        //Holder[i].Image = Deck[i];
                        Holder[i].Location = new Point(horizontal, vertical);
                        horizontal += Holder[i].Width;
                        Holder[i].Visible = true;
                        Controls.Add(firstBotPanel);
                        firstBotPanel.Location = new Point(Holder[2].Left - 10, Holder[2].Top - 10);
                        firstBotPanel.BackColor = Color.DarkBlue;
                        firstBotPanel.Height = 150;
                        firstBotPanel.Width = 180;
                        firstBotPanel.Visible = false;
                        if (i == 3)
                        {
                            check = false;
                        }
                    }
                }
                if (secondBotChips > 0)
                {
                    foldedPlayers--;
                    if (i >= 4 && i < 6)
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
                        Holder[i].Anchor = AnchorStyles.Top | AnchorStyles.Left;
                        Holder[i].Image = backImage;
                        //Holder[i].Image = Deck[i];
                        Holder[i].Location = new Point(horizontal, vertical);
                        horizontal += Holder[i].Width;
                        Holder[i].Visible = true;
                        Controls.Add(secondBotPanel);
                        secondBotPanel.Location = new Point(Holder[4].Left - 10, Holder[4].Top - 10);
                        secondBotPanel.BackColor = Color.DarkBlue;
                        secondBotPanel.Height = 150;
                        secondBotPanel.Width = 180;
                        secondBotPanel.Visible = false;
                        if (i == 5)
                        {
                            check = false;
                        }
                    }
                }
                if (thirdBotChips > 0)
                {
                    foldedPlayers--;
                    if (i >= 6 && i < 8)
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
                        Holder[i].Anchor = AnchorStyles.Top;
                        Holder[i].Image = backImage;
                        //Holder[i].Image = Deck[i];
                        Holder[i].Location = new Point(horizontal, vertical);
                        horizontal += Holder[i].Width;
                        Holder[i].Visible = true;
                        Controls.Add(thirdBotPanel);
                        thirdBotPanel.Location = new Point(Holder[6].Left - 10, Holder[6].Top - 10);
                        thirdBotPanel.BackColor = Color.DarkBlue;
                        thirdBotPanel.Height = 150;
                        thirdBotPanel.Width = 180;
                        thirdBotPanel.Visible = false;
                        if (i == 7)
                        {
                            check = false;
                        }
                    }
                }
                if (fourthBotChips > 0)
                {
                    foldedPlayers--;
                    if (i >= 8 && i < 10)
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
                        Holder[i].Anchor = AnchorStyles.Top | AnchorStyles.Right;
                        Holder[i].Image = backImage;
                        //Holder[i].Image = Deck[i];
                        Holder[i].Location = new Point(horizontal, vertical);
                        horizontal += Holder[i].Width;
                        Holder[i].Visible = true;
                        Controls.Add(fourthBotPanel);
                        fourthBotPanel.Location = new Point(Holder[8].Left - 10, Holder[8].Top - 10);
                        fourthBotPanel.BackColor = Color.DarkBlue;
                        fourthBotPanel.Height = 150;
                        fourthBotPanel.Width = 180;
                        fourthBotPanel.Visible = false;
                        if (i == 9)
                        {
                            check = false;
                        }
                    }
                }
                if (fifthBotChips > 0)
                {
                    foldedPlayers--;
                    if (i >= 10 && i < 12)
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
                        Holder[i].Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                        Holder[i].Image = backImage;
                        //Holder[i].Image = Deck[i];
                        Holder[i].Location = new Point(horizontal, vertical);
                        horizontal += Holder[i].Width;
                        Holder[i].Visible = true;
                        Controls.Add(fifthBotPanel);
                        fifthBotPanel.Location = new Point(Holder[10].Left - 10, Holder[10].Top - 10);
                        fifthBotPanel.BackColor = Color.DarkBlue;
                        fifthBotPanel.Height = 150;
                        fifthBotPanel.Width = 180;
                        fifthBotPanel.Visible = false;
                        if (i == 11)
                        {
                            check = false;
                        }
                    }
                }
                if (i >= 12)
                {
                    Holder[12].Tag = Reserve[12];
                    if (i > 12) Holder[13].Tag = Reserve[13];
                    if (i > 13) Holder[14].Tag = Reserve[14];
                    if (i > 14) Holder[15].Tag = Reserve[15];
                    if (i > 15)
                    {
                        Holder[16].Tag = Reserve[16];
                    }
                    if (!check)
                    {
                        horizontal = 410;
                        vertical = 265;
                    }
                    check = true;
                    if (Holder[i] != null)
                    {
                        Holder[i].Anchor = AnchorStyles.None;
                        Holder[i].Image = backImage;
                        //Holder[i].Image = Deck[i];
                        Holder[i].Location = new Point(horizontal, vertical);
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
                    if (i == 3)
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
                    botTwoTurn = true;
                    Holder[4].Visible = false;
                    Holder[5].Visible = false;
                }
                else
                {
                    botTwoTurn = false;
                    if (i == 5)
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
                    if (i == 7)
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
                    if (i == 9)
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
                    if (i == 11)
                    {
                        if (Holder[11] != null)
                        {
                            Holder[10].Visible = true;
                            Holder[11].Visible = true;
                        }
                    }
                }

                if (i == 16)
                {
                    if (!restart)
                    {
                        MaximizeBox = true;
                        MinimizeBox = true;
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

            if (i == 17)
            {
                raiseButton.Enabled = true;
                callButton.Enabled = true;
                raiseButton.Enabled = true;
                raiseButton.Enabled = true;
                foldButton.Enabled = true;
            }
        }

        private async Task Turns()
        {
            #region Rotating

            if (!PlayerFirstTurn)
            {
                if (playerTurn)
                {
                    FixCall(playerStatus, ref playerCall, ref playerRise, 1);
                    //MessageBox.Show("Player's Turn");
                    progressBarTimer.Visible = true;
                    progressBarTimer.Value = 1000;
                    t = 60;
                    up = 10000000;
                    timer.Start();
                    raiseButton.Enabled = true;
                    callButton.Enabled = true;
                    raiseButton.Enabled = true;
                    raiseButton.Enabled = true;
                    foldButton.Enabled = true;
                    turnCount++;
                    FixCall(playerStatus, ref playerCall, ref playerRise, 2);
                }
            }
            if (PlayerFirstTurn || !playerTurn)
            {
                await AllIn();
                if (PlayerFirstTurn && !playerFolded)
                {
                    if (callButton.Text.Contains("All in") == false || raiseButton.Text.Contains("All in") == false)
                    {
                        bools.RemoveAt(0);
                        bools.Insert(0, null);
                        maxLeft--;
                        playerFolded = true;
                    }
                }
                await CheckRaise(0, 0);
                progressBarTimer.Visible = false;
                raiseButton.Enabled = false;
                callButton.Enabled = false;
                raiseButton.Enabled = false;
                raiseButton.Enabled = false;
                foldButton.Enabled = false;
                timer.Stop();
                B1turn = true;
                if (!botOneFirstTurn)
                {
                    if (B1turn)
                    {
                        FixCall(firstBotStatus, ref firstBotCall, ref firstBotRise, 1);
                        FixCall(firstBotStatus, ref firstBotCall, ref firstBotRise, 2);
                        Rules_ToBeDeleted_NewName_SetGameRules(2, 3, "Bot 1", ref firstBotType, ref firstBotPower, botOneFirstTurn);
                        MessageBox.Show("Bot 1's Turn");
                        AI(2, 3, ref firstBotChips, ref B1turn, ref botOneFirstTurn, firstBotStatus, 0, firstBotPower,
                            firstBotType);
                        turnCount++;
                        last = 1;
                        B1turn = false;
                        B2turn = true;
                    }
                }
                if (botOneFirstTurn && !botOneFolded)
                {
                    bools.RemoveAt(1);
                    bools.Insert(1, null);
                    maxLeft--;
                    botOneFolded = true;
                }
                if (botOneFirstTurn || !B1turn)
                {
                    await CheckRaise(1, 1);
                    B2turn = true;
                }
                if (!botTwoTurn)
                {
                    if (B2turn)
                    {
                        FixCall(secondBotStatus, ref secondBotCall, ref secondBotRise, 1);
                        FixCall(secondBotStatus, ref secondBotCall, ref secondBotRise, 2);
                        Rules_ToBeDeleted_NewName_SetGameRules(4, 5, "Bot 2", ref secondBotType, ref secondBotPower, botTwoTurn);
                        MessageBox.Show("Bot 2's Turn");
                        AI(4, 5, ref secondBotChips, ref B2turn, ref botTwoTurn, secondBotStatus, 1, secondBotPower,
                            secondBotType);
                        turnCount++;
                        last = 2;
                        B2turn = false;
                        B3turn = true;
                    }
                }
                if (botTwoTurn && !botTwoFolded)
                {
                    bools.RemoveAt(2);
                    bools.Insert(2, null);
                    maxLeft--;
                    botTwoFolded = true;
                }
                if (botTwoTurn || !B2turn)
                {
                    await CheckRaise(2, 2);
                    B3turn = true;
                }
                if (!botThreeFirstTurn)
                {
                    if (B3turn)
                    {
                        FixCall(thirdBotStatus, ref thirdBotCall, ref thirdBotRise, 1);
                        FixCall(thirdBotStatus, ref thirdBotCall, ref thirdBotRise, 2);
                        Rules_ToBeDeleted_NewName_SetGameRules(6, 7, "Bot 3", ref thirdBotType, ref thirdBotPower, botThreeFirstTurn);
                        MessageBox.Show("Bot 3's Turn");
                        AI(6, 7, ref thirdBotChips, ref B3turn, ref botThreeFirstTurn, thirdBotStatus, 2, thirdBotPower,
                            thirdBotType);
                        turnCount++;
                        last = 3;
                        B3turn = false;
                        B4turn = true;
                    }
                }
                if (botThreeFirstTurn && !botThreeFolded)
                {
                    bools.RemoveAt(3);
                    bools.Insert(3, null);
                    maxLeft--;
                    botThreeFolded = true;
                }
                if (botThreeFirstTurn || !B3turn)
                {
                    await CheckRaise(3, 3);
                    B4turn = true;
                }
                if (!botFourFirstTurn)
                {
                    if (B4turn)
                    {
                        FixCall(fourthBotStatus, ref fourthBotCall, ref fourthBotRise, 1);
                        FixCall(fourthBotStatus, ref fourthBotCall, ref fourthBotRise, 2);
                        Rules_ToBeDeleted_NewName_SetGameRules(8, 9, "Bot 4", ref fourthBotType, ref fourthBotPower, botFourFirstTurn);
                        MessageBox.Show("Bot 4's Turn");
                        AI(8, 9, ref fourthBotChips, ref B4turn, ref botFourFirstTurn, fourthBotStatus, 3,
                            fourthBotPower, fourthBotType);
                        turnCount++;
                        last = 4;
                        B4turn = false;
                        B5turn = true;
                    }
                }
                if (botFourFirstTurn && !b4Folded)
                {
                    bools.RemoveAt(4);
                    bools.Insert(4, null);
                    maxLeft--;
                    b4Folded = true;
                }
                if (botFourFirstTurn || !B4turn)
                {
                    await CheckRaise(4, 4);
                    B5turn = true;
                }
                if (!botFiveFirstTurn)
                {
                    if (B5turn)
                    {
                        FixCall(fifthBotStatus, ref fifthBotCall, ref fifthBotRise, 1);
                        FixCall(fifthBotStatus, ref fifthBotCall, ref fifthBotRise, 2);
                        Rules_ToBeDeleted_NewName_SetGameRules(10, 11, "Bot 5", ref fifthBotType, ref fifthBotPower, botFiveFirstTurn);
                        MessageBox.Show("Bot 5's Turn");
                        AI(10, 11, ref fifthBotChips, ref B5turn, ref botFiveFirstTurn, fifthBotStatus, 4, fifthBotPower,
                            fifthBotType);
                        turnCount++;
                        last = 5;
                        B5turn = false;
                    }
                }
                if (botFiveFirstTurn && !b5Folded)
                {
                    bools.RemoveAt(5);
                    bools.Insert(5, null);
                    maxLeft--;
                    b5Folded = true;
                }
                if (botFiveFirstTurn || !B5turn)
                {
                    await CheckRaise(5, 5);
                    playerTurn = true;
                }
                if (PlayerFirstTurn && !playerFolded)
                {
                    if (callButton.Text.Contains("All in") == false || raiseButton.Text.Contains("All in") == false)
                    {
                        bools.RemoveAt(0);
                        bools.Insert(0, null);
                        maxLeft--;
                        playerFolded = true;
                    }
                }

                #endregion

                await AllIn();
                if (!restart)
                {
                    await Turns();
                }
                restart = false;
            }
        }

        private void tbBotChips2_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void tbRaise_TextChanged(object sender, EventArgs e)
        {
            if (tbRaise.Text == "GODMODE")
            {
                addChipsButton.Visible = true;
                numberOfChipsToAdd.Visible = true;
            }
            else
            {
                addChipsButton.Visible = false;
                numberOfChipsToAdd.Visible = false;
            }
        }

        #region Variables

        private readonly Panel playerPanel = new Panel();
        private readonly Panel firstBotPanel = new Panel();
        private readonly Panel secondBotPanel = new Panel();
        private readonly Panel thirdBotPanel = new Panel();
        private readonly Panel fourthBotPanel = new Panel();
        private readonly Panel fifthBotPanel = new Panel();

        DataBase.DataBase a = new DataBase.DataBase();

        private int Nm;
        private int call = 500;
        private int foldedPlayers = 5;
        private int Chips = 10000;
        private int firstBotChips = 10000;
        private int secondBotChips = 10000;
        private int thirdBotChips = 10000;
        private int fourthBotChips = 10000;
        private int fifthBotChips = 10000;
        private int playerCall;
        private int firstBotCall;
        private int secondBotCall;
        private int thirdBotCall;
        private int fourthBotCall;
        private int fifthBotCall;
        private int playerRise;
        private int firstBotRise;
        private int secondBotRise;
        private int thirdBotRise;
        private int fourthBotRise;
        private int fifthBotRise;

        private int height;
        private int width;
        private int winners;
        private int Flop = 1;
        private int Turn = 2;
        private int River = 3;
        private int End = 4;
        private int maxLeft = 6;
        private int last = 123;
        private int raisedTurn = 1;

        private double type;
        private double rounds;
        private double firstBotPower;
        private double secondBotPower;
        private double thirdBotPower;
        private double fourthBotPower;
        private double fifthBotPower;
        private double playerPower;
        private double playerType = -1;
        private double raise;
        private double firstBotType = -1;
        private double secondBotType = -1;
        private double thirdBotType = -1;
        private double fourthBotType = -1;
        private double fifthBotType = -1;

        private bool B1turn;
        private bool B2turn;
        private bool B3turn;
        private bool B4turn;
        private bool B5turn;
        private bool botOneFirstTurn;
        private bool botTwoTurn;
        private bool botThreeFirstTurn;
        private bool botFourFirstTurn;
        private bool botFiveFirstTurn;

        private bool playerFolded;
        private bool botOneFolded;
        private bool botTwoFolded;
        private bool botThreeFolded;
        private bool b4Folded;
        private bool b5Folded;

        private bool intsadded;
        private bool changed;
        private bool PlayerFirstTurn;
        private bool playerTurn = true;
        private bool restart;
        private bool isRaising;

        private readonly List<bool?> bools = new List<bool?>();
        private readonly List<Type> Win = new List<Type>();
        private readonly List<string> CheckWinners = new List<string>();
        private readonly List<int> ints = new List<int>();

        private Type sorted;

        private string[] ImgLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);
        /*string[] ImgLocation ={
                   "Assets\\Cards\\33.png","Assets\\Cards\\22.png",
                    "Assets\\Cards\\29.png","Assets\\Cards\\21.png",
                    "Assets\\Cards\\36.png","Assets\\Cards\\17.png",
                    "Assets\\Cards\\40.png","Assets\\Cards\\16.png",
                    "Assets\\Cards\\5.png","Assets\\Cards\\47.png",
                    "Assets\\Cards\\37.png","Assets\\Cards\\13.png",
                    
                    "Assets\\Cards\\12.png",
                    "Assets\\Cards\\8.png","Assets\\Cards\\18.png",
                    "Assets\\Cards\\15.png","Assets\\Cards\\27.png"};*/
        private readonly int[] Reserve = new int[17];
        private readonly Image[] Deck = new Image[52];
        private readonly PictureBox[] Holder = new PictureBox[52];
        private readonly Timer timer = new Timer();
        private readonly Timer Updates = new Timer();

        private int t = 60;
        private int i;
        private int bigBlind = 500;
        private int smallBlind = 250;
        private int up = 10000000;
        private int turnCount;
        private ProgressBar progressBar = new ProgressBar();

        #endregion

        #region Saki

        private void Rules_ToBeDeleted_NewName_SetGameRules(
            int card1,
            int card2,
            string currentText,
            ref double curentCardsValue,
            ref double power,
            bool foldedTurn)
        {
            //if (card1 == 0 && card2 == 1)
            //{
            //}
            if (!foldedTurn || card1 == 0 && card2 == 1 && playerStatus.Text.Contains("Fold") == false)
            {
                #region Variables

                bool done = false;
                bool vf = false;

                int[] littleStraight = new int[5];
                int[] bigStraight = new int[7];

                bigStraight[0] = Reserve[card1];
                bigStraight[1] = Reserve[card2];
                littleStraight[0] = bigStraight[2] = Reserve[12];
                littleStraight[1] = bigStraight[3] = Reserve[13];
                littleStraight[2] = bigStraight[4] = Reserve[14];
                littleStraight[3] = bigStraight[5] = Reserve[15];
                littleStraight[4] = bigStraight[6] = Reserve[16];

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

                const int CardsOnTable = 16;

                #endregion

                for (i = 0; i < CardsOnTable; i++)
                {
                    if (Reserve[i] == int.Parse(Holder[card1].Tag.ToString()) &&
                        Reserve[i + 1] == int.Parse(Holder[card2].Tag.ToString()))
                    {
                        //Pair from Hand curentCardsValue = 1
                        CheckForPairFromHand(ref curentCardsValue, ref power);

                        //Pair or Two Pairs from Table curentCardsValue = 2 || 0
                        CheckForPairTwoPair(ref curentCardsValue, ref power);

                        //Two Pairs curentCardsValue = 2
                        CheckForTwoPair(ref curentCardsValue, ref power);

                        //Three of a kind curentCardsValue = 3
                        CheckForThreeOfAKind(ref curentCardsValue, ref power, bigStraight);

                        //Straight curentCardsValue = 4
                        rStraight(ref curentCardsValue, ref power, bigStraight);

                        //Flush curentCardsValue = 5 || 5.5
                        rFlush(ref curentCardsValue, ref power, ref vf, littleStraight);

                        //Full House curentCardsValue = 6
                        rFullHouse(ref curentCardsValue, ref power, ref done, bigStraight);

                        //Four of a Kind curentCardsValue = 7
                        CheckForFourOfAKind(ref curentCardsValue, ref power, bigStraight);

                        //Straight Flush curentCardsValue = 8 || 9
                        CheckForStraightFlush_ToBeDeleted_NewMethodsInstead(ref curentCardsValue, ref power, straightOfClubsValue, straightOfDiamondsValue, straightOfHeartsValue, straightOfSpadesValue);

                        //High Card curentCardsValue = -1
                        CheckForHighCard(ref curentCardsValue, ref power);
                    }
                }
            }
        }


        private void CheckForStraightFlush_ToBeDeleted_NewMethodsInstead(
            ref double currentCardsValue,
            ref double cardsPower,
            int[] straightOfClubs,
            int[] straightOfDiamonds,
            int[] straightOfHearts,
            int[] straightOfSpades)
        {
            if (currentCardsValue >= -1)
            {
                if (straightOfClubs.Length >= 5)
                {
                    if (straightOfClubs[0] + 4 == straightOfClubs[4])
                    {
                        currentCardsValue = 8;
                        cardsPower = straightOfClubs.Max() / 4 + currentCardsValue * 100;
                        Win.Add(new Type { Power = cardsPower, Current = 8 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (straightOfClubs[0] == 0 && straightOfClubs[1] == 9 && straightOfClubs[2] == 10 && straightOfClubs[3] == 11 && straightOfClubs[0] + 12 == straightOfClubs[4])
                    {
                        currentCardsValue = 9;
                        cardsPower = straightOfClubs.Max() / 4 + currentCardsValue * 100;
                        Win.Add(new Type { Power = cardsPower, Current = 9 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
                if (straightOfDiamonds.Length >= 5)
                {
                    if (straightOfDiamonds[0] + 4 == straightOfDiamonds[4])
                    {
                        currentCardsValue = 8;
                        cardsPower = straightOfDiamonds.Max() / 4 + currentCardsValue * 100;
                        Win.Add(new Type { Power = cardsPower, Current = 8 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (straightOfDiamonds[0] == 0 && straightOfDiamonds[1] == 9 && straightOfDiamonds[2] == 10 && straightOfDiamonds[3] == 11 && straightOfDiamonds[0] + 12 == straightOfDiamonds[4])
                    {
                        currentCardsValue = 9;
                        cardsPower = straightOfDiamonds.Max() / 4 + currentCardsValue * 100;
                        Win.Add(new Type { Power = cardsPower, Current = 9 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
                if (straightOfHearts.Length >= 5)
                {
                    if (straightOfHearts[0] + 4 == straightOfHearts[4])
                    {
                        currentCardsValue = 8;
                        cardsPower = straightOfHearts.Max() / 4 + currentCardsValue * 100;
                        Win.Add(new Type { Power = cardsPower, Current = 8 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (straightOfHearts[0] == 0 && straightOfHearts[1] == 9 && straightOfHearts[2] == 10 && straightOfHearts[3] == 11 && straightOfHearts[0] + 12 == straightOfHearts[4])
                    {
                        currentCardsValue = 9;
                        cardsPower = straightOfHearts.Max() / 4 + currentCardsValue * 100;
                        Win.Add(new Type { Power = cardsPower, Current = 9 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
                if (straightOfSpades.Length >= 5)
                {
                    if (straightOfSpades[0] + 4 == straightOfSpades[4])
                    {
                        currentCardsValue = 8;
                        cardsPower = straightOfSpades.Max() / 4 + currentCardsValue * 100;
                        Win.Add(new Type { Power = cardsPower, Current = 8 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (straightOfSpades[0] == 0 && straightOfSpades[1] == 9 && straightOfSpades[2] == 10 && straightOfSpades[3] == 11 && straightOfSpades[0] + 12 == straightOfSpades[4])
                    {
                        currentCardsValue = 9;
                        cardsPower = straightOfSpades.Max() / 4 + currentCardsValue * 100;
                        Win.Add(new Type { Power = cardsPower, Current = 9 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
            }
        }

        private void CheckForFourOfAKind(ref double current, ref double Power, int[] Straight)
        {
            if (current >= -1)
            {
                for (var j = 0; j <= 3; j++)
                {
                    if (Straight[j] / 4 == Straight[j + 1] / 4 && Straight[j] / 4 == Straight[j + 2] / 4 &&
                        Straight[j] / 4 == Straight[j + 3] / 4)
                    {
                        current = 7;
                        Power = Straight[j] / 4 * 4 + current * 100;
                        Win.Add(new Type { Power = Power, Current = 7 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (Straight[j] / 4 == 0 && Straight[j + 1] / 4 == 0 && Straight[j + 2] / 4 == 0 && Straight[j + 3] / 4 == 0)
                    {
                        current = 7;
                        Power = 13 * 4 + current * 100;
                        Win.Add(new Type { Power = Power, Current = 7 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
            }
        }

        private void rFullHouse(ref double current, ref double Power, ref bool done, int[] Straight)
        {
            if (current >= -1)
            {
                type = Power;
                for (var j = 0; j <= 12; j++)
                {
                    var fh = Straight.Where(o => o / 4 == j).ToArray();
                    if (fh.Length == 3 || done)
                    {
                        if (fh.Length == 2)
                        {
                            if (fh.Max() / 4 == 0)
                            {
                                current = 6;
                                Power = 13 * 2 + current * 100;
                                Win.Add(new Type { Power = Power, Current = 6 });
                                sorted =
                                    Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                                break;
                            }
                            if (fh.Max() / 4 > 0)
                            {
                                current = 6;
                                Power = fh.Max() / 4 * 2 + current * 100;
                                Win.Add(new Type { Power = Power, Current = 6 });
                                sorted =
                                    Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                                break;
                            }
                        }
                        if (!done)
                        {
                            if (fh.Max() / 4 == 0)
                            {
                                Power = 13;
                                done = true;
                                j = -1;
                            }
                            else
                            {
                                Power = fh.Max() / 4;
                                done = true;
                                j = -1;
                            }
                        }
                    }
                }
                if (current != 6)
                {
                    Power = type;
                }
            }
        }

        private void rFlush(ref double current, ref double Power, ref bool vf, int[] Straight1)
        {
            if (current >= -1)
            {
                var f1 = Straight1.Where(o => o % 4 == 0).ToArray();
                var f2 = Straight1.Where(o => o % 4 == 1).ToArray();
                var f3 = Straight1.Where(o => o % 4 == 2).ToArray();
                var f4 = Straight1.Where(o => o % 4 == 3).ToArray();
                if (f1.Length == 3 || f1.Length == 4)
                {
                    if (Reserve[i] % 4 == Reserve[i + 1] % 4 && Reserve[i] % 4 == f1[0] % 4)
                    {
                        if (Reserve[i] / 4 > f1.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        if (Reserve[i + 1] / 4 > f1.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i + 1] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else if (Reserve[i] / 4 < f1.Max() / 4 && Reserve[i + 1] / 4 < f1.Max() / 4)
                        {
                            current = 5;
                            Power = f1.Max() + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f1.Length == 4) //different cards in hand
                {
                    if (Reserve[i] % 4 != Reserve[i + 1] % 4 && Reserve[i] % 4 == f1[0] % 4)
                    {
                        if (Reserve[i] / 4 > f1.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            Power = f1.Max() + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                    if (Reserve[i + 1] % 4 != Reserve[i] % 4 && Reserve[i + 1] % 4 == f1[0] % 4)
                    {
                        if (Reserve[i + 1] / 4 > f1.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i + 1] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            Power = f1.Max() + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f1.Length == 5)
                {
                    if (Reserve[i] % 4 == f1[0] % 4 && Reserve[i] / 4 > f1.Min() / 4)
                    {
                        current = 5;
                        Power = Reserve[i] + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    if (Reserve[i + 1] % 4 == f1[0] % 4 && Reserve[i + 1] / 4 > f1.Min() / 4)
                    {
                        current = 5;
                        Power = Reserve[i + 1] + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    else if (Reserve[i] / 4 < f1.Min() / 4 && Reserve[i + 1] / 4 < f1.Min())
                    {
                        current = 5;
                        Power = f1.Max() + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                }

                if (f2.Length == 3 || f2.Length == 4)
                {
                    if (Reserve[i] % 4 == Reserve[i + 1] % 4 && Reserve[i] % 4 == f2[0] % 4)
                    {
                        if (Reserve[i] / 4 > f2.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        if (Reserve[i + 1] / 4 > f2.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i + 1] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else if (Reserve[i] / 4 < f2.Max() / 4 && Reserve[i + 1] / 4 < f2.Max() / 4)
                        {
                            current = 5;
                            Power = f2.Max() + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f2.Length == 4) //different cards in hand
                {
                    if (Reserve[i] % 4 != Reserve[i + 1] % 4 && Reserve[i] % 4 == f2[0] % 4)
                    {
                        if (Reserve[i] / 4 > f2.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            Power = f2.Max() + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                    if (Reserve[i + 1] % 4 != Reserve[i] % 4 && Reserve[i + 1] % 4 == f2[0] % 4)
                    {
                        if (Reserve[i + 1] / 4 > f2.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i + 1] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            Power = f2.Max() + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f2.Length == 5)
                {
                    if (Reserve[i] % 4 == f2[0] % 4 && Reserve[i] / 4 > f2.Min() / 4)
                    {
                        current = 5;
                        Power = Reserve[i] + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    if (Reserve[i + 1] % 4 == f2[0] % 4 && Reserve[i + 1] / 4 > f2.Min() / 4)
                    {
                        current = 5;
                        Power = Reserve[i + 1] + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    else if (Reserve[i] / 4 < f2.Min() / 4 && Reserve[i + 1] / 4 < f2.Min())
                    {
                        current = 5;
                        Power = f2.Max() + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                }

                if (f3.Length == 3 || f3.Length == 4)
                {
                    if (Reserve[i] % 4 == Reserve[i + 1] % 4 && Reserve[i] % 4 == f3[0] % 4)
                    {
                        if (Reserve[i] / 4 > f3.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        if (Reserve[i + 1] / 4 > f3.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i + 1] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else if (Reserve[i] / 4 < f3.Max() / 4 && Reserve[i + 1] / 4 < f3.Max() / 4)
                        {
                            current = 5;
                            Power = f3.Max() + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f3.Length == 4) //different cards in hand
                {
                    if (Reserve[i] % 4 != Reserve[i + 1] % 4 && Reserve[i] % 4 == f3[0] % 4)
                    {
                        if (Reserve[i] / 4 > f3.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            Power = f3.Max() + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                    if (Reserve[i + 1] % 4 != Reserve[i] % 4 && Reserve[i + 1] % 4 == f3[0] % 4)
                    {
                        if (Reserve[i + 1] / 4 > f3.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i + 1] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            Power = f3.Max() + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f3.Length == 5)
                {
                    if (Reserve[i] % 4 == f3[0] % 4 && Reserve[i] / 4 > f3.Min() / 4)
                    {
                        current = 5;
                        Power = Reserve[i] + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    if (Reserve[i + 1] % 4 == f3[0] % 4 && Reserve[i + 1] / 4 > f3.Min() / 4)
                    {
                        current = 5;
                        Power = Reserve[i + 1] + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    else if (Reserve[i] / 4 < f3.Min() / 4 && Reserve[i + 1] / 4 < f3.Min())
                    {
                        current = 5;
                        Power = f3.Max() + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                }

                if (f4.Length == 3 || f4.Length == 4)
                {
                    if (Reserve[i] % 4 == Reserve[i + 1] % 4 && Reserve[i] % 4 == f4[0] % 4)
                    {
                        if (Reserve[i] / 4 > f4.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        if (Reserve[i + 1] / 4 > f4.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i + 1] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else if (Reserve[i] / 4 < f4.Max() / 4 && Reserve[i + 1] / 4 < f4.Max() / 4)
                        {
                            current = 5;
                            Power = f4.Max() + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f4.Length == 4) //different cards in hand
                {
                    if (Reserve[i] % 4 != Reserve[i + 1] % 4 && Reserve[i] % 4 == f4[0] % 4)
                    {
                        if (Reserve[i] / 4 > f4.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            Power = f4.Max() + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                    if (Reserve[i + 1] % 4 != Reserve[i] % 4 && Reserve[i + 1] % 4 == f4[0] % 4)
                    {
                        if (Reserve[i + 1] / 4 > f4.Max() / 4)
                        {
                            current = 5;
                            Power = Reserve[i + 1] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            Power = f4.Max() + current * 100;
                            Win.Add(new Type { Power = Power, Current = 5 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f4.Length == 5)
                {
                    if (Reserve[i] % 4 == f4[0] % 4 && Reserve[i] / 4 > f4.Min() / 4)
                    {
                        current = 5;
                        Power = Reserve[i] + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    if (Reserve[i + 1] % 4 == f4[0] % 4 && Reserve[i + 1] / 4 > f4.Min() / 4)
                    {
                        current = 5;
                        Power = Reserve[i + 1] + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    else if (Reserve[i] / 4 < f4.Min() / 4 && Reserve[i + 1] / 4 < f4.Min())
                    {
                        current = 5;
                        Power = f4.Max() + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                }
                //ace
                if (f1.Length > 0)
                {
                    if (Reserve[i] / 4 == 0 && Reserve[i] % 4 == f1[0] % 4 && vf && f1.Length > 0)
                    {
                        current = 5.5;
                        Power = 13 + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (Reserve[i + 1] / 4 == 0 && Reserve[i + 1] % 4 == f1[0] % 4 && vf && f1.Length > 0)
                    {
                        current = 5.5;
                        Power = 13 + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
                if (f2.Length > 0)
                {
                    if (Reserve[i] / 4 == 0 && Reserve[i] % 4 == f2[0] % 4 && vf && f2.Length > 0)
                    {
                        current = 5.5;
                        Power = 13 + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (Reserve[i + 1] / 4 == 0 && Reserve[i + 1] % 4 == f2[0] % 4 && vf && f2.Length > 0)
                    {
                        current = 5.5;
                        Power = 13 + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
                if (f3.Length > 0)
                {
                    if (Reserve[i] / 4 == 0 && Reserve[i] % 4 == f3[0] % 4 && vf && f3.Length > 0)
                    {
                        current = 5.5;
                        Power = 13 + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (Reserve[i + 1] / 4 == 0 && Reserve[i + 1] % 4 == f3[0] % 4 && vf && f3.Length > 0)
                    {
                        current = 5.5;
                        Power = 13 + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
                if (f4.Length > 0)
                {
                    if (Reserve[i] / 4 == 0 && Reserve[i] % 4 == f4[0] % 4 && vf && f4.Length > 0)
                    {
                        current = 5.5;
                        Power = 13 + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (Reserve[i + 1] / 4 == 0 && Reserve[i + 1] % 4 == f4[0] % 4 && vf)
                    {
                        current = 5.5;
                        Power = 13 + current * 100;
                        Win.Add(new Type { Power = Power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
            }
        }

        private void rStraight(ref double current, ref double Power, int[] Straight)
        {
            if (current >= -1)
            {
                var op = Straight.Select(o => o / 4).Distinct().ToArray();
                for (var j = 0; j < op.Length - 4; j++)
                {
                    if (op[j] + 4 == op[j + 4])
                    {
                        if (op.Max() - 4 == op[j])
                        {
                            current = 4;
                            Power = op.Max() + current * 100;
                            Win.Add(new Type { Power = Power, Current = 4 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        }
                        else
                        {
                            current = 4;
                            Power = op[j + 4] + current * 100;
                            Win.Add(new Type { Power = Power, Current = 4 });
                            sorted =
                                Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        }
                    }
                    if (op[j] == 0 && op[j + 1] == 9 && op[j + 2] == 10 && op[j + 3] == 11 && op[j + 4] == 12)
                    {
                        current = 4;
                        Power = 13 + current * 100;
                        Win.Add(new Type { Power = Power, Current = 4 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
            }
        }

        #endregion

        #region Martin

        private void CheckForThreeOfAKind(ref double current, ref double power, int[] straight)
        {
            var threeOfAKindCounter = 3;
            if (current >= -1)
            {
                for (var j = 0; j <= 12; j++)
                {
                    var fh = straight.Where(o => o / 4 == j).ToArray();

                    if (fh.Length == threeOfAKindCounter)
                    {
                        current = threeOfAKindCounter;

                        if (fh.Max() / 4 == 0)
                        {
                            power = 13 * 3 + current * 100;
                        }
                        else
                        {
                            power = fh[0] / 4 + fh[1] / 4 + fh[2] / 4 + current * 100;
                        }
                        Win.Add(new Type { Power = power, Current = 3 });
                        sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                    }
                }
            }
        }

        private void CheckForTwoPair(ref double current, ref double power)
        {
            if (current >= -1)
            {
                var hasBeenProcessed = false;
                for (var tc = 16; tc >= 12; tc--)
                {
                    var max = tc - 12;
                    if (Reserve[i] / 4 != Reserve[i + 1] / 4)
                    {
                        for (var k = 1; k <= max; k++)
                        {
                            if (tc - k < 12)
                            {
                                max--;
                            }
                            if (tc - k >= 12)
                            {
                                var conditionOne = Reserve[i] / 4 == Reserve[tc] / 4 &&
                                                   Reserve[i + 1] / 4 == Reserve[tc - k] / 4;

                                var conditionTwo = Reserve[i + 1] / 4 == Reserve[tc] / 4 &&
                                                   Reserve[i] / 4 == Reserve[tc - k] / 4;

                                if (conditionOne || conditionTwo)
                                {
                                    if (!hasBeenProcessed)
                                    {
                                        current = 2;
                                        if (Reserve[i] / 4 == 0)
                                        {
                                            power = 13 * 4 + Reserve[i + 1] / 4 * 2 + current * 100;
                                            Win.Add(new Type { Power = power, Current = 2 });
                                        }
                                        if (Reserve[i + 1] / 4 == 0)
                                        {
                                            power = 13 * 4 + Reserve[i] / 4 * 2 + current * 100;
                                            Win.Add(new Type { Power = power, Current = current });
                                        }
                                        if (Reserve[i + 1] / 4 != 0 && Reserve[i] / 4 != 0)
                                        {
                                            power = Reserve[i] / 4 * 2 + Reserve[i + 1] / 4 * 2 + current * 100;
                                            Win.Add(new Type { Power = power, Current = current });
                                        }

                                        sorted =
                                            Win.OrderByDescending(op => op.Current)
                                                .ThenByDescending(op => op.Power)
                                                .First();
                                    }
                                    hasBeenProcessed = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void CheckForPairTwoPair(ref double current, ref double power)
        {
            if (current >= -1)
            {
                var hasBeenProcessed1 = false;
                var hasBeenProcessed2 = false;
                for (var tc = 16; tc >= 12; tc--)
                {
                    var max = tc - 12;
                    for (var k = 1; k <= max; k++)
                    {
                        if (tc - k < 12)
                        {
                            max--;
                        }
                        if (tc - k >= 12)
                        {
                            if (Reserve[tc] / 4 == Reserve[tc - k] / 4)
                            {
                                if (Reserve[tc] / 4 != Reserve[i] / 4 && Reserve[tc] / 4 != Reserve[i + 1] / 4 && current == 1)
                                {
                                    if (!hasBeenProcessed1)
                                    {
                                        current = 2;
                                        if (Reserve[i + 1] / 4 == 0)
                                        {
                                            power = Reserve[i] / 4 * 2 + 13 * 4 + current * 100;
                                        }
                                        else
                                        {
                                            power = Reserve[tc] / 4 * 2 + Reserve[i + 1] / 4 * 2 + current * 100;
                                        }
                                        Win.Add(new Type { Power = power, Current = 2 });

                                        if (Reserve[i] / 4 == 0)
                                        {
                                            power = Reserve[i + 1] / 4 * 2 + 13 * 4 + current * 100;
                                        }
                                        else
                                        {
                                            power = Reserve[tc] / 4 * 2 + Reserve[i] / 4 * 2 + current * 100;
                                        }
                                        Win.Add(new Type { Power = power, Current = 2 });

                                        sorted =
                                            Win.OrderByDescending(op => op.Current)
                                                .ThenByDescending(op => op.Power)
                                                .First();
                                    }

                                    hasBeenProcessed1 = true;
                                }
                                if (current == -1)
                                {
                                    if (!hasBeenProcessed2)
                                    {
                                        current = 0;
                                        if (Reserve[i] / 4 > Reserve[i + 1] / 4)
                                        {
                                            if (Reserve[tc] / 4 == 0)
                                            {
                                                power = 13 + Reserve[i] / 4 + current * 100;
                                            }
                                            else
                                            {
                                                power = Reserve[tc] / 4 + Reserve[i] / 4 + current * 100;
                                            }
                                            Win.Add(new Type { Power = power, Current = 1 });
                                            sorted =
                                                Win.OrderByDescending(op => op.Current)
                                                    .ThenByDescending(op => op.Power)
                                                    .First();
                                        }
                                        else
                                        {
                                            if (Reserve[tc] / 4 == 0)
                                            {
                                                power = 13 + Reserve[i + 1] + current * 100;
                                            }
                                            else
                                            {
                                                power = Reserve[tc] / 4 + Reserve[i + 1] / 4 + current * 100;
                                            }
                                            Win.Add(new Type { Power = power, Current = 1 });
                                            sorted =
                                                Win.OrderByDescending(op => op.Current)
                                                    .ThenByDescending(op => op.Power)
                                                    .First();
                                        }
                                    }
                                    hasBeenProcessed2 = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CheckForPairFromHand(ref double current, ref double power)
        {
            if (current >= -1)
            {
                var hasBeenProcessed = false;
                if (Reserve[i] / 4 == Reserve[i + 1] / 4)
                {
                    if (!hasBeenProcessed)
                    {
                        current = 1;
                        if (Reserve[i] / 4 == 0)
                        {
                            power = 13 * 4 + current * 100;
                        }
                        else
                        {
                            power = Reserve[i + 1] / 4 * 4 + current * 100;
                        }

                        Win.Add(new Type { Power = power, Current = 1 });
                        sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                    }
                    hasBeenProcessed = true;
                }
                for (var tc = 16; tc >= 12; tc--)
                {
                    if (Reserve[i + 1] / 4 == Reserve[tc] / 4)
                    {
                        if (!hasBeenProcessed)
                        {
                            current = 1;
                            if (Reserve[i + 1] / 4 == 0)
                            {
                                power = 13 * 4 + Reserve[i] / 4 + current * 100;
                            }
                            else
                            {
                                power = Reserve[i + 1] / 4 * 4 + Reserve[i] / 4 + current * 100;
                            }

                            Win.Add(new Type { Power = power, Current = 1 });
                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                        }
                        hasBeenProcessed = true;
                    }
                    if (Reserve[i] / 4 == Reserve[tc] / 4)
                    {
                        if (!hasBeenProcessed)
                        {
                            current = 1;
                            if (Reserve[i] / 4 == 0)
                            {
                                power = 13 * 4 + Reserve[i + 1] / 4 + current * 100;
                            }
                            else
                            {
                                power = Reserve[tc] / 4 * 4 + Reserve[i + 1] / 4 + current * 100;
                            }

                            Win.Add(new Type { Power = power, Current = 1 });
                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                        }
                        hasBeenProcessed = true;
                    }
                }
            }
        }

        private void CheckForHighCard(ref double current, ref double power)
        {
            if (current == -1)
            {
                if (Reserve[i] / 4 > Reserve[i + 1] / 4)
                {
                    power = Reserve[i] / 4;
                }
                else
                {
                    power = Reserve[i + 1] / 4;
                }
                Win.Add(new Type { Power = power, Current = -1 });

                if (Reserve[i] / 4 == 0 || Reserve[i + 1] / 4 == 0)
                {
                    power = 13;
                    Win.Add(new Type { Power = power, Current = -1 });
                }
                sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
            }
        }

        #endregion

        #region John

        //This method determines winner
        private void Winner(double current, double power, string currentText, int chips, string lastPlayed)
        {
            if (lastPlayed == string.Empty)
            {
                lastPlayed = "Bot 5";
            }

            for (var j = 0; j <= 16; j++)
            {
                //await Task.Delay(5);
                if (Holder[j].Visible)
                    Holder[j].Image = Deck[j];
            }
            if (current == sorted.Current)
            {
                if (power == sorted.Power)
                {
                    winners++;
                    CheckWinners.Add(currentText);

                    if (current == -1)
                    {
                        MessageBox.Show(currentText + " High Card ");
                    }
                    if (current == 1 || current == 0)
                    {
                        MessageBox.Show(currentText + " Pair ");
                    }
                    if (current == 2)
                    {
                        MessageBox.Show(currentText + " Two Pair ");
                    }
                    if (current == 3)
                    {
                        MessageBox.Show(currentText + " Three of a Kind ");
                    }
                    if (current == 4)
                    {
                        MessageBox.Show(currentText + " Straight ");
                    }
                    if (current == 5 || current == 5.5)
                    {
                        MessageBox.Show(currentText + " Flush ");
                    }
                    if (current == 6)
                    {
                        MessageBox.Show(currentText + " Full House ");
                    }
                    if (current == 7)
                    {
                        MessageBox.Show(currentText + " Four of a Kind ");
                    }
                    if (current == 8)
                    {
                        MessageBox.Show(currentText + " Straight Flush ");
                    }
                    if (current == 9)
                    {
                        MessageBox.Show(currentText + " Royal Flush ! ");
                    }
                }
            }
            if (currentText == lastPlayed) //lastfixed
            {
                if (winners > 1)
                {
                    if (CheckWinners.Contains("Player"))
                    {
                        Chips += int.Parse(potChips.Text) / winners;
                        tableChips.Text = Chips.ToString();
                        //playerPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 1"))
                    {
                        firstBotChips += int.Parse(potChips.Text) / winners;
                        tableBot1Chips.Text = firstBotChips.ToString();
                        //firstBotPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 2"))
                    {
                        secondBotChips += int.Parse(potChips.Text) / winners;
                        tableBot2Chips.Text = secondBotChips.ToString();
                        //secondBotPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 3"))
                    {
                        thirdBotChips += int.Parse(potChips.Text) / winners;
                        tableBot3Chips.Text = thirdBotChips.ToString();
                        //thirdBotPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 4"))
                    {
                        fourthBotChips += int.Parse(potChips.Text) / winners;
                        tableBot4Chips.Text = fourthBotChips.ToString();
                        //fourthBotPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 5"))
                    {
                        fifthBotChips += int.Parse(potChips.Text) / winners;
                        tableBot5Chips.Text = fifthBotChips.ToString();
                        //fifthBotPanel.Visible = true;
                    }
                    //await Finish(1);
                }
                if (winners == 1)
                {
                    if (CheckWinners.Contains("Player"))
                    {
                        Chips += int.Parse(potChips.Text);
                        //await Finish(1);
                        //playerPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 1"))
                    {
                        firstBotChips += int.Parse(potChips.Text);
                        //await Finish(1);
                        //firstBotPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 2"))
                    {
                        secondBotChips += int.Parse(potChips.Text);
                        //await Finish(1);
                        //secondBotPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 3"))
                    {
                        thirdBotChips += int.Parse(potChips.Text);
                        //await Finish(1);
                        //thirdBotPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 4"))
                    {
                        fourthBotChips += int.Parse(potChips.Text);
                        //await Finish(1);
                        //fourthBotPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 5"))
                    {
                        fifthBotChips += int.Parse(potChips.Text);
                        //await Finish(1);
                        //fifthBotPanel.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="currentTurn"></param>
        /// <param name="raiseTurn"></param>
        /// <returns></returns>
        private async Task CheckRaise(int currentTurn, int raiseTurn)
        {
            if (isRaising)
            {
                turnCount = 0;
                isRaising = false;
                raisedTurn = currentTurn;
                changed = true;
            }
            else
            {
                if (turnCount >= maxLeft - 1 || !changed && turnCount == maxLeft)
                {
                    if (currentTurn == raisedTurn - 1 || !changed && turnCount == maxLeft ||
                        raisedTurn == 0 && currentTurn == 5)
                    {
                        changed = false;
                        turnCount = 0;
                        raise = 0;
                        call = 0;
                        raisedTurn = 123;
                        rounds++;
                        if (!PlayerFirstTurn)
                            playerStatus.Text = "";
                        if (!botOneFirstTurn)
                            firstBotStatus.Text = "";
                        if (!botTwoTurn)
                            secondBotStatus.Text = "";
                        if (!botThreeFirstTurn)
                            thirdBotStatus.Text = "";
                        if (!botFourFirstTurn)
                            fourthBotStatus.Text = "";
                        if (!botFiveFirstTurn)
                            fifthBotStatus.Text = "";
                    }
                }
            }
            if (rounds == Flop)
            {
                for (var j = 12; j <= 14; j++)
                {
                    if (Holder[j].Image != Deck[j])
                    {
                        Holder[j].Image = Deck[j];

                        playerCall = 0;
                        playerRise = 0;

                        firstBotCall = 0;
                        firstBotRise = 0;

                        secondBotCall = 0;
                        secondBotRise = 0;

                        thirdBotCall = 0;
                        thirdBotRise = 0;

                        fourthBotCall = 0;
                        fourthBotRise = 0;

                        fifthBotCall = 0;
                        fifthBotRise = 0;
                    }
                }
            }
            if (rounds == Turn)
            {
                for (var j = 14; j <= 15; j++)
                {
                    if (Holder[j].Image != Deck[j])
                    {
                        Holder[j].Image = Deck[j];
                        playerCall = 0;
                        playerRise = 0;
                        firstBotCall = 0;
                        firstBotRise = 0;
                        secondBotCall = 0;
                        secondBotRise = 0;
                        thirdBotCall = 0;
                        thirdBotRise = 0;
                        fourthBotCall = 0;
                        fourthBotRise = 0;
                        fifthBotCall = 0;
                        fifthBotRise = 0;
                    }
                }
            }
            if (rounds == River)
            {
                for (var j = 15; j <= 16; j++)
                {
                    if (Holder[j].Image != Deck[j])
                    {
                        Holder[j].Image = Deck[j];

                        playerCall = 0;
                        playerRise = 0;
                        firstBotCall = 0;
                        firstBotRise = 0;
                        secondBotCall = 0;
                        secondBotRise = 0;
                        thirdBotCall = 0;
                        thirdBotRise = 0;
                        fourthBotCall = 0;
                        fourthBotRise = 0;
                        fifthBotCall = 0;
                        fifthBotRise = 0;
                    }
                }
            }
            if (rounds == End && maxLeft == 6)
            {
                var fixedLast = "qwerty";
                if (!playerStatus.Text.Contains("Fold"))
                {
                    fixedLast = "Player";
                    Rules_ToBeDeleted_NewName_SetGameRules(0, 1, "Player", ref playerType, ref playerPower, PlayerFirstTurn);
                }
                if (!firstBotStatus.Text.Contains("Fold"))
                {
                    fixedLast = "Bot 1";
                    Rules_ToBeDeleted_NewName_SetGameRules(2, 3, "Bot 1", ref firstBotType, ref firstBotPower, botOneFirstTurn);
                }
                if (!secondBotStatus.Text.Contains("Fold"))
                {
                    fixedLast = "Bot 2";
                    Rules_ToBeDeleted_NewName_SetGameRules(4, 5, "Bot 2", ref secondBotType, ref secondBotPower, botTwoTurn);
                }
                if (!thirdBotStatus.Text.Contains("Fold"))
                {
                    fixedLast = "Bot 3";
                    Rules_ToBeDeleted_NewName_SetGameRules(6, 7, "Bot 3", ref thirdBotType, ref thirdBotPower, botThreeFirstTurn);
                }
                if (!fourthBotStatus.Text.Contains("Fold"))
                {
                    fixedLast = "Bot 4";
                    Rules_ToBeDeleted_NewName_SetGameRules(8, 9, "Bot 4", ref fourthBotType, ref fourthBotPower, botFourFirstTurn);
                }
                if (!fifthBotStatus.Text.Contains("Fold"))
                {
                    fixedLast = "Bot 5";
                    Rules_ToBeDeleted_NewName_SetGameRules(10, 11, "Bot 5", ref fifthBotType, ref fifthBotPower, botFiveFirstTurn);
                }

                Winner(playerType, playerPower, "Player", Chips, fixedLast);
                Winner(firstBotType, firstBotPower, "Bot 1", firstBotChips, fixedLast);
                Winner(secondBotType, secondBotPower, "Bot 2", secondBotChips, fixedLast);
                Winner(thirdBotType, thirdBotPower, "Bot 3", thirdBotChips, fixedLast);
                Winner(fourthBotType, fourthBotPower, "Bot 4", fourthBotChips, fixedLast);
                Winner(fifthBotType, fifthBotPower, "Bot 5", fifthBotChips, fixedLast);
                restart = true;
                playerTurn = true;
                PlayerFirstTurn = false;
                botOneFirstTurn = false;
                botTwoTurn = false;
                botThreeFirstTurn = false;
                botFourFirstTurn = false;
                botFiveFirstTurn = false;
                if (Chips <= 0)
                {
                    var f2 = new AddChips();
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
                    }
                }
                playerPanel.Visible = false;
                firstBotPanel.Visible = false;
                secondBotPanel.Visible = false;
                thirdBotPanel.Visible = false;
                fourthBotPanel.Visible = false;
                fifthBotPanel.Visible = false;

                playerCall = 0;
                playerRise = 0;
                firstBotCall = 0;
                firstBotRise = 0;
                secondBotCall = 0;
                secondBotRise = 0;
                thirdBotCall = 0;
                thirdBotRise = 0;
                fourthBotCall = 0;
                fourthBotRise = 0;
                fifthBotCall = 0;
                fifthBotRise = 0;

                last = 0;
                call = bigBlind;
                raise = 0;
                ImgLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);
                bools.Clear();

                rounds = 0;
                playerPower = 0;
                playerType = -1;
                type = 0;

                firstBotPower = 0;
                secondBotPower = 0;
                thirdBotPower = 0;
                fourthBotPower = 0;
                fifthBotPower = 0;
                firstBotType = -1;
                secondBotType = -1;
                thirdBotType = -1;
                fourthBotType = -1;
                fifthBotType = -1;

                ints.Clear();
                CheckWinners.Clear();
                winners = 0;
                Win.Clear();
                sorted.Current = 0;
                sorted.Power = 0;

                for (var os = 0; os < 17; os++)
                {
                    Holder[os].Image = null;
                    Holder[os].Invalidate();
                    Holder[os].Visible = false;
                }
                potChips.Text = "0";
                playerStatus.Text = string.Empty;
                await Shuffle();
                await Turns();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="status"></param>
        /// <param name="cCall"></param>
        /// <param name="cRaise"></param>
        /// <param name="options"></param>
        private void FixCall(Label status, ref int cCall, ref int cRaise, int options)
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

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private async Task AllIn()
        {
            #region All in

            if (Chips <= 0 && !intsadded)
            {
                if (playerStatus.Text.Contains("raise"))
                {
                    ints.Add(Chips);
                    intsadded = true;
                }
                if (playerStatus.Text.Contains("Call"))
                {
                    ints.Add(Chips);
                    intsadded = true;
                }
            }
            intsadded = false;
            if (firstBotChips <= 0 && !botOneFirstTurn)
            {
                if (!intsadded)
                {
                    ints.Add(firstBotChips);
                    intsadded = true;
                }
                intsadded = false;
            }
            if (secondBotChips <= 0 && !botTwoTurn)
            {
                if (!intsadded)
                {
                    ints.Add(secondBotChips);
                    intsadded = true;
                }
                intsadded = false;
            }
            if (thirdBotChips <= 0 && !botThreeFirstTurn)
            {
                if (!intsadded)
                {
                    ints.Add(thirdBotChips);
                    intsadded = true;
                }
                intsadded = false;
            }
            if (fourthBotChips <= 0 && !botFourFirstTurn)
            {
                if (!intsadded)
                {
                    ints.Add(fourthBotChips);
                    intsadded = true;
                }
                intsadded = false;
            }
            if (fifthBotChips <= 0 && !botFiveFirstTurn)
            {
                if (!intsadded)
                {
                    ints.Add(fifthBotChips);
                    intsadded = true;
                }
            }
            if (ints.ToArray().Length == maxLeft)
            {
                await Finish(2);
            }
            else
            {
                ints.Clear();
            }

            #endregion

            var winer = bools.Count(x => x == false);

            #region LastManStanding

            if (winer == 1)
            {
                var index = bools.IndexOf(false);
                if (index == 0)
                {
                    Chips += int.Parse(potChips.Text);
                    tableChips.Text = Chips.ToString();
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

                for (var j = 0; j <= 16; j++)
                {
                    Holder[j].Visible = false;
                }
                await Finish(1);
            }
            intsadded = false;

            #endregion

            #region FiveOrLessLeft

            if (winer < 6 && winer > 1 && rounds >= End)
            {
                await Finish(2);
            }

            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private async Task Finish(int n)
        {
            if (n == 2)
            {
                FixWinners();
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
            botTwoTurn = false;
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
            CheckWinners.Clear();
            ints.Clear();
            Win.Clear();
            sorted.Current = 0;
            sorted.Power = 0;
            potChips.Text = "0";

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
                var f2 = new AddChips();
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
                }
            }

            ImgLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);
            for (var os = 0; os < 17; os++)
            {
                Holder[os].Image = null;
                Holder[os].Invalidate();
                Holder[os].Visible = false;
            }
            await Shuffle();
            //await Turns();
        }

        /// <summary>
        /// </summary>
        private void FixWinners()
        {
            Win.Clear();
            sorted.Current = 0;
            sorted.Power = 0;
            var fixedLast = "qwerty";
            if (!playerStatus.Text.Contains("Fold"))
            {
                fixedLast = "Player";
                Rules_ToBeDeleted_NewName_SetGameRules(0, 1, "Player", ref playerType, ref playerPower, PlayerFirstTurn);
            }
            if (!firstBotStatus.Text.Contains("Fold"))
            {
                fixedLast = "Bot 1";
                Rules_ToBeDeleted_NewName_SetGameRules(2, 3, "Bot 1", ref firstBotType, ref firstBotPower, botOneFirstTurn);
            }
            if (!secondBotStatus.Text.Contains("Fold"))
            {
                fixedLast = "Bot 2";
                Rules_ToBeDeleted_NewName_SetGameRules(4, 5, "Bot 2", ref secondBotType, ref secondBotPower, botTwoTurn);
            }
            if (!thirdBotStatus.Text.Contains("Fold"))
            {
                fixedLast = "Bot 3";
                Rules_ToBeDeleted_NewName_SetGameRules(6, 7, "Bot 3", ref thirdBotType, ref thirdBotPower, botThreeFirstTurn);
            }
            if (!fourthBotStatus.Text.Contains("Fold"))
            {
                fixedLast = "Bot 4";
                Rules_ToBeDeleted_NewName_SetGameRules(8, 9, "Bot 4", ref fourthBotType, ref fourthBotPower, botFourFirstTurn);
            }
            if (!fifthBotStatus.Text.Contains("Fold"))
            {
                fixedLast = "Bot 5";
                Rules_ToBeDeleted_NewName_SetGameRules(10, 11, "Bot 5", ref fifthBotType, ref fifthBotPower, botFiveFirstTurn);
            }

            Winner(playerType, playerPower, "Player", Chips, fixedLast);
            Winner(firstBotType, firstBotPower, "Bot 1", firstBotChips, fixedLast);
            Winner(secondBotType, secondBotPower, "Bot 2", secondBotChips, fixedLast);
            Winner(thirdBotType, thirdBotPower, "Bot 3", thirdBotChips, fixedLast);
            Winner(fourthBotType, fourthBotPower, "Bot 4", fourthBotChips, fixedLast);
            Winner(fifthBotType, fifthBotPower, "Bot 5", fifthBotChips, fixedLast);
        }

        #endregion

        #region Alex

        /// <summary>
        ///     x
        /// </summary>
        /// <param name="firstCall">The first call.</param>
        /// <param name="secondCall">The second call.</param>
        /// <param name="sChips">The s chips.</param>
        /// <param name="sTurn">if set to <c>true</c> [s turn].</param>
        /// <param name="sFTurn">if set to <c>true</c> [s f turn].</param>
        /// <param name="sStatus">The s status.</param>
        /// <param name="name">The name.</param>
        /// <param name="botPower">The bot cardsPower.</param>
        /// <param name="botCurrent">The bot curentCardsValue.</param>
        private void AI(int firstCall, int secondCall, ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus,
            int name, double botPower, double botCurrent)
        {
            if (!sFTurn)
            {
                if (botCurrent == -1)
                {
                    HighCard(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower);
                }
                if (botCurrent == 0)
                {
                    PairTable(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower);
                }
                if (botCurrent == 1)
                {
                    PairHand(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower);
                }
                if (botCurrent == 2)
                {
                    TwoPairs(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower);
                }
                if (botCurrent == 3)
                {
                    ThreeOfAKind(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
                }
                if (botCurrent == 4)
                {
                    Straight(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
                }
                if (botCurrent == 5 || botCurrent == 5.5)
                {
                    Flush(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
                }
                if (botCurrent == 6)
                {
                    FullHouse(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
                }
                if (botCurrent == 7)
                {
                    FourOfAKind(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
                }
                if (botCurrent == 8 || botCurrent == 9)
                {
                    StraightFlush(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
                }
            }
            if (sFTurn)
            {
                Holder[firstCall].Visible = false;
                Holder[secondCall].Visible = false;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sChips">The s chips.</param>
        /// <param name="sTurn">if set to <c>true</c> [s turn].</param>
        /// <param name="sFTurn">if set to <c>true</c> [s f turn].</param>
        /// <param name="sStatus">The s status.</param>
        /// <param name="botPower">The bot cardsPower.</param>
        private void HighCard(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower)
        {
            ChooseBotsMoveFirstWay(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower, 20, 25);
        }

        /// <summary>
        /// </summary>
        /// <param name="sChips">The s chips.</param>
        /// <param name="sTurn">if set to <c>true</c> [s turn].</param>
        /// <param name="sFTurn">if set to <c>true</c> [s f turn].</param>
        /// <param name="sStatus">The s status.</param>
        /// <param name="botPower">The bot cardsPower.</param>
        private void PairTable(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower)
        {
            ChooseBotsMoveFirstWay(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower, 16, 25);
        }

        /// <summary>
        ///     Pairs the hand.
        /// </summary>
        /// <param name="sChips">The s chips.</param>
        /// <param name="sTurn">if set to <c>true</c> [s turn].</param>
        /// <param name="sFTurn">if set to <c>true</c> [s f turn].</param>
        /// <param name="sStatus">The s status.</param>
        /// <param name="botPower">The bot cardsPower.</param>
        private void PairHand(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower)
        {
            var pairHandRandom = new Random();
            var rCall = pairHandRandom.Next(10, 16);
            var rRaise = pairHandRandom.Next(10, 13);

            if (botPower <= 199 && botPower >= 140)
            {
                ChooseBotsMoveSecondWay(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 6, rRaise);
            }
            if (botPower <= 139 && botPower >= 128)
            {
                ChooseBotsMoveSecondWay(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 7, rRaise);
            }
            if (botPower < 128 && botPower >= 101)
            {
                ChooseBotsMoveSecondWay(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 9, rRaise);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sChips">The s chips.</param>
        /// <param name="sTurn">if set to <c>true</c> [s turn].</param>
        /// <param name="sFTurn">if set to <c>true</c> [s f turn].</param>
        /// <param name="sStatus">The s status.</param>
        /// <param name="botPower">The bot cardsPower.</param>
        private void TwoPairs(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower)
        {
            var twoPairsRandom = new Random();
            var rCall = twoPairsRandom.Next(6, 11);
            var rRaise = twoPairsRandom.Next(6, 11);

            if (botPower <= 290 && botPower >= 246)
            {
                ChooseBotsMoveSecondWay(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 3, rRaise);
            }
            if (botPower <= 244 && botPower >= 234)
            {
                ChooseBotsMoveSecondWay(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 4, rRaise);
            }
            if (botPower < 234 && botPower >= 201)
            {
                ChooseBotsMoveSecondWay(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 4, rRaise);
            }
        }

        /// <summary>
        ///     Threes the kind of the of a.
        /// </summary>
        /// <param name="sChips">The s chips.</param>
        /// <param name="sTurn">if set to <c>true</c> [s turn].</param>
        /// <param name="sFTurn">if set to <c>true</c> [s f turn].</param>
        /// <param name="sStatus">The s status.</param>
        /// <param name="name">The name.</param>
        /// <param name="botPower">The bot cardsPower.</param>
        private void ThreeOfAKind(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name,
            double botPower)
        {
            var threeOfAKindRandom = new Random();
            var tCall = threeOfAKindRandom.Next(3, 7);
            var tRaise = threeOfAKindRandom.Next(4, 8);
            if (botPower <= 390 && botPower >= 330)
            {
                ChooseBotsMoveThirdWay(ref sChips, ref sTurn, ref sFTurn, sStatus, name, tCall, tRaise);
            }
            if (botPower <= 327 && botPower >= 321) //10  8
            {
                ChooseBotsMoveThirdWay(ref sChips, ref sTurn, ref sFTurn, sStatus, name, tCall, tRaise);
            }
            if (botPower < 321 && botPower >= 303) //7 2
            {
                ChooseBotsMoveThirdWay(ref sChips, ref sTurn, ref sFTurn, sStatus, name, tCall, tRaise);
            }
        }

        #endregion

        #region Tsvetelin

        //botChips/sChips = the curentCardsValue bot's chips
        //isOnTurn/sTurn = the bot is on turn
        //isFinalTurn/sFTurn = the final hand for the game is played (all five cards on table are shown)
        //hasFolded/sStatus = checks if the bot has folded the game
        //botIndex/name = used for Bot indexing, name = 0 is bot 1, name = 1 is Bot 2 and etc.

        private void Straight(ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded,
            int botIndex, double botPower)
        {
            var straightRandomGenerator = new Random();
            var chanceToCall = straightRandomGenerator.Next(3, 6);
            var chanceToRaise = straightRandomGenerator.Next(3, 8);

            //Трите if-а могат да се заменят с един, който ще проверява дали botPower >= 404 && botPower <= 480
            //тъй като и в трите случая извикват един и същи метод с едни и същи параметри
            if (botPower <= 480 && botPower >= 410)
            {
                ChooseBotsMoveThirdWay(ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, chanceToCall,
                    chanceToRaise);
            }
            if (botPower <= 409 && botPower >= 407) //10  8
            {
                ChooseBotsMoveThirdWay(ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, chanceToCall,
                    chanceToRaise);
            }
            if (botPower < 407 && botPower >= 404)
            {
                ChooseBotsMoveThirdWay(ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, chanceToCall,
                    chanceToRaise);
            }
        }

        private void Flush(ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded,
            int botIndex, double botPower)
        {
            var flushRandomGenerator = new Random();
            var chanceToCall = flushRandomGenerator.Next(2, 6);
            var chanceToRaise = flushRandomGenerator.Next(3, 7);
            ChooseBotsMoveThirdWay(ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, chanceToCall,
                chanceToRaise);
        }

        private void FullHouse(ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded,
            int botIndex, double botPower)
        {
            var fullHouseRandomGenerator = new Random();
            var chanceToCall = fullHouseRandomGenerator.Next(1, 5);
            var chanceToRaise = fullHouseRandomGenerator.Next(2, 6);
            if (botPower <= 626 && botPower >= 620)
            {
                ChooseBotsMoveThirdWay(ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, chanceToCall,
                    chanceToRaise);
            }
            if (botPower < 620 && botPower >= 602)
            {
                ChooseBotsMoveThirdWay(ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, chanceToCall,
                    chanceToRaise);
            }
        }

        private void FourOfAKind(ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded,
            int botIndex, double botPower)
        {
            var fourOfAKindRandomGenerator = new Random();
            var chanceToCall = fourOfAKindRandomGenerator.Next(1, 4);
            var chanceToRaise = fourOfAKindRandomGenerator.Next(2, 5);
            if (botPower <= 752 && botPower >= 704)
            {
                ChooseBotsMoveThirdWay(ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, chanceToCall,
                    chanceToRaise);
            }
        }

        private void StraightFlush(ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded,
            int botIndex, double botPower)
        {
            var straightFlushRandomGenerator = new Random();
            var chanceToCall = straightFlushRandomGenerator.Next(1, 3);
            var chanceToRaise = straightFlushRandomGenerator.Next(1, 3);
            if (botPower <= 913 && botPower >= 804)
            {
                ChooseBotsMoveThirdWay(ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, chanceToCall,
                    chanceToRaise);
            }
        }

        private void Fold(ref bool isOnTurn, ref bool isFinalTurn, Label sStatus)
        {
            isRaising = false;
            sStatus.Text = "Fold";
            isOnTurn = false;
            isFinalTurn = true;
        }

        #endregion

        #region Daniela

        //Changes the status label of the bot when it is checking the community cards
        private void ChangeStatusToChecking(ref bool isBotsTurn, Label statusLabel)
        {
            statusLabel.Text = "Check";
            isBotsTurn = false;
            isRaising = false;
        }

        //The bot calls
        private void Call(ref int botChips, ref bool isBotsTurn, Label statusLabel)
        {
            isRaising = false;
            isBotsTurn = false;
            botChips -= call;
            statusLabel.Text = "Call " + call;
            potChips.Text = (int.Parse(potChips.Text) + call).ToString();
        }

        //The bot raises the bet
        private void RaiseBet(ref int botChips, ref bool isBotsTurn, Label statusLabel)
        {
            botChips -= Convert.ToInt32(raise);
            statusLabel.Text = "raise " + raise;
            potChips.Text = (int.Parse(potChips.Text) + Convert.ToInt32(raise)).ToString();
            call = Convert.ToInt32(raise);
            isRaising = true;
            isBotsTurn = false;
        }

        //Calculate the maximum amount of money that the bot can play with on this particular turn
        private static double CalculateMaximumBidAbilityOfTheBot(int botChips, int behaviourFactor)
        {
            var maximumBidChips = Math.Round(botChips / behaviourFactor / 100d, 0) * 100;
            return maximumBidChips;
        }

        //Chooses the bot's move if it has a "High Card" or "Pair" from table combination - not sure about the combinations ???
        private void ChooseBotsMoveFirstWay(ref int botChips, ref bool isBotsTurn, ref bool botFolds, Label statusLabel,
            double botPower, int carefulBehaviourFactor, int riskyBehaviourFactor)
        {
            var rand = new Random();
            var rnd = rand.Next(1, 4);
            if (call <= 0)
            {
                ChangeStatusToChecking(ref isBotsTurn, statusLabel);
            }
            if (call > 0)
            {
                if (rnd == 1)
                {
                    if (call <= CalculateMaximumBidAbilityOfTheBot(botChips, carefulBehaviourFactor))
                    {
                        Call(ref botChips, ref isBotsTurn, statusLabel);
                    }
                    else
                    {
                        Fold(ref isBotsTurn, ref botFolds, statusLabel);
                    }
                }

                if (rnd == 2)
                {
                    if (call <= CalculateMaximumBidAbilityOfTheBot(botChips, riskyBehaviourFactor))
                    {
                        Call(ref botChips, ref isBotsTurn, statusLabel);
                    }
                    else
                    {
                        Fold(ref isBotsTurn, ref botFolds, statusLabel);
                    }
                }
            }
            if (rnd == 3)
            {
                if (raise == 0)
                {
                    raise = call * 2;
                    RaiseBet(ref botChips, ref isBotsTurn, statusLabel);
                }
                else
                {
                    if (raise <= CalculateMaximumBidAbilityOfTheBot(botChips, carefulBehaviourFactor))
                    {
                        raise = call * 2;
                        RaiseBet(ref botChips, ref isBotsTurn, statusLabel);
                    }
                    else
                    {
                        Fold(ref isBotsTurn, ref botFolds, statusLabel);
                    }
                }
            }
            if (botChips <= 0)
            {
                botFolds = true;
            }
        }

        //Chooses the bot's move if it has a "Pair" in the hand or "Two pairs" combinations - not sure about the combinations???
        private void ChooseBotsMoveSecondWay(ref int botChips, ref bool isBotsTurn, ref bool botFolds, Label labelStatus,
            int raiseBehaviourFactor, int behaviourFactorBasedOnBotPower, int callBehaviourFactor)
        {
            var rand = new Random();
            var randomNumber = rand.Next(1, 3);
            if (rounds < 2)
            {
                if (call <= 0)
                {
                    ChangeStatusToChecking(ref isBotsTurn, labelStatus);
                }
                if (call > 0)
                {
                    if (call >= CalculateMaximumBidAbilityOfTheBot(botChips, behaviourFactorBasedOnBotPower))
                    {
                        Fold(ref isBotsTurn, ref botFolds, labelStatus);
                    }
                    if (raise > CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor))
                    {
                        Fold(ref isBotsTurn, ref botFolds, labelStatus);
                    }
                    if (!botFolds)
                    {
                        if (call >= CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor) &&
                            call <= CalculateMaximumBidAbilityOfTheBot(botChips, behaviourFactorBasedOnBotPower))
                        {
                            Call(ref botChips, ref isBotsTurn, labelStatus);
                        }
                        if (raise <= CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor) &&
                            raise >= CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor) / 2)
                        {
                            Call(ref botChips, ref isBotsTurn, labelStatus);
                        }
                        if (raise <= CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor) / 2)
                        {
                            if (raise > 0)
                            {
                                raise = CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor);
                                RaiseBet(ref botChips, ref isBotsTurn, labelStatus);
                            }
                            else
                            {
                                raise = call * 2;
                                RaiseBet(ref botChips, ref isBotsTurn, labelStatus);
                            }
                        }
                    }
                }
            }
            if (rounds >= 2)
            {
                if (call > 0)
                {
                    if (call >=
                        CalculateMaximumBidAbilityOfTheBot(botChips, behaviourFactorBasedOnBotPower - randomNumber))
                    {
                        Fold(ref isBotsTurn, ref botFolds, labelStatus);
                    }
                    if (raise > CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor - randomNumber))
                    {
                        Fold(ref isBotsTurn, ref botFolds, labelStatus);
                    }
                    if (!botFolds)
                    {
                        if (call >= CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor - randomNumber) &&
                            call <=
                            CalculateMaximumBidAbilityOfTheBot(botChips, behaviourFactorBasedOnBotPower - randomNumber))
                        {
                            Call(ref botChips, ref isBotsTurn, labelStatus);
                        }
                        if (raise <= CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor - randomNumber) &&
                            raise >= CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor - randomNumber) / 2)
                        {
                            Call(ref botChips, ref isBotsTurn, labelStatus);
                        }
                        if (raise <= CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor - randomNumber) / 2)
                        {
                            if (raise > 0)
                            {
                                raise = CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor - randomNumber);
                                RaiseBet(ref botChips, ref isBotsTurn, labelStatus);
                            }
                            else
                            {
                                raise = call * 2;
                                RaiseBet(ref botChips, ref isBotsTurn, labelStatus);
                            }
                        }
                    }
                }
                if (call <= 0)
                {
                    raise = CalculateMaximumBidAbilityOfTheBot(botChips, callBehaviourFactor - randomNumber);
                    RaiseBet(ref botChips, ref isBotsTurn, labelStatus);
                }
            }
            if (botChips <= 0)
            {
                botFolds = true;
            }
        }

        //Chooses the bot's move if it has a "ThreeOfAKind", "Straight", "FullHouse", "Flush", "FourOfAKind" or "StraightFlush" combination - not sure about the combinations??? 
        private void ChooseBotsMoveThirdWay(ref int botChips, ref bool isBotsTurn, ref bool botFolds, Label botStatus,
            int name, int behaviourFactor, int r)
        {
            var rand = new Random();
            var rnd = rand.Next(1, 3);
            if (call <= 0)
            {
                ChangeStatusToChecking(ref isBotsTurn, botStatus);
            }
            else
            {
                if (call >= CalculateMaximumBidAbilityOfTheBot(botChips, behaviourFactor))
                {
                    if (botChips > call)
                    {
                        Call(ref botChips, ref isBotsTurn, botStatus);
                    }
                    else if (botChips <= call)
                    {
                        isRaising = false;
                        isBotsTurn = false;
                        botChips = 0;
                        botStatus.Text = "Call " + botChips;
                        potChips.Text = (int.Parse(potChips.Text) + botChips).ToString();
                    }
                }
                else
                {
                    if (raise > 0)
                    {
                        if (botChips >= raise * 2)
                        {
                            raise *= 2;
                            RaiseBet(ref botChips, ref isBotsTurn, botStatus);
                        }
                        else
                        {
                            Call(ref botChips, ref isBotsTurn, botStatus);
                        }
                    }
                    else
                    {
                        raise = call * 2;
                        RaiseBet(ref botChips, ref isBotsTurn, botStatus);
                    }
                }
            }
            if (botChips <= 0)
            {
                botFolds = true;
            }
        }

        #endregion

        #region UI

        private async void timer_Tick(object sender, object e)
        {
            if (progressBarTimer.Value <= 0)
            {
                PlayerFirstTurn = true;
                await Turns();
            }
            if (t > 0)
            {
                t--;
                progressBarTimer.Value = t / 6 * 100;
            }
        }

        private void Update_Tick(object sender, object e)
        {
            if (Chips <= 0)
            {
                tableChips.Text = "Chips : 0";
            }
            if (firstBotChips <= 0)
            {
                tableBot1Chips.Text = "Chips : 0";
            }
            if (secondBotChips <= 0)
            {
                tableBot2Chips.Text = "Chips : 0";
            }
            if (thirdBotChips <= 0)
            {
                tableBot3Chips.Text = "Chips : 0";
            }
            if (fourthBotChips <= 0)
            {
                tableBot4Chips.Text = "Chips : 0";
            }
            if (fifthBotChips <= 0)
            {
                tableBot5Chips.Text = "Chips : 0";
            }
            tableChips.Text = "Chips : " + Chips;
            tableBot1Chips.Text = "Chips : " + firstBotChips;
            tableBot2Chips.Text = "Chips : " + secondBotChips;
            tableBot3Chips.Text = "Chips : " + thirdBotChips;
            tableBot4Chips.Text = "Chips : " + fourthBotChips;
            tableBot5Chips.Text = "Chips : " + fifthBotChips;
            if (Chips <= 0)
            {
                playerTurn = false;
                PlayerFirstTurn = true;
                callButton.Enabled = false;
                raiseButton.Enabled = false;
                foldButton.Enabled = false;
                checkButton.Enabled = false;
            }
            if (up > 0)
            {
                up--;
            }
            if (Chips >= call)
            {
                callButton.Text = "Call " + call;
            }
            else
            {
                callButton.Text = "All in";
                raiseButton.Enabled = false;
            }
            if (call > 0)
            {
                checkButton.Enabled = false;
            }
            if (call <= 0)
            {
                checkButton.Enabled = true;
                callButton.Text = "Call";
                callButton.Enabled = false;
            }
            if (Chips <= 0)
            {
                raiseButton.Enabled = false;
            }
            int parsedValue;

            if (tbRaise.Text != "" && int.TryParse(tbRaise.Text, out parsedValue))
            {
                if (Chips <= int.Parse(tbRaise.Text))
                {
                    raiseButton.Text = "All in";
                }
                else
                {
                    raiseButton.Text = "raise";
                }
            }
            if (Chips < call)
            {
                raiseButton.Enabled = false;
            }
        }

        private async void bFold_Click(object sender, EventArgs e)
        {
            playerStatus.Text = "Fold";
            playerTurn = false;
            PlayerFirstTurn = true;
            await Turns();
        }

        private async void bCheck_Click(object sender, EventArgs e)
        {
            if (call <= 0)
            {
                playerTurn = false;
                playerStatus.Text = "Check";
            }
            else
            {
                //playerStatus.Text = "All in " + Chips;

                checkButton.Enabled = false;
            }
            await Turns();
        }

        private async void bCall_Click(object sender, EventArgs e)
        {
            Rules_ToBeDeleted_NewName_SetGameRules(0, 1, "Player", ref playerType, ref playerPower, PlayerFirstTurn);
            if (Chips >= call)
            {
                Chips -= call;
                tableChips.Text = "Chips : " + Chips;
                if (potChips.Text != "")
                {
                    potChips.Text = (int.Parse(potChips.Text) + call).ToString();
                }
                else
                {
                    potChips.Text = call.ToString();
                }
                playerTurn = false;
                playerStatus.Text = "Call " + call;
                playerCall = call;
            }
            else if (Chips <= call && call > 0)
            {
                potChips.Text = (int.Parse(potChips.Text) + Chips).ToString();
                playerStatus.Text = "All in " + Chips;
                Chips = 0;
                tableChips.Text = "Chips : " + Chips;
                playerTurn = false;
                foldButton.Enabled = false;
                playerCall = Chips;
            }
            await Turns();
        }

        private async void bRaise_Click(object sender, EventArgs e)
        {
            Rules_ToBeDeleted_NewName_SetGameRules(0, 1, "Player", ref playerType, ref playerPower, PlayerFirstTurn);
            int parsedValue;
            if (tbRaise.Text != "" && int.TryParse(tbRaise.Text, out parsedValue))
            {
                if (Chips > call)
                {
                    if (raise * 2 > int.Parse(tbRaise.Text))
                    {
                        tbRaise.Text = (raise * 2).ToString();
                        MessageBox.Show("You must raise atleast twice as the curentCardsValue raise !");
                        return;
                    }
                    if (Chips >= int.Parse(tbRaise.Text))
                    {
                        call = int.Parse(tbRaise.Text);
                        raise = int.Parse(tbRaise.Text);
                        playerStatus.Text = "raise " + call;
                        potChips.Text = (int.Parse(potChips.Text) + call).ToString();
                        callButton.Text = "Call";
                        Chips -= int.Parse(tbRaise.Text);
                        isRaising = true;
                        last = 0;
                        playerRise = Convert.ToInt32(raise);
                    }
                    else
                    {
                        call = Chips;
                        raise = Chips;
                        potChips.Text = (int.Parse(potChips.Text) + Chips).ToString();
                        playerStatus.Text = "raise " + call;
                        Chips = 0;
                        isRaising = true;
                        last = 0;
                        playerRise = Convert.ToInt32(raise);
                    }
                }
            }
            else
            {
                MessageBox.Show("This is a number only field");
                return;
            }
            playerTurn = false;
            await Turns();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (numberOfChipsToAdd.Text == "")
            {
            }
            else
            {
                //Exception handaled
                try
                {
                    Chips += int.Parse(numberOfChipsToAdd.Text);
                    firstBotChips += int.Parse(numberOfChipsToAdd.Text);
                    secondBotChips += int.Parse(numberOfChipsToAdd.Text);
                    thirdBotChips += int.Parse(numberOfChipsToAdd.Text);
                    fourthBotChips += int.Parse(numberOfChipsToAdd.Text);
                    fifthBotChips += int.Parse(numberOfChipsToAdd.Text);
                }
                catch (OverflowException)
                {
                    MessageBox.Show("What you are going to do with all this money", "ARE YOU MAD");
                    numberOfChipsToAdd.Text = "";
                }
                catch (FormatException)
                {
                    MessageBox.Show("Wrong value", "ARE YOU MAD");
                    numberOfChipsToAdd.Text = "";
                }
            }
            tableChips.Text = "Chips : " + Chips;
        }

        private void bOptions_Click(object sender, EventArgs e)
        {
            bigBlindSum.Text = bigBlind.ToString();
            smallBlindSum.Text = smallBlind.ToString();
            if (bigBlindSum.Visible == false)
            {
                bigBlindSum.Visible = true;
                smallBlindSum.Visible = true;
                bigBlindButton.Visible = true;
                smallBlindButton.Visible = true;
            }
            else
            {
                bigBlindSum.Visible = false;
                smallBlindSum.Visible = false;
                bigBlindButton.Visible = false;
                smallBlindButton.Visible = false;
            }
        }

        private void bSB_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (smallBlindSum.Text.Contains(",") || smallBlindSum.Text.Contains("."))
            {
                MessageBox.Show("The Small Blind can be only round number !");
                smallBlindSum.Text = smallBlind.ToString();
                return;
            }
            if (!int.TryParse(smallBlindSum.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                smallBlindSum.Text = smallBlind.ToString();
                return;
            }
            if (int.Parse(smallBlindSum.Text) > 100000)
            {
                MessageBox.Show("The maximum of the Small Blind is 100 000 $");
                smallBlindSum.Text = smallBlind.ToString();
            }
            if (int.Parse(smallBlindSum.Text) < 250)
            {
                MessageBox.Show("The minimum of the Small Blind is 250 $");
            }
            if (int.Parse(smallBlindSum.Text) >= 250 && int.Parse(smallBlindSum.Text) <= 100000)
            {
                smallBlind = int.Parse(smallBlindSum.Text);
                MessageBox.Show("The changes have been saved ! They will become available the next hand you play. ");
            }
        }

        private void bBB_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (bigBlindSum.Text.Contains(",") || bigBlindSum.Text.Contains("."))
            {
                MessageBox.Show("The Big Blind can be only round number !");
                bigBlindSum.Text = bigBlind.ToString();
                return;
            }
            if (!int.TryParse(smallBlindSum.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                smallBlindSum.Text = bigBlind.ToString();
                return;
            }
            if (int.Parse(bigBlindSum.Text) > 200000)
            {
                MessageBox.Show("The maximum of the Big Blind is 200 000");
                bigBlindSum.Text = bigBlind.ToString();
            }
            if (int.Parse(bigBlindSum.Text) < 500)
            {
                MessageBox.Show("The minimum of the Big Blind is 500 $");
            }
            if (int.Parse(bigBlindSum.Text) >= 500 && int.Parse(bigBlindSum.Text) <= 200000)
            {
                bigBlind = int.Parse(bigBlindSum.Text);
                MessageBox.Show("The changes have been saved ! They will become available the next hand you play. ");
            }
        }

        private void Layout_Change(object sender, LayoutEventArgs e)
        {
            width = Width;
            height = Height;
        }

        #endregion

    }
}