using Poker.Interfacees;
using System.Collections.Generic;
using Poker.Enumerations;

namespace Poker.Interfaces
{
    public interface ICombination
    {
        IList<ICard> TheOtherCardsFromTheHandNotIncludedInTheCombination { get; set; }
        double Power { get; set; }
        CombinationType Type { get; set; }
        double BehaviourPower { get; set; }
    }
}
