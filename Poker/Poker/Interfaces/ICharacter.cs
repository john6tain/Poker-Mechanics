﻿using System.Collections;
using System.Windows.Forms;

namespace Poker.Interfaces
{
    public interface ICharacter
    {
        ICombination CardsCombination { get; set; }

        void Fold(ref bool isOnTurn, ref bool isFinalTurn, Label sStatus);

        void ChangeStatusToChecking(ref bool isBotsTurn, Label statusLabel);

        void Call(ref int botChips, ref bool isBotsTurn, Label statusLabel);

        void RaiseBet(ref int botChips, ref bool isBotsTurn, Label statusLabel);
    }
}