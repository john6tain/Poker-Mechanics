using System.Drawing;

namespace Poker.GameConstants
{
    public class Constants
    {
        //Card Powers
        public const double HighCardBehaviourPower = -1;
        public const double ThreeOfAKindBehaviourPower = 3;
        public const double PairFromHandBehaviourPower = 1;
        public const double FullHouseBehaviourPower = 6;
        public const double LittleStraightFlushBehaviourPower = 8;
        public const double BigStraightFlushBehaviourPower = 9;
        public const double FourOfAKindBehavourPower = 7;
        public const double BigFlushBehaviourPower = 5.5;
        public const double LittleFlushBehaviourPower = 5;
        public const double StraightBehaviourPower = 4;
        //Card Dimensions
        public const int CardHeight = 130;
        public const int CardWidth = 80;
        //Locations
        public const int PlayerCoordinateX = 580;
        public const int PlayerCoordinateY = 480;
        public const int FirstBotCoordinateX = 15;
        public const int FirstBotCoordinateY = 420;
        public const int SecondBotCoordinateX = 75;
        public const int SecondBotCoordinateY = 65;
        public const int ThirdBotCoordinateX = 590;
        public const int ThirdBotCoordinateY = 25;
        public const int FourthBotCoordinateX = 1115;
        public const int FourthBotCoordinateY = 65;
        public const int FifthBotCoordinateX = 1160;
        public const int FifthBotCoordinateY = 420;
        public const int TableCoordinateX = 410;
        public const int TableCoordinateY = 265;


        

    }
}
