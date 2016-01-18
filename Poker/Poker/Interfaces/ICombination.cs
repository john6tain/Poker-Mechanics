using Poker.Interfacees;
using System.Collections.Generic;

namespace Poker.Interfaces
{
    public interface ICombination
    {
        IList<ICard> TheOtherCardsFromTheHandNotIncludedInTheCombination { get; set; }
        string CharacterName { get; set; }
        double Power { get; set; }
        int CardCombinationCode { get; set; }
    }
}
