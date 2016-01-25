using System.Threading.Tasks;

namespace Poker.Interfaces
{
    using Poker.Interfacees;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public interface ICharacter
    {
        int Chips { get; set; }

        string Name { get; set; }

        bool HasFolded { get; set; }

        ICombination CardsCombination { get; set; }

        IList<ICard> CharacterCardsCollection { get; set; }

        Task AllIn();

        void Fold(ref bool isOnTurn, ref bool isFinalTurn, Label sStatus);

        void ChangeStatusToChecking(ref bool isBotsTurn, Label statusLabel);

        void Call(ref int botChips, ref bool isBotsTurn, Label statusLabel);

        void RaiseBet(ref int botChips, ref bool isBotsTurn, Label statusLabel);
    }
}