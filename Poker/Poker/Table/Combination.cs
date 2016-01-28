namespace Poker.Table
{
    using Enumerations;
    using Interfacees;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class Combination : ICombination
    {
        public Combination(double power, CombinationType type, double behaviourPower,
                           IList<ICard> combinationCardsCollection, IList<ICard> kickersCollection)
        {
            this.Power = power;
            this.Type = type;
            this.BehaviourPower = behaviourPower;
            this.CombinationCardsCollection = combinationCardsCollection;
            this.KickersCollection = kickersCollection;
        }

        public IList<ICard> KickersCollection { get; set; }
        public IList<ICard> CombinationCardsCollection { get; set; }

        public IList<ICard> Hand
        {
            get
            {
                IList<ICard> hand = this.CombinationCardsCollection.Union(this.KickersCollection).ToList();
                return hand;
            }
        }

        public double Power { get; set; }

        public CombinationType Type { get; set; }

        public double BehaviourPower { get; set; }
    }
}