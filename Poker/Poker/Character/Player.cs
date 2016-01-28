namespace Poker.Character
{
    using Interfacees;
    using Interfaces;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public class Player : Character
    {
        public Player(Point firstCardLocation, int cardWidth)
               : base(firstCardLocation, cardWidth)
        {
        }

        public override void Decide(ICharacter character, IList<ICard> cardCollection,
                                   int firstCard, int secondCard, int botChips,
                                   bool isFinalTurn, Label hasFolded, int botIndex,
                                   double botPower, double behaviourPower, int callSum)
        {
            this.IsOnTurn = true;
        }
    }
}