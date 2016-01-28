namespace Poker.Interfacees
{
    using Enumerations;
    using System.Drawing;
    using System.Windows.Forms;

    public interface ICard
    {
        bool IsVisible { get; set; }
        Image FrontImage { get; }
        Image BackImage { get; }
        CardSuit Suit { get; }
        CardRank Rank { get; set; }
        PictureBox CardPictureBox { get; set; }

        /// <summary>
        /// Updates the specified controls.
        /// </summary>
        /// <param name="controls">The controls.</param>
        void Update(Control.ControlCollection controls);
    }
}