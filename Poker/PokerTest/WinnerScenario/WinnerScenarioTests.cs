using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Character;
using Poker.Enumerations;
using Poker.GameConstants;
using Poker.Interfacees;
using Poker.Interfaces;
using Poker.Table;

namespace PokerTest.WinningScenarioTests
{
    [TestClass]
    public class WinningTests
    {
        private IList<ICard> firstPlayerCards;
        private IList<ICard> secondPlayerCards;
        private IList<ICard> thirdPlayerCards;
        private IList<ICard> fourthPlayerCards;
        private IList<ICard> fifthPlayerCards;
        private IList<ICard> tableCards;


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
            this.secondPlayer = new Bot(secondCardLocation, cardWidth);
            this.secondPlayer.Name = "Bot2";
            this.secondPlayerCards = new List<ICard>();
            this.thirdPlayer = new Bot(thirdCardLocation, cardWidth);
            this.thirdPlayer.Name = "Bot3";
            this.thirdPlayerCards = new List<ICard>();
            this.fourthPlayer = new Bot(fourthCardLocation, cardWidth);
            this.fourthPlayer.Name = "Bot4";
            this.fourthPlayerCards = new List<ICard>();
            this.fifthPlayer = new Bot(fifthCardLocation, cardWidth);
            this.fifthPlayer.Name = "Bot5";
            this.fifthPlayerCards = new List<ICard>();
            this.tableCards = new List<ICard>();

        }

        [TestMethod]
        public void Test_DetermineWinnerByHightCard_TwoPlayersHasThreeOfAKind_ShouldPass()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Spades, CardRank.Queen));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Queen));
            tableCards.Add(new Card(CardSuit.Spades, CardRank.Ten));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Queen));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Three));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Five));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Seven));


            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[0].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreEqual(result, winner);
        }

        [TestMethod]
        public void Test_DetermineWinnerStrongestFull_TwoPlayersHasFullHouse_ShouldPass()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Queen));
            tableCards.Add(new Card(CardSuit.Diamonds, CardRank.Queen));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            firstPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Queen));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Seven));


            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[0].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreEqual(result, winner);
        }

        [TestMethod]
        public void Test_WinnerIfOnePlayerHasRoyalStraightFlush_ShouldPass()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Spades, CardRank.Queen));
            tableCards.Add(new Card(CardSuit.Spades, CardRank.Jack));
            tableCards.Add(new Card(CardSuit.Spades, CardRank.Ten));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.King));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Seven));

            
            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[0].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string) (obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreEqual(result, winner);
        }

        [TestMethod]
        public void Test_WinnerIfOnePlayerHasFullHouse_ShouldPass()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Spades, CardRank.Queen));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Queen));
            tableCards.Add(new Card(CardSuit.Spades, CardRank.Ten));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Queen));
            firstPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Ten));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Seven));


            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[0].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreEqual(result, winner);
        }

        [TestMethod]
        public void Test_WinnerIfOnePlayerHasRoyalStraightFlush_ShouldFail()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Spades, CardRank.Queen));
            tableCards.Add(new Card(CardSuit.Spades, CardRank.Jack));
            tableCards.Add(new Card(CardSuit.Spades, CardRank.Ten));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.King));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Seven));


            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[1].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreNotEqual(result, winner);
        }

        [TestMethod]
        public void Test_WinnerIfOnePlayerHasStraightFlush_ShouldPass()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Two));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Three));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Four));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Five));
            firstPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Four));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));


            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);
            
            int pot = 1000;
            string result = playersOnTable[0].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreEqual(result, winner);
        }

        [TestMethod]
        public void Test_WinnerIfOnePlayerHasFlush_ShouldPass()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Two));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Ten));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Five));
            firstPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Four));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));


            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[0].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreEqual(result, winner);
        }

        [TestMethod]
        public void Test_WinnerIfOnePlayerHasFourOfAKind_ShouldPass()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Ten));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));
            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Three));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));


            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[0].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreEqual(result, winner);
        }

        [TestMethod]
        public void Test_WinnerIfOnePlayerHasThreeOfAKind_ShouldPass()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Two));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Ten));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));
            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Three));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));


            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[0].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreEqual(result, winner);
        }

        [TestMethod]
        public void Test_WinnerIfOnePlayerHasTwoPairs_ShouldPass()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Two));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Ten));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));
            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Two));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Three));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));


            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[0].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreEqual(result, winner);
        }

        [TestMethod]
        public void Test_WinnerIfOnePlayerHasOnePair_ShouldPass()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Two));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Ten));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));
            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Five));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Three));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Three));


            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[0].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreEqual(result, winner);
        }

        [TestMethod]
        public void Test_WinnerIfOnePlayerHasStraightFlush_ShouldFail()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Two));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Three));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Four));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Five));
            firstPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Four));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));


            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[1].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreNotEqual(result, winner);
        }

        [TestMethod]
        public void Test_WinnerIfOnePlayerHasFlush_ShouldFail()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Two));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Ten));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Five));
            firstPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Four));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));


            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[1].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreNotEqual(result, winner);
        }

        [TestMethod]
        public void Test_WinnerIfOnePlayerHasFourOfAKind_ShouldFail()
        {
            IDealer dealer = new Poker.Table.Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            tableCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            tableCards.Add(new Card(CardSuit.Hearts, CardRank.Ten));

            tableCards[0].IsVisible = true;
            tableCards[1].IsVisible = true;
            tableCards[2].IsVisible = true;

            firstPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));
            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Three));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fifthPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));


            dealer.SetGameRules(firstPlayerCards, tableCards, firstPlayer);
            dealer.SetGameRules(secondPlayerCards, tableCards, secondPlayer);
            dealer.SetGameRules(thirdPlayerCards, tableCards, thirdPlayer);
            dealer.SetGameRules(fourthPlayerCards, tableCards, fourthPlayer);
            dealer.SetGameRules(fifthPlayerCards, tableCards, fifthPlayer);

            playersOnTable.Add(firstPlayer);
            playersOnTable.Add(secondPlayer);
            playersOnTable.Add(thirdPlayer);
            playersOnTable.Add(fourthPlayer);
            playersOnTable.Add(fifthPlayer);

            int pot = 1000;
            string result = playersOnTable[1].Name + " " + playersOnTable[0].CardsCombination.Type;
            PrivateObject obj = new PrivateObject(typeof(Poker.Table.Dealer));

            string winner = (string)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreNotEqual(result, winner);
        }
    }
}
