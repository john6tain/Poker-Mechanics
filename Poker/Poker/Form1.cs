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
using Poker.Interfacees;
using Poker.Table;

namespace Poker
{
    public partial class Form1 : Form
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


        public Form1()
        {
            InitializeComponent();
            InitializeGameObjects();
            //dealer.SetupGame(database, player, bot1, bot2, bot3, bot4, bot5, table);
            Dealer.SetupGame(GameDatabase, Player, Bot1, Bot2, Bot3, Bot4, Bot5, Table, Controls);

        }

        private void InitializeGameObjects()
        {
            this.Bot1 = new Bot();
            this.Bot2 = new Bot();
            this.Bot3 = new Bot();
            this.Bot4 = new Bot();
            this.Bot5 = new Bot();
            this.Player = new Player();
            this.GameDatabase = new DataBase.DataBase();
            this.DecisionMaker = new DecisionMaker();
            this.Table = new Table.Table();
            this.Dealer = new Dealer();
        }

        ICharacter Bot1 { get; set; }
        ICharacter Bot2 { get; set; }
        ICharacter Bot3 { get; set; }
        ICharacter Bot4 { get; set; }
        ICharacter Bot5 { get; set; }
        ICharacter Player { get; set; }
        IDatabase GameDatabase { get; set; }
        IDecisionMaker DecisionMaker { get; set; }
        ITable Table { get; set; }
        IDealer Dealer { get; set; }




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
    }
}