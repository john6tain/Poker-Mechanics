namespace Poker.Interfaces
{
    using Enumerations;
    using Interfacees;
    using System.Collections.Generic;

    public interface ICombination
    {
        IList<ICard> KickersCollection { get; set; }
        IList<ICard> CombinationCardsCollection { get; set; }
        IList<ICard> Hand { get; }
        CombinationType Type { get; set; }
        double Power { get; set; }
        double BehaviourPower { get; set; }
    }
}