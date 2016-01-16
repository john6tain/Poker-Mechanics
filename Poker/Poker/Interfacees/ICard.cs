using Poker.Enumerations;

namespace Poker.Interfacees
{
    public interface ICard
    {
        CardSuit Suit { get; set; }
        CardRank Rank { get; set; }
    }
}