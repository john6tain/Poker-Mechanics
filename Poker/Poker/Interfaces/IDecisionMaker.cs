namespace Poker.Interfaces
{
    using System.Windows.Forms;

    /// <summary>
    /// The decision maker is artificial inteligence of the bot
    /// </summary>
    public interface IDecisionMaker
    {
        void MakeDecision(ICharacter character,
            int firstCard, int secondCard, ref int botChips, bool isOnTurn,
            ref bool isFinalTurn, Label hasFolded, int botIndex, double botPower,
            double behaviourPower, int callSum);
    }
}
