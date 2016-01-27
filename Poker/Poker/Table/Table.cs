using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows.Forms;
using Poker.Interfacees;
using Poker.Interfaces;

namespace Poker.Table
{
    public class Table : ITable
    {
        public IList<ICard> TableCardsCollection { get; set; }

        public int Pot { get; set; }

        public void TakeCall(int callSum, TextBox tablePotSum)
        {
            this.Pot += callSum;
            tablePotSum.Text = this.Pot.ToString();
        }
    }
}