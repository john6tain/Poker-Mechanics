using Poker.Interfacees;
using System.Collections.Generic;
using Poker.Enumerations;

namespace Poker.Interfaces
{
    public interface ICombination
    {
        IList<ICard> TheOtherCardsFromTheHandNotIncludedInTheCombination { get; set; }
        IList<ICard> TheCombinationCards { get; set; }
        IList<ICard> Hand { get; }

        double Power { get; set; }
        CombinationType Type { get; set; }
        double BehaviourPower { get; set; }
    }
}
