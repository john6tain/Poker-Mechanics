namespace PokerTest.Dealer
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker.Character;
    using Poker.Enumerations;
    using Poker.Interfacees;
    using Poker.Interfaces;
    using Poker.Table;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class DealerTests
    {
        private IList<ICard> characterCardsCollection;
        private IList<ICard> tableCardsCollection;
        private ICharacter character;

        [TestInitialize]
        public void InitializeList()
        {
            this.characterCardsCollection = new List<ICard>();
            this.tableCardsCollection = new List<ICard>();
            this.character = new Player();
        }

        [TestMethod]
        public void Test_CheckForRoyalStraightFlushOfClubs_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.King));

            this.tableCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Queen));
            this.tableCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Jack));
            this.tableCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ten));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraightFlushOfClubs",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers combination of Royal Straight Flush");
        }

        [TestMethod]
        public void Test_CheckForStraightFlushOfClubs_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Two));
            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Three));

            this.tableCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Four));
            this.tableCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Five));
            this.tableCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Six));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraightFlushOfClubs",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers combination of Straight Flush");
        }

        [TestMethod]
        public void Test_CheckForStraightFlushOfClubs_ShouldFail()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.King));

            this.tableCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Queen));
            this.tableCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Eight));
            this.tableCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ten));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraightFlushOfClubs",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(false, result, "Combination is not Straight Flush");
        }

        [TestMethod]
        public void Test_CheckForRoyalStraightFlushOfDiamonds_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.King));

            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Queen));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Jack));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ten));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraightFlushOfDiamonds",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers combination of Royal Straight Flush");
        }

        [TestMethod]
        public void Test_CheckForStraightFlushOfDiamonds_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Two));
            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Three));

            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Four));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Five));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Six));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraightFlushOfDiamonds",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers combination of Straight Flush");
        }

        [TestMethod]
        public void Test_CheckForStraightFlushOfDiamonds_ShouldFail()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.King));

            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Queen));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Eight));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ten));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraightFlushOfDiamonds",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(false, result, "Combination is not Straight Flush");
        }

        [TestMethod]
        public void Test_CheckForRoyalStraightFlushOfHearts_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.King));

            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Queen));
            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Jack));
            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ten));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraightFlushOfHearts",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers combination of Royal Straight Flush");
        }

        [TestMethod]
        public void Test_CheckForStraightFlushOfHearts_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Two));
            this.characterCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Three));

            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Four));
            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Five));
            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Six));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraightFlushOfHearts",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers combination of Straight Flush");
        }

        [TestMethod]
        public void Test_CheckForStraightFlushOfHearts_ShouldFail()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.King));

            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Queen));
            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Eight));
            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ten));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraightFlushOfHearts",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(false, result, "Combination is not Straight Flush");
        }

        [TestMethod]
        public void Test_CheckForRoyalStraightFlushOfSpades_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Spades, CardRank.King));

            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Queen));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Jack));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ten));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraightFlushOfSpades",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers combination of Royal Straight Flush");
        }

        [TestMethod]
        public void Test_CheckForStraightFlushOfSpades_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Two));
            this.characterCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Three));

            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Four));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Five));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Six));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraightFlushOfSpades",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers combination of Straight Flush");
        }

        [TestMethod]
        public void Test_CheckForStraightFlushOfSpades_ShouldFail()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Spades, CardRank.King));

            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Queen));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Eight));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ten));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraightFlushOfSpades",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(false, result, "Combination is not Straight Flush");
        }

        [TestMethod]
        public void Test_CheckForStraight_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.King));

            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Queen));
            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Jack));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ten));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraight",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers combination of Straight");
        }

        [TestMethod]
        public void Test_CheckForStraight_ShouldFail()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.King));

            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Queen));
            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Jack));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Two));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForStraight",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(false, result, "Player doesn't registers combination of Straight");
        }

        [TestMethod]
        public void Test_CheckForFlush_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Jack));

            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Nine));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Six));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Four));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForFlush",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers combination of Flush");
        }

        [TestMethod]
        public void Test_CheckForFlush_ShouldFail()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Jack));

            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Nine));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Six));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Four));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForFlush",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(false, result, "Player doesn't registers combination of Flush");
        }

        [TestMethod]
        public void Test_CheckForFourOfAKind_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ace));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Four));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForFourOfAKind",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers combination Four of a kind");
        }

        [TestMethod]
        public void Test_CheckForFourOfAKind_ShouldFail()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Nine));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Four));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForFourOfAKind",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(false, result, "Player doesn't register combination Four of a kind");
        }

        [TestMethod]
        public void Test_CheckForFullHouse_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.King));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.King));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForFullHouse",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers Full House combination");
        }

        [TestMethod]
        public void Test_CheckForFullHouse_ShouldFail()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.King));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Jack));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForFullHouse",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(false, result, "Player doesn't register Full House combination");
        }

        [TestMethod]
        public void Test_CheckForThreeOfAKind_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.King));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Jack));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForThreeOfAKind",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers Three of a Kind combination");
        }

        [TestMethod]
        public void Test_CheckForThreeOfAKind_ShouldFail()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Nine));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.King));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Jack));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForThreeOfAKind",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(false, result, "Player doesn't registers Three of a Kind combination");
        }

        [TestMethod]
        public void Test_CheckForTwoPairs_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Nine));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.King));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.King));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForTwoPairs",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(true, result, "Player registers Two Pairs combination");
        }

        [TestMethod]
        public void Test_CheckForTwoPairs_ShouldFail()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Nine));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Queen));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.King));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForTwoPairs",
                characterCardsCollection, tableCardsCollection, character));

            Assert.AreEqual(false, result, "Player doesn't register Two Pairs combination");
        }

        [TestMethod]
        public void Test_CheckForOnePair_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Nine));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Queen));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.King));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForOnePair",
                characterCardsCollection, tableCardsCollection, character, false));

            Assert.AreEqual(true, result, "Player registers Pair combination");
        }

        [TestMethod]
        public void Test_CheckForOnePair_ShouldFail()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            this.characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Two));

            this.tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Nine));
            this.tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Queen));
            this.tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.King));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;

            bool result = Convert.ToBoolean(obj.Invoke("CheckForOnePair",
                characterCardsCollection, tableCardsCollection, character, false));

            Assert.AreEqual(false, result, "Player doesn't register Pair combination");
        }

        [TestMethod]
        public void Test_CheckDeterminWinner_IfTwoPlayersHaveOnePair_ShouldPass()
        {
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            IList<ICharacter> gameCharacters = new List<ICharacter>();
            int pot = 1000;

            IList<ICard> firstPlayerCombinationCardsCollection = new List<ICard>();
            IList<ICard> firstPlayerKikcersCollection = new List<ICard>();

            firstPlayerCombinationCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            firstPlayerCombinationCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ace));
            firstPlayerKikcersCollection.Add(new Card(CardSuit.Clubs, CardRank.Eight));
            firstPlayerKikcersCollection.Add(new Card(CardSuit.Diamonds, CardRank.Five));
            firstPlayerKikcersCollection.Add(new Card(CardSuit.Hearts, CardRank.Four));

            IList<ICard> secondPlayerCombinationCardsCollection = new List<ICard>();
            IList<ICard> secondPlayerKikcersCollection = new List<ICard>();

            secondPlayerCombinationCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.King));
            secondPlayerCombinationCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.King));
            secondPlayerKikcersCollection.Add(new Card(CardSuit.Clubs, CardRank.Eight));
            secondPlayerKikcersCollection.Add(new Card(CardSuit.Diamonds, CardRank.Five));
            secondPlayerKikcersCollection.Add(new Card(CardSuit.Hearts, CardRank.Four));

            ICharacter firstPlayer = new Bot();
            firstPlayer.CardsCombination = new Combination(1, CombinationType.OnePair, 0,
                firstPlayerCombinationCardsCollection, firstPlayerKikcersCollection);

            ICharacter secondPlayer = new Bot();
            secondPlayer.CardsCombination = new Combination(0, CombinationType.OnePair, 0,
                secondPlayerCombinationCardsCollection, secondPlayerKikcersCollection);

            gameCharacters.Add(secondPlayer);
            gameCharacters.Add(firstPlayer);

            ICharacter winner = gameCharacters[0];

            ICharacter result = (ICharacter)(obj.Invoke("DetermineTheWinner",
                gameCharacters, pot));

            Assert.AreEqual(result, winner);
        }



    }
}
