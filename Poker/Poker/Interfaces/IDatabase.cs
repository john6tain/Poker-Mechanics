namespace Poker.Interfacees
{
    using System.Collections.Generic;

    public interface IDatabase
    {
        IEnumerable<ICard> Deck { get; }
    }
}