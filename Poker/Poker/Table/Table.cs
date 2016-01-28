namespace Poker.Table
{
    using Interfacees;
    using Interfaces;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class Table : ITable
    {
        private int pot;

        public int Pot
        {
            get { return this.pot; }
            set
            {
                int outTemp;
                if (value >= 0 || int.TryParse(value.ToString(), out outTemp) == true)
                {
                    //throw new ?
                }
                this.pot = value;
            }
        }

        public IList<ICard> TableCardsCollection { get; set; }

        /// <summary>
        /// Takes and sum the call.
        /// </summary>
        /// <param name="callSum">The call sum.</param>
        /// <param name="tablePotSum">The table pot sum.</param>
        public void TakeCall(int callSum, TextBox tablePotSum)
        {
            this.Pot += callSum;
            tablePotSum.Text = this.Pot.ToString();
        }
    }
}