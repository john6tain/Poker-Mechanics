namespace PokerTest.WinningScenarioTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker.Character;
    using Poker.Enumerations;
    using Poker.GameConstants;
    using Poker.Interfacees;
    using Poker.Interfaces;
    using Poker.Table;
    using System.Collections.Generic;
    using System.Drawing;

    [TestClass]
    public class WinningTests
    {
        private IList<ICard> firstPlayerCards;
        private IList<ICard> firstPlayerTableCards;
        private IList<ICard> secondPlayerCards;
        private IList<ICard> secondPlayerTableCards;
        private IList<ICard> thirdPlayerCards;
        private IList<ICard> thirdPlayerTableCards;
        private IList<ICard> fourthPlayerCards;
        private IList<ICard> fourthPlayerTableCards;
        private IList<ICard> fifthPlayerCards;
        private IList<ICard> fifthPlayerTableCards;

        private ICharacter firstPlayer;
        private ICharacter secondPlayer;
        private ICharacter thirdPlayer;
        private ICharacter fourthPlayer;
        private ICharacter fifthPlayer;

        private Point firstCardLocation = new Point(Constants.FirstBotCoordinateX, Constants.FirstBotCoordinateY);
        private Point secondCardLocation = new Point(Constants.SecondBotCoordinateX, Constants.SecondBotCoordinateY);
        private Point thirdCardLocation = new Point(Constants.ThirdBotCoordinateX, Constants.ThirdBotCoordinateY);
        private Point fourthCardLocation = new Point(Constants.FourthBotCoordinateX, Constants.FourthBotCoordinateY);
        private Point fifthCardLocation = new Point(Constants.FifthBotCoordinateX, Constants.FifthBotCoordinateY);

        private int cardWidth = Constants.CardWidth;

        [TestInitialize]
        public void InitializeList()
        {
            this.firstPlayer = new Bot(firstCardLocation, cardWidth);
            this.firstPlayer.Name = "Bot1";
            this.firstPlayerCards = new List<ICard>();
            this.firstPlayerTableCards = new List<ICard>();

            this.secondPlayer = new Bot(secondCardLocation, cardWidth);
            this.secondPlayer.Name = "Bot2";
            this.secondPlayerCards = new List<ICard>();
            this.secondPlayerTableCards = new List<ICard>();

            this.thirdPlayer = new Bot(thirdCardLocation, cardWidth);
            this.thirdPlayer.Name = "Bot3";
            this.thirdPlayerCards = new List<ICard>();
            this.thirdPlayerTableCards = new List<ICard>();

            this.fourthPlayer = new Bot(fourthCardLocation, cardWidth);
            this.fourthPlayer.Name = "Bot4";
            this.fourthPlayerCards = new List<ICard>();
            this.fourthPlayerTableCards = new List<ICard>();

            this.fifthPlayer = new Bot(fifthCardLocation, cardWidth);
            this.fifthPlayer.Name = "Bot5";
            this.fifthPlayerCards = new List<ICard>();
            this.fifthPlayerTableCards = new List<ICard>();
        }

        [TestMethod]
        public void Test_WinnerIfOnePlayerHasRoyalStraightFlush_ShouldPass()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.King));

            firstPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Queen));
            firstPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Jack));
            firstPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Ten));
            firstPlayerTableCards[0].IsVisible = true;
            firstPlayerTableCards[1].IsVisible = true;
            firstPlayerTableCards[2].IsVisible = true;

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            secondPlayerTableCards.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            secondPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            secondPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Ten));
            secondPlayerTableCards[0].IsVisible = true;
            secondPlayerTableCards[1].IsVisible = true;
            secondPlayerTableCards[2].IsVisible = true;

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            thirdPlayerTableCards.Add(new Card(CardSuit.Hearts, CardRank.King));
            thirdPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Queen));
            thirdPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Queen));
            thirdPlayerTableCards[0].IsVisible = true;
            thirdPlayerTableCards[1].IsVisible = true;
            thirdPlayerTableCards[2].IsVisible = true;

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerTableCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerTableCards.Add(new Card(CardSuit.Hearts, CardRank.King));
            fourthPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Queen));
            fourthPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Ten));
            fourthPlayerTableCards[0].IsVisible = true;
            fourthPlayerTableCards[1].IsVisible = true;
            fourthPlayerTableCards[2].IsVisible = true;

            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Seven));

            fifthPlayerTableCards.Add(new Card(CardSuit.Hearts, CardRank.Eight));
            fifthPlayerTableCards.Add(new Card(CardSuit.Hearts, CardRank.Nine));
            fifthPlayerTableCards.Add(new Card(CardSuit.Hearts, CardRank.Ten));
            fifthPlayerTableCards[0].IsVisible = true;
            fifthPlayerTableCards[1].IsVisible = true;
            fifthPlayerTableCards[2].IsVisible = true;

            dealer.SetGameRules(firstPlayerCards, firstPlayerTableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, secondPlayerTableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, thirdPlayerTableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, fourthPlayerTableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, fifthPlayerTableCards, fifthPlayer);

            playersOnTable.Add(fifthPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[0].Name;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            ICharacter winner = (Bot)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreEqual(winner.Name, result);
        }
    }
}