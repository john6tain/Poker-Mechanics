using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Enumerations
{
    public enum CombinationType
    {
        StraightFlush = 7,
        FourOfAKind = 6,
        FullHouse = 5,
        Flush = 4,
        Straight = 3,
        ThreeOfAKind = 2,
        TwoPair = 1,
        OnePair = 0,
        HighCard = -1
    }
}
