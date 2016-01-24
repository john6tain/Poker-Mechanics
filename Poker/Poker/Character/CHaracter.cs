// ***********************************************************************
// Assembly         : Poker
// Class Author     : Alex
//
// Last Modified By : Alex
// Last Modified On : 25 Jan 2016
// ***********************************************************************
// <copyright file="Character.cs" team="Currant">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Poker.Character
{
    using Interfaces;
    using Poker.Interfacees;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public abstract class Character : ICharacter
    {
        public int Chips { get; set; }
        public string Name { get; set; }
        public bool HasFolded { get; set; }
        public ICombination CardsCombination { get; set; }
        public IList<ICard> CharacterCardsCollection { get; set; }

        //private async Task AllIn()
        //{
        //    #region All in
        //    if (Chips <= 0 && !intsadded)
        //    {
        //        if (playerStatus.Text.Contains("raise"))
        //        {
        //            ints.Add(Chips);
        //            intsadded = true;
        //        }
        //        if (playerStatus.Text.Contains("Call"))
        //        {
        //            ints.Add(Chips);
        //            intsadded = true;
        //        }
        //    }
        //    intsadded = false;
        //    if (firstBotChips <= 0 && !botOneFirstTurn)
        //    {
        //        if (!intsadded)
        //        {
        //            ints.Add(firstBotChips);
        //            intsadded = true;
        //        }
        //        intsadded = false;
        //    }
        //    if (secondBotChips <= 0 && !botTwoTurn)
        //    {
        //        if (!intsadded)
        //        {
        //            ints.Add(secondBotChips);
        //            intsadded = true;
        //        }
        //        intsadded = false;
        //    }
        //    if (thirdBotChips <= 0 && !botThreeFirstTurn)
        //    {
        //        if (!intsadded)
        //        {
        //            ints.Add(thirdBotChips);
        //            intsadded = true;
        //        }
        //        intsadded = false;
        //    }
        //    if (fourthBotChips <= 0 && !botFourFirstTurn)
        //    {
        //        if (!intsadded)
        //        {
        //            ints.Add(fourthBotChips);
        //            intsadded = true;
        //        }
        //        intsadded = false;
        //    }
        //    if (fifthBotChips <= 0 && !botFiveFirstTurn)
        //    {
        //        if (!intsadded)
        //        {
        //            ints.Add(fifthBotChips);
        //            intsadded = true;
        //        }
        //    }
        //    if (ints.ToArray().Length == maxLeft)
        //    {
        //        await Finish(2);
        //    }
        //    else
        //    {
        //        ints.Clear();
        //    }

        //    #endregion

        //    var winer = bools.Count(x => x == false);

        //    #region LastManStanding

        //    if (winer == 1)
        //    {
        //        var index = bools.IndexOf(false);
        //        if (index == 0)
        //        {
        //            Chips += int.Parse(potChips.Text);
        //            tableChips.Text = Chips.ToString();
        //            playerPanel.Visible = true;
        //            MessageBox.Show("Player Wins");
        //        }
        //        if (index == 1)
        //        {
        //            firstBotChips += int.Parse(potChips.Text);
        //            tableChips.Text = firstBotChips.ToString();
        //            firstBotPanel.Visible = true;
        //            MessageBox.Show("Bot 1 Wins");
        //        }
        //        if (index == 2)
        //        {
        //            secondBotChips += int.Parse(potChips.Text);
        //            tableChips.Text = secondBotChips.ToString();
        //            secondBotPanel.Visible = true;
        //            MessageBox.Show("Bot 2 Wins");
        //        }
        //        if (index == 3)
        //        {
        //            thirdBotChips += int.Parse(potChips.Text);
        //            tableChips.Text = thirdBotChips.ToString();
        //            thirdBotPanel.Visible = true;
        //            MessageBox.Show("Bot 3 Wins");
        //        }
        //        if (index == 4)
        //        {
        //            fourthBotChips += int.Parse(potChips.Text);
        //            tableChips.Text = fourthBotChips.ToString();
        //            fourthBotPanel.Visible = true;
        //            MessageBox.Show("Bot 4 Wins");
        //        }
        //        if (index == 5)
        //        {
        //            fifthBotChips += int.Parse(potChips.Text);
        //            tableChips.Text = fifthBotChips.ToString();
        //            fifthBotPanel.Visible = true;
        //            MessageBox.Show("Bot 5 Wins");
        //        }

        //        for (var j = 0; j <= 16; j++)
        //        {
        //            Holder[j].Visible = false;
        //        }
        //        await Finish(1);
        //    }
        //    intsadded = false;

        //    #endregion

        //    #region FiveOrLessLeft

        //    if (winer < 6 && winer > 1 && rounds >= End)
        //    {
        //        await Finish(2);
        //    }

        //    #endregion
        //}

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