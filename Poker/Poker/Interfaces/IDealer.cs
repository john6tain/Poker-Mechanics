namespace Poker.Interfaces
{
    using Interfacees;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public interface IDealer
    {
        /// <summary>
        /// Sets the game rules.
        /// </summary>
        /// <param name="charactersCardsCollection">The characters cards collection.</param>
        /// <param name="tableCardsCollection">The table cards collection.</param>
        /// <param name="character">The character.</param>
        void SetGameRules(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection, ICharacter character);

        void DeclareWinner(IList<ICharacter> gameCharacters, int pot);

        /// <summary>
        /// Setups the game.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="player">The player.</param>
        /// <param name="bot1">The bot1.</param>
        /// <param name="bot2">The bot2.</param>
        /// <param name="bot3">The bot3.</param>
        /// <param name="bot4">The bot4.</param>
        /// <param name="bot5">The bot5.</param>
        /// <param name="table">The table.</param>
        /// <param name="Controls">The controls.</param>
        void SetupGame(IDatabase database, ICharacter player, ICharacter bot1,
                       ICharacter bot2, ICharacter bot3, ICharacter bot4, ICharacter bot5,
                       ITable table, Control.ControlCollection Controls);

        /// <summary>
        /// Reveals the next card.
        /// </summary>
        /// <param name="table">The table.</param>
        void RevealTheNextCard(ITable table);
    }
}