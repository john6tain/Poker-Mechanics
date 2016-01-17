// ***********************************************************************
// Assembly         : Poker
// Class Author     : Alex
//
// Last Modified By : Alex
// Last Modified On : 17 Jan 2016
// ***********************************************************************
// <copyright file="Character.cs" team="Currant">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using Poker.Interfaces;
using System;
using System.Windows.Forms;

namespace Poker.Character
{
    public abstract class Character : ICharacter
    {
        #region Variables   
        //TODO: potChips may not be null     
        private bool isRaising;
        private int call = 500;
        private readonly TextBox potChips = null;
        private double raise = 0;
        #endregion

        /// <summary>
        /// Fold can be used for both player and bot it means "give up"
        /// </summary>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="sStatus">The s status.</param>
        public void Fold(ref bool isOnTurn, ref bool isFinalTurn, Label sStatus)
        {
            isRaising = false;
            sStatus.Text = "Fold";
            isOnTurn = false;
            isFinalTurn = true;
        }

        /// <summary>
        /// Changes the status label of the bot when it is checking the community cards
        /// </summary>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="statusLabel">The status label.</param>
        public void ChangeStatusToChecking(ref bool isBotsTurn, Label statusLabel)
        {
            statusLabel.Text = "Check";
            isBotsTurn = false;
            isRaising = false;
        }

        /// <summary>
        /// Calls the specified value in chips
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

        /// <summary>
        /// Raises the bet
        /// </summary>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="statusLabel">The status label.</param>
        public void RaiseBet(ref int botChips, ref bool isBotsTurn, Label statusLabel)
        {
            botChips -= Convert.ToInt32(raise);
            statusLabel.Text = "raise " + raise;
            potChips.Text = (int.Parse(potChips.Text) + Convert.ToInt32(raise)).ToString();
            call = Convert.ToInt32(raise);
            isRaising = true;
            isBotsTurn = false;
        }
    }
}