﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfacees;

namespace Poker.Interfaces
{
    interface ITable
    {
        IList<ICard> TableCardsCollection { get; set; }
        int Pot { get; set; }
    }
}
