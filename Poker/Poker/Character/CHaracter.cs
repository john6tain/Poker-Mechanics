// ***********************************************************************
// Assembly         : Poker
// Class Author     : Alex
//
// Last Modified By : Alex
// Last Modified On : 20 Jan 2016
// ***********************************************************************
// <copyright file="Character.cs" team="Currant">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Poker.Character
{
    using Interfaces;
    using System;
    using System.Windows.Forms;

    public abstract class Character : ICharacter
    {
        public ICombination CardsCombination { get; set; }

        private bool isRaising;
        /// <summary>
        /// Fold tell us who is giving up
        /// </summary>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        public void Fold(ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded)
        {
            isRaising = false;
            hasFolded.Text = "Fold";
            isOnTurn = false;
            isFinalTurn = true;
        }

        /// <summary>
        /// Changes the label status to checking.
        /// </summary>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="statusLabel">The status label.</param>
        public void ChangeStatusToChecking(ref bool isBotsTurn, Label statusLabel)
        {
            statusLabel.Text = "Check";
            isBotsTurn = false;
            isRaising = false;
        }

        private readonly TextBox potChips = null;
        private int call = 500;
        /// <summary>
        /// You call the required amount of chips to continue playing the game
        /// </summary>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="statusLabel">The status label.</param>
        public void Call(ref int botChips, ref bool isBotsTurn, Label statusLabel)
        {
            isRaising = false;
            isBotsTurn = false;
            botChips -= call;
            statusLabel.Text = "Call " + call;
            potChips.Text = (int.Parse(potChips.Text) + call).ToString();
        }

        private double raise = 0;
        /// <summary>
        /// Raises the bet.
        /// </summary>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="statusLabel">The status label.</param>
        public void RaiseBet(ref int botChips, ref bool isBotsTurn, Label statusLabel)
        {
            botChips -= Convert.ToInt32(raise);
            statusLabel.Text = "Raise " + raise;
            potChips.Text = (int.Parse(potChips.Text) + Convert.ToInt32(raise)).ToString();
            call = Convert.ToInt32(raise);
            isRaising = true;
            isBotsTurn = false;
        }
    }
}