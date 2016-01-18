using Poker.Enumerations;

namespace Poker.Interfacees
{
    public interface ICard
    {
        bool isVisible { get; set; }
        CardSuit Suit { get; set; }
        CardRank Rank { get; set; }
    }
}