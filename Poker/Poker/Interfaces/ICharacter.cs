namespace Poker.Interfaces
{
    using Interfacees;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public interface ICharacter
    {
        int Chips { get; set; }

        Label StatusLabel { get; set; }
        Label ChipsLabel { get; set; }

        string Name { get; set; }

        bool HasFolded { get; set; }

        bool IsOnTurn { get; set; }

        ICombination CardsCombination { get; set; }

        IList<ICard> CharacterCardsCollection { get; set; }

        Point FirstCardLocation { get; set; }

        Point SecondCardLocation { get; set; }

        /// <summary>
        /// You bet all the money you have.
        /// </summary>
        /// <returns></returns>
        Task AllIn(TextBox potChips);

        /// <summary>
        /// You can exit the game.
        /// </summary>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="sStatus">The s status.</param>
        void Fold(Label sStatus);

        /// <summary>
        /// Changes the status label to checking.
        /// </summary>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="statusLabel">The status label.</param>
        void ChangeStatusToChecking();

        /// <summary>
        /// Calls the specified chips.
        /// </summary>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="statusLabel">The status label.</param>
        void Call(int callSum);

        /// <summary>
        /// Raises the bet.
        /// </summary>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="statusLabel">The status label.</param>
        void RaiseBet(ref int botChips, ref bool isBotsTurn, Label statusLabel, TextBox potChips);

        /// <summary>
        /// Updates the specified chips text box.
        /// </summary>
        /// <param name="chipsTextBox">The chips text box.</param>
        void Update(TextBox chipsTextBox);

        /// <summary>
        /// Decides the specified card combination
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="cardCollection">The card collection.</param>
        /// <param name="firstCard">The first card.</param>
        /// <param name="secondCard">The second card.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botIndex">Index of the bot.</param>
        /// <param name="botPower">The bot power.</param>
        /// <param name="behaviourPower">The behaviour power.</param>
        /// <param name="callSum">The call sum.</param>
        void Decide(ICharacter character, IList<ICard> cardCollection,
                    int firstCard, int secondCard, int botChips,
                    bool isFinalTurn, Label hasFolded, int botIndex,
                    double botPower, double behaviourPower, int callSum);

        /// <summary>
        /// Gets the second card location.
        /// </summary>
        /// <param name="firstCardLocation">The first card location.</param>
        /// <param name="cardWidth">Width of the card.</param>
        /// <returns></returns>
        Point GetSecondCardLocation(Point firstCardLocation, int cardWidth);
    }
}