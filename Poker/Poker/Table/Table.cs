using System.Collections.Generic;
using Poker.Interfacees;
using Poker.Interfaces;

namespace Poker.Table
{
    public class Table : ITable
    {
        private int pot;
        public IList<ICard> TableCardsCollection { get; set; }

        public int Pot
        {
            get { return pot; }
            set
            {
                int outTemp;
                if (value >= 0 || int.TryParse(value.ToString(), out outTemp) == true)
                {

                }
            }
        }
    }
}