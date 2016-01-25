using System.Drawing;
using Poker.Enumerations;

namespace Poker.Interfacees
{
    public interface ICard
    {
        bool IsVisible { get; set; }
        Image FrontImage { get; }
        Image BackImage { get; }
        CardSuit Suit { get; }
        CardRank Rank { get; set; }
    }
}