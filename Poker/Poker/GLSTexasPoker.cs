// ***********************************************************************
// Assembly         : Poker
// Author           : Team "Currant"
// ***********************************************************************
// <copyright file="Poker" team="Currant">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Poker
{
    using Character;
    using GameConstants;
    using Interfacees;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Table;

    public partial class GLSTexasPoker : Form
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

        public GLSTexasPoker()
        {
            InitializeComponent();
            InitializeGameObjects();

            Dealer.SetupGame(GameDatabase, Player, Bot1, Bot2, Bot3, Bot4, Bot5, Table, Controls);

            EnableButtons();

            this.GameUpdate.Start();
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
            this.Bot1.Chips = 10000;
            this.Bot2.Chips = 10000;
            this.Bot3.Chips = 10000;
            this.Bot4.Chips = 10000;
            this.Bot5.Chips = 10000;
            this.Player.Chips = 10000;
            this.Bot1.ChipsLabel.Text = "Chips: " + this.Bot1.Chips.ToString();
            this.Bot2.ChipsLabel.Text = "Chips: " + this.Bot2.Chips.ToString();
            this.Bot3.ChipsLabel.Text = "Chips: " + this.Bot3.Chips.ToString();
            this.Bot4.ChipsLabel.Text = "Chips: " + this.Bot4.Chips.ToString();
            this.Bot5.ChipsLabel.Text = "Chips: " + this.Bot5.Chips.ToString();
            this.Player.ChipsLabel.Text = "Chips: " + this.Player.Chips.ToString();
            Controls.Add(this.Bot1.ChipsLabel);
            Controls.Add(this.Bot2.ChipsLabel);
            Controls.Add(this.Bot3.ChipsLabel);
            Controls.Add(this.Bot4.ChipsLabel);
            Controls.Add(this.Bot5.ChipsLabel);
            Controls.Add(this.Player.ChipsLabel);
            this.GameDatabase = new DataBase.DataBase();
            this.DecisionMaker = new DecisionMaker();
            this.Table = new Table.Table();
            this.Dealer = new Dealer();
            this.CallSum = InitialCallValue;
            this.CharactersCollection = new List<ICharacter>();
            InitializeCharactersCollection();
        }

        private TextBox GetTextBox(string textAround, ICharacter a)
        {
            string labelName = "" + this.CharactersCollection[this.Index].Name + textAround;
            TextBox searchedTextBox = (TextBox)Controls.Find(labelName, true)[0];
            return searchedTextBox;
        }

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
            Label statusLabelToUpdate = GetLabel("StatusLabel");

            this.CharactersCollection[this.Index].Fold(statusLabelToUpdate);

            //DisablePlayerButtons(this.callButton, this.foldButton, this.checkButton, this.raiseButton);

            //StartBotRotation();
        }

        private Label GetLabel(string textAround)
        {
            string labelName = "" + this.CharactersCollection[this.Index].Name + textAround;
            Label searchedLabel = (Label)Controls.Find(labelName, true)[0];
            return searchedLabel;
        }

        private void StartBotRotation()
        {
            if (this.RotateTimer.Enabled == false)
            {
                RotateTimer.Start();
            }
        }

        private async void bCheck_Click(object sender, EventArgs e)
        {

            //The bellow code reveals 1 card from the table cards

            Label statusLabelToUpdate = GetLabel("StatusLabel");

            string newText = "Check ";

            this.CharactersCollection[this.Index].ChangeStatusToChecking();

            UpdateStatusLabel(newText, statusLabelToUpdate);

            this.Dealer.RevealTheNextCard(this.Table);


            //The bellow block was meant to be executed in the original version of the game. 
            //After the player makes his turn by pressing a button, starts the rotating of the bots.

            //DisablePlayerButtons(this.callButton, this.foldButton, this.checkButton, this.raiseButton);

            //StartBotRotation();
        }

        private void MakeAllCardsVisible()
        {
            foreach (var element in this.Table.TableCardsCollection)
            {
                element.IsVisible = true;
            }

            foreach (var element in this.CharactersCollection)
            {
                foreach (var card in element.CharacterCardsCollection)
                {
                    card.IsVisible = true;
                }
            }
        }

        private async void bCall_Click(object sender, EventArgs e)
        {
            this.CharactersCollection[this.Index].Call(this.CallSum);

            this.Table.TakeCall(this.CallSum, potChips);

            Label statusLabelToUpdate = GetLabel("StatusLabel");

            string newText = "Call " + this.CallSum;

            UpdateStatusLabel(newText, statusLabelToUpdate);


            //DisablePlayerButtons(this.callButton, this.foldButton, this.checkButton, this.raiseButton);
            //StartBotRotation();
        }


        private void DisablePlayerButtons(Button callButton, Button foldButton, Button checkButton, Button raiseButton)
        {
            callButton.Enabled = false;
            foldButton.Enabled = false;
            checkButton.Enabled = false;
            raiseButton.Enabled = false;
        }

        private void UpdateStatusLabel(string newText, Label statusLabelToUpdate)
        {
            statusLabelToUpdate.Text = newText;
        }

        private async void bRaise_Click(object sender, EventArgs e)
        {
            //Raise the call minimum
            this.CallSum += int.Parse(this.tbRaise.Text);

            this.CharactersCollection[this.Index].Call(this.CallSum);

            this.Table.TakeCall(this.CallSum, potChips);

            Label statusLabelToUpdate = GetLabel("StatusLabel");

            string newText = "Raise " + int.Parse(this.tbRaise.Text);

            UpdateStatusLabel(newText, statusLabelToUpdate);

            //StartBotRotation();
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

            Label characterLabel = new Label();

            if (CharactersCollection[this.Index].Name == "Bot1")
            {
                characterLabel = Bot1StatusLabel;
            }
            else if (CharactersCollection[this.Index].Name == "Bot2")
            {
                characterLabel = Bot2StatusLabel;
            }
            else if (CharactersCollection[this.Index].Name == "Bot3")
            {
                characterLabel = Bot3StatusLabel;
            }
            else if (CharactersCollection[this.Index].Name == "Bot4")
            {
                characterLabel = Bot4StatusLabel;
            }
            else if (CharactersCollection[this.Index].Name == "Bot5")
            {
                characterLabel = Bot5StatusLabel;
            }

            this.CharactersCollection[this.Index].Decide(this.CharactersCollection[this.Index], this.CharactersCollection[this.Index].CharacterCardsCollection, 0, 1, 1000, false, characterLabel, this.Index, 20, CharactersCollection[this.Index].CardsCombination.BehaviourPower, this.CallSum);
        }

        private void CardsRenderer_Tick(object sender, EventArgs e)
        {
        }

        private void GameRenderer_Tick(object sender, EventArgs e)
        {
        }

        private void GameRenderer_Tick_1(object sender, EventArgs e)
        {
        }

        private void CardsRenderer_Tick_1(object sender, EventArgs e)
        {
        }

        private void GameUpdate_Tick(object sender, EventArgs e)
        {
            foreach (var element in this.Table.TableCardsCollection)
            {
                element.Update(Controls);
            }

            foreach (var character in this.CharactersCollection)
            {
                foreach (var card in character.CharacterCardsCollection)
                {
                    card.Update(Controls);
                }
            }

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

        private void checkAllButton_Click(object sender, EventArgs e)
        {
            MakeAllCardsVisible();
        }

        private void checkWinnersButton_Click(object sender, EventArgs e)
        {
            foreach (var character in this.CharactersCollection)
            {
                this.Dealer.SetGameRules(character.CharacterCardsCollection, this.Table.TableCardsCollection, character);
            }

            this.Dealer.DeclareWinner(this.CharactersCollection, this.Table.Pot);
        }
    }
}