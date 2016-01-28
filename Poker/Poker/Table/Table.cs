using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows.Forms;
using Poker.Interfacees;
using Poker.Interfaces;

namespace Poker.Table
{
    public class Table : ITable
    {
        private int pot;
        public IList<ICard> TableCardsCollection { get; set; }



        public void TakeCall(int callSum, TextBox tablePotSum)
        {
            this.Pot += callSum;
            tablePotSum.Text = this.Pot.ToString();
        }

        public int Pot
        {
            get { return this.pot; }
            set
            {
                int outTemp;
                if (value >= 0 || int.TryParse(value.ToString(), out outTemp) == true)
                {

                }

                this.pot = value;
            }
        }
    }
}