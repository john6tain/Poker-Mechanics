using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfacees;
using Poker.Interfaces;

namespace Poker.Table
{
    class Combination : ICombination
    {
        public Combination(double power, int cardCombinationCode, string characterName, IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination)
        {
            this.Power = power;
            this.CardCombinationCode = cardCombinationCode;
            this.CharacterName = characterName;
            this.TheOtherCardsFromTheHandNotIncludedInTheCombination = theOtherCardsFromTheHandNotIncludedInTheCombination;
        }

        public IList<ICard> TheOtherCardsFromTheHandNotIncludedInTheCombination { get; set; }
        public string CharacterName { get; set; }
        public double Power { get; set; }
        public int CardCombinationCode { get; set; }
    }
}
