using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfacees;

namespace Poker.Interfaces
{
    interface ICombination
    {
        IList<ICard> TheOtherCardsFromTheHandNotIncludedInTheCombination { get; set; }
        string CharacterName { get; set; }
        double Power { get; set; }
        int CardCombinationCode { get; set; }
    }
}
