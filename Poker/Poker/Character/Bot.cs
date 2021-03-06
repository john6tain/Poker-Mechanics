﻿namespace Poker.Character
{
    using Interfacees;
    using Interfaces;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public class Bot : Character
    {
        private readonly IDecisionMaker decisionMaker;

        /// <summary>
        /// Initializes a new instance of DecisionMaker class.
        /// </summary>
        public Bot(Point firstCardLocation, int cardWidth)
            : base(firstCardLocation, cardWidth)
        {
            this.decisionMaker = new DecisionMaker();
        }

        /// <summary>
        /// Decides the winning combination.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="cardCollection">The card collection.</param>
        /// <param name="firstCard">The first card.</param>
        /// <param name="secondCard">The second card.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botIndex">Index of the bot.</param>
        /// <param name="botPower">The bot power.</param>
        /// <param name="behaviourPower">The behaviour power.</param>
        public override void Decide(
            ICharacter character, IList<ICard> cardCollection,
            int firstCard, int secondCard, int botChips,
            bool isFinalTurn, Label hasFolded, int botIndex, double botPower,
            double behaviourPower, int callSum)
        {
            this.decisionMaker.MakeDecision(
                character, firstCard, secondCard,
                ref botChips, this.IsOnTurn,
                ref isFinalTurn, hasFolded,
                botIndex, botPower, behaviourPower, callSum);
        }
    }
}