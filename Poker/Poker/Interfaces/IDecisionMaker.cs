namespace Poker.Interfaces
{
    using System.Windows.Forms;

    /// <summary>
    /// The decision maker is artificial inteligence of the bot
    /// </summary>
    public interface IDecisionMaker
    {
        /// <summary>
        /// Makes the decision for specified combination.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="firstCard">The first card.</param>
        /// <param name="secondCard">The second card.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botIndex">Index of the bot.</param>
        /// <param name="botPower">The bot power.</param>
        /// <param name="behaviourPower">The behaviour power.</param>
        /// <param name="callSum">The call sum.</param>
        void MakeDecision(ICharacter character,
            int firstCard, int secondCard, ref int botChips, bool isOnTurn,
            ref bool isFinalTurn, Label hasFolded, int botIndex, double botPower,
            double behaviourPower, int callSum);
    }
}
