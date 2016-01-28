using System.Drawing;
using System.Windows.Forms;
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
        PictureBox CardPictureBox { get; set; }

        void Update(Control.ControlCollection controls);
    }
}