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
    public partial class GLSTexasPoker : Form
    {
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


        public GLSTexasPoker()
        {
            InitializeComponent();
            InitializeGameObjects();
      
            Dealer.SetupGame(GameDatabase, Player, Bot1, Bot2, Bot3, Bot4, Bot5, Table, Controls);

            //RotateTimer.Start();
        }

        private void InitializeGameObjects()
        {
            this.Bot1 = new Bot(new Point(Constants.FirstBotCoordinateX,Constants.FirstBotCoordinateY), Constants.CardWidth);
            this.Bot2 = new Bot(new Point(Constants.SecondBotCoordinateX, Constants.SecondBotCoordinateY), Constants.CardWidth);
            this.Bot3 = new Bot(new Point(Constants.ThirdBotCoordinateX, Constants.ThirdBotCoordinateY), Constants.CardWidth);
            this.Bot4 = new Bot(new Point(Constants.FourthBotCoordinateX, Constants.FourthBotCoordinateY), Constants.CardWidth);
            this.Bot5 = new Bot(new Point(Constants.FifthBotCoordinateX, Constants.FifthBotCoordinateY), Constants.CardWidth);
            this.Player = new Player(new Point(Constants.PlayerCoordinateX, Constants.PlayerCoordinateY), Constants.CardWidth);
            this.GameDatabase = new DataBase.DataBase();
            this.DecisionMaker = new DecisionMaker();
            this.Table = new Table.Table();
            this.Dealer = new Dealer();
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
        public IList <ICharacter> CharactersCollection { get; set; }


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

        }

        private async void bCheck_Click(object sender, EventArgs e)
        {

        }

        private async void bCall_Click(object sender, EventArgs e)
        {

        }

        private async void bRaise_Click(object sender, EventArgs e)
        {

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

        private void Renderer_Tick(object sender, EventArgs e)
        {
            if (this.CharactersCollection[this.Index].Name == "player")
            {

            }
        }

        private void RotateTimer_Tick(object sender, EventArgs e)
        {
            this.Index++;

            if (this.Index >= this.CharactersCollection.Count)
            {
                this.Index = 0;
            }

            this.Dealer.SetGameRules(this.CharactersCollection[this.Index].CharacterCardsCollection, this.Table.TableCardsCollection, this.CharactersCollection[this.Index]);
            this.CharactersCollection[this.Index].Decide(this.CharactersCollection[this.Index], this.CharactersCollection[this.Index].CharacterCardsCollection, 2, 3, 1000, false, new Label(), 4, 20, 3);

            if (this.CharactersCollection[this.Index].Name == "player")
            {
                this.RotateTimer.Stop();
            }

        }
    }
}