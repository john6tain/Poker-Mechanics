namespace Poker.Interfaces
{
    using Interfacees;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public interface ITable
    {
        IList<ICard> TableCardsCollection { get; set; }

        int Pot { get; set; }

        /// <summary>
        /// Takes and sum the call.
        /// </summary>
        /// <param name="callSum">The call sum.</param>
        /// <param name="tablePotSum">The table pot sum.</param>
        void TakeCall(int callSum, TextBox tablePotSum);
    }
}