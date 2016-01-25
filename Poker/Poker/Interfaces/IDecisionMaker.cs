namespace Poker.Interfaces
{
    using Poker.Interfacees;
    using System.Collections.Generic;
    using System.Windows.Forms;


    /// <summary>
    /// The decision maker is artificial inteligence of the bot
    /// </summary>
    public interface IDecisionMaker
    {
        void MakeDecision(ICharacter character, IList<ICard> cardCollection,
            int firstCard, int secondCard, ref int botChips, ref bool isOnTurn,
            ref bool isFinalTurn, Label hasFolded, int botIndex, double botPower,
            double behaviourPower);
    }
}
