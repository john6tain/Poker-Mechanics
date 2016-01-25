using System.Collections.Generic;
using Poker.Interfacees;
using Poker.Interfaces;

namespace Poker.Table
{
    public class Table : ITable
    {
        public IList<ICard> TableCardsCollection { get; set; }

        public int Pot { get; set; }
    }
}