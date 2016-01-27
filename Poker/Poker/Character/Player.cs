using System.Collections.Generic;
using System.Windows.Forms;
using Poker.Interfacees;
using Poker.Interfaces;
﻿using System.Drawing;

namespace Poker.Character
{
    public class Player : Character
    {
        public Player(Point firstCardLocation, int cardWidth) : base(firstCardLocation, cardWidth)
        {
        }

        public override void Decide(ICharacter character, IList<ICard> cardCollection, int firstCard, int secondCard,
    int botChips, bool isFinalTurn, Label hasFolded, int botIndex, double botPower, double behaviourPower)
        {
            this.IsOnTurn = true;
        }
    }
}