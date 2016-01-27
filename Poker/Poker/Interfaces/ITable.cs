using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfacees;

namespace Poker.Interfaces
{
    public interface ITable
    {
        IList<ICard> TableCardsCollection { get; set; }
        int Pot { get; set; }
    }
}
