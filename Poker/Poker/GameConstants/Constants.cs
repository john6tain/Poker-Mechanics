using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.GameConstants
{
    public class Constants
    {
        public const double HighCardBehaviourPower = -1;
        public const double ThreeOfAKindBehaviourPower = 3;
        public const double PairFromHandBehaviourPower = 1;
        public const double FullHouseBehaviourPower = 6;
        public const double LittleStraightFlushBehaviourPower = 8;
        public const double BigStraightFlushBehaviourPower = 9;
        public const double FourOfAKindBehavourPower = 7;
        public const double BigFlushBehaviourPower = 5.5;
        public const double LittleFlushBehaviourPower = 5;
    }
}
