using System.Collections.Generic;

namespace Poker.Interfacees
{
    public interface IDatabase
    {
        IEnumerable<ICard> Deck { get; }
    }
}