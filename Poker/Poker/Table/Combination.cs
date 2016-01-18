using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Enumerations;
using Poker.Interfacees;
using Poker.Interfaces;

namespace Poker.Table
{
    class Combination : ICombination
    {
        public Combination(double power, CombinationType type, double behaviourPower, IList<ICard> theCombinationCards, IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination)
        {
            this.Power = power;
            this.Type = type;
            this.BehaviourPower = behaviourPower;
            this.TheCombinationCards = theCombinationCards;
            this.TheOtherCardsFromTheHandNotIncludedInTheCombination = theOtherCardsFromTheHandNotIncludedInTheCombination;
        }

        public IList<ICard> TheOtherCardsFromTheHandNotIncludedInTheCombination { get; set; }
        public IList<ICard> TheCombinationCards { get; set; }
        public double Power { get; set; }
        public CombinationType Type { get; set; }
        public double BehaviourPower { get; set; }
    }
}
