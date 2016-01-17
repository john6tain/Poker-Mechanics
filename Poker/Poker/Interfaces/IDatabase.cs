using System.Collections.Generic;

namespace Poker.Interfacees
{
    public interface IDatabase
    {
        IList<ICard> Deck { get; set; }
    }
}