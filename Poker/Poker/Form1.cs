// ***********************************************************************
// Assembly         : Poker
// Author           : Team "Currant"
// ***********************************************************************
// <copyright file="Poker" team="Currant">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using Poker.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.Character;
using Poker.GameConstants;
using Poker.Interfacees;
using Poker.Table;

namespace Poker
{
    public partial class Form1 : Form
    {
        public const int InitialCallValue = 500;

        private ICharacter bot1;
        private ICharacter bot2;
        private ICharacter bot3;
        private ICharacter bot4;
        private ICharacter bot5;
        private ICharacter player;
        private IDatabase database;
        private IDecisionMaker decisionMaker;
        private ITable table;
        private IDealer dealer;
        private int callSum;


        public Form1()
        {
            InitializeComponent();
            InitializeGameObjects();

            Dealer.SetupGame(GameDatabase, Player, Bot1, Bot2, Bot3, Bot4, Bot5, Table, Controls);

            EnableButtons();
            //RotateTimer.Start();
        }

        private void EnableButtons()
        {
            this.foldButton.Enabled = true;
            this.checkButton.Enabled = true;
            this.callButton.Enabled = true;
            this.raiseButton.Enabled = true;
        }

        private void InitializeGameObjects()
        {
            this.Bot1 = new Bot(new Point(Constants.FirstBotCoordinateX, Constants.FirstBotCoordinateY), Constants.CardWidth);
            this.Bot2 = new Bot(new Point(Constants.SecondBotCoordinateX, Constants.SecondBotCoordinateY), Constants.CardWidth);
            this.Bot3 = new Bot(new Point(Constants.ThirdBotCoordinateX, Constants.ThirdBotCoordinateY), Constants.CardWidth);
            this.Bot4 = new Bot(new Point(Constants.FourthBotCoordinateX, Constants.FourthBotCoordinateY), Constants.CardWidth);
            this.Bot5 = new Bot(new Point(Constants.FifthBotCoordinateX, Constants.FifthBotCoordinateY), Constants.CardWidth);
            this.Player = new Player(new Point(Constants.PlayerCoordinateX, Constants.PlayerCoordinateY), Constants.CardWidth);
            this.Bot1.Name = "Bot1";
            this.Bot2.Name = "Bot2";
            this.Bot3.Name = "Bot3";
            this.Bot4.Name = "Bot4";
            this.Bot5.Name = "Bot5";
            this.Player.Name = "Player";
            this.GameDatabase = new DataBase.DataBase();
            this.DecisionMaker = new DecisionMaker();
            this.Table = new Table.Table();
            this.Dealer = new Dealer();
            this.CallSum = InitialCallValue;
            this.CharactersCollection = new List<ICharacter>();
            InitializeCharactersCollection();

        }

        public void InitializeCharactersCollection()
        {
            this.CharactersCollection.Add(this.Player);
            this.CharactersCollection.Add(this.Bot1);
            this.CharactersCollection.Add(this.Bot2);
            this.CharactersCollection.Add(this.Bot3);
            this.CharactersCollection.Add(this.Bot4);
            this.CharactersCollection.Add(this.Bot5);
        }

        public ICharacter Bot1 { get; set; }
        public ICharacter Bot2 { get; set; }
        public ICharacter Bot3 { get; set; }
        public ICharacter Bot4 { get; set; }
        public ICharacter Bot5 { get; set; }
        public ICharacter Player { get; set; }
        public IDatabase GameDatabase { get; set; }
        public IDecisionMaker DecisionMaker { get; set; }
        public ITable Table { get; set; }
        public IDealer Dealer { get; set; }
        public bool GameIsSet { get; set; }
        public int Index { get; set; }
        public IList<ICharacter> CharactersCollection { get; set; }
        public int CallSum { get; set; }


        private void tbBotChips2_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void tbRaise_TextChanged(object sender, EventArgs e)
        {
        }



        private async void timer_Tick(object sender, object e)
        {

        }

        private void Update_Tick(object sender, object e)
        {

        }

        private async void bFold_Click(object sender, EventArgs e)
        {
            Label statusLabelToUpdate = GetControl();

            this.CharactersCollection[this.Index].Fold(statusLabelToUpdate);

            //ContinueRotating();
        }

        private Label GetControl()
        {
            string controlName = "" + this.CharactersCollection[this.Index].Name + "StatusLabel";
            Label searchedControl = (Label) Controls.Find(controlName, true)[0];
            return searchedControl;
        }

        private void ContinueRotating()
        {
            if (this.RotateTimer.Enabled == false)
            {
                RotateTimer.Start();
            }
        }

        private async void bCheck_Click(object sender, EventArgs e)
        {
            Label statusLabelToUpdate = GetControl();

            this.CharactersCollection[this.Index].ChangeStatusToChecking(statusLabelToUpdate);

            RevealTheNextCard();

            //ContinueRotating();
        }

        private void RevealTheNextCard()
        {
            for (int i = 0; i < this.Table.TableCardsCollection.Count; i++)
            {
                if (this.Table.TableCardsCollection[i].IsVisible != true)
                {
                    this.Table.TableCardsCollection[i].IsVisible = true;
                    break;
                }
            }
        }

        private async void bCall_Click(object sender, EventArgs e)
        {
            Label statusLabelToUpdate = GetControl();

            string newText = "Call " + this.CallSum;

            UpdateStatusLabel(newText, statusLabelToUpdate);


            this.CharactersCollection[this.Index].Call(this.CallSum);

            //ContinueRotating();
        }

        private void UpdateStatusLabel(string newText, Label statusLabelToUpdate)
        {
            statusLabelToUpdate.Text = newText;
        }

        private async void bRaise_Click(object sender, EventArgs e)
        {
            //ContinueRotating();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
        }

        private void bOptions_Click(object sender, EventArgs e)
        {

        }

        private void bSB_Click(object sender, EventArgs e)
        {

        }

        private void bBB_Click(object sender, EventArgs e)
        {

        }

        private void Layout_Change(object sender, LayoutEventArgs e)
        {

        }



        private void RotateTimer_Tick(object sender, EventArgs e)
        {
            this.Index++;

            if (this.Index >= this.CharactersCollection.Count)
            {
                this.Index = 0;
            }

            this.Dealer.SetGameRules(this.CharactersCollection[this.Index].CharacterCardsCollection, this.Table.TableCardsCollection, this.CharactersCollection[this.Index]);

            if (this.CharactersCollection[this.Index].Name == "Player")
            {
                this.RotateTimer.Stop();
            }

            this.CharactersCollection[this.Index].Decide(this.CharactersCollection[this.Index], this.CharactersCollection[this.Index].CharacterCardsCollection, 0, 1, 1000, false, new Label(), this.Index, 20, CharactersCollection[this.Index].CardsCombination.BehaviourPower, this.CallSum);
        }
    }
}