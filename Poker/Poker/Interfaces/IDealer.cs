using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.Interfacees;

namespace Poker.Interfaces
{
    public interface IDealer
    {
        void SetGameRules(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection, ICharacter character);

        void SetupGame(IDatabase database, ICharacter player, ICharacter bot1, ICharacter bot2, ICharacter bot3, ICharacter bot4, ICharacter bot5, ITable table, Control.ControlCollection Controls);
        void RevealTheNextCard(ITable table);
    }
}
