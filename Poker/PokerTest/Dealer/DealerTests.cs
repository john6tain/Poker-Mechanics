
﻿using System.Collections;
﻿using System.Drawing;
﻿using System.Linq;
using Poker.Table;
using System.Linq;
﻿using Poker.GameConstants;
﻿using Poker.Table;


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
    using System.Drawing;

    [TestClass]
    public class DealerTests
    {
        private IList<ICard> characterCardsCollection;
        private IList<ICard> tableCardsCollection;
        private ICharacter character;

        private Point firstCardLocation = new Point(Constants.PlayerCoordinateX, Constants.PlayerCoordinateY);
        private int cardWidth = Constants.CardWidth;

        [TestInitialize]
        public void InitializeList()
        {
            this.characterCardsCollection = new List<ICard>();
            this.tableCardsCollection = new List<ICard>();
            this.character = new Player(firstCardLocation, cardWidth);
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
        public void Test_ChooseTheWinnerByTheCardsRank_IfTwoPlayersHaveOnePair_ShouldPass()
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
            firstPlayerKikcersCollection.Add(new Card(CardSuit.Hearts, CardRank.Jack));

            IList<ICard> secondPlayerCombinationCardsCollection = new List<ICard>();
            IList<ICard> secondPlayerKikcersCollection = new List<ICard>();

            secondPlayerCombinationCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            secondPlayerCombinationCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ace));
            secondPlayerKikcersCollection.Add(new Card(CardSuit.Clubs, CardRank.Eight));
            secondPlayerKikcersCollection.Add(new Card(CardSuit.Diamonds, CardRank.Five));
            secondPlayerKikcersCollection.Add(new Card(CardSuit.Hearts, CardRank.Four));

            ICharacter firstPlayer = new Bot(firstCardLocation, cardWidth);
            firstPlayer.CardsCombination = new Combination(1, CombinationType.OnePair, 0,
                firstPlayerCombinationCardsCollection, firstPlayerKikcersCollection);

            ICharacter secondPlayer = new Bot(firstCardLocation, cardWidth);
            secondPlayer.CardsCombination = new Combination(0, CombinationType.OnePair, 0,
                secondPlayerCombinationCardsCollection, secondPlayerKikcersCollection);

            gameCharacters.Add(firstPlayer);
            gameCharacters.Add(secondPlayer);

            ICharacter winner = gameCharacters[0];

            ICharacter result = (Bot)(obj.Invoke("ChooseTheWinnerByTheCardsRank",
                gameCharacters));

            Assert.AreEqual(result, winner);
        }

        [TestMethod]
        public void Test_ChooseTheWinnerByTheCardsRank_IfTwoPlayersHaveOnePair_ShoudFail()
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
            firstPlayerKikcersCollection.Add(new Card(CardSuit.Hearts, CardRank.Jack));

            IList<ICard> secondPlayerCombinationCardsCollection = new List<ICard>();
            IList<ICard> secondPlayerKikcersCollection = new List<ICard>();

            secondPlayerCombinationCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            secondPlayerCombinationCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ace));
            secondPlayerKikcersCollection.Add(new Card(CardSuit.Clubs, CardRank.Eight));
            secondPlayerKikcersCollection.Add(new Card(CardSuit.Diamonds, CardRank.Five));
            secondPlayerKikcersCollection.Add(new Card(CardSuit.Hearts, CardRank.Four));

            ICharacter firstPlayer = new Bot(firstCardLocation, cardWidth);
            firstPlayer.CardsCombination = new Combination(1, CombinationType.OnePair, 0,
                firstPlayerCombinationCardsCollection, firstPlayerKikcersCollection);

            ICharacter secondPlayer = new Bot(firstCardLocation, cardWidth);
            secondPlayer.CardsCombination = new Combination(0, CombinationType.OnePair, 0,
                secondPlayerCombinationCardsCollection, secondPlayerKikcersCollection);

            gameCharacters.Add(secondPlayer);
            gameCharacters.Add(firstPlayer);

            ICharacter winner = gameCharacters[0];


            ICharacter result = (Bot)(obj.Invoke("ChooseTheWinnerByTheCardsRank",
                gameCharacters));


            Assert.AreNotEqual(result, winner);
        }


        #region Winning Scenario

        public void Test_WinnerIfOnePlayerHasRoyalStraightFlush()
        {
            IDealer dealer = new Dealer();
            IList<ICharacter> playersOnTable = new List<ICharacter>();

            ICharacter firstPlayer = new Bot(new Point(0, 0), 10);
            IList<ICard> firstPlayerCards = new List<ICard>();
            IList<ICard> firstPlayerTableCards = new List<ICard>();

            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            firstPlayerCards.Add(new Card(CardSuit.Spades, CardRank.King));

            firstPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Queen));
            firstPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Jack));
            firstPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Ten));

            ICharacter secondPlayer = new Bot(new Point(0, 0), 10);
            IList<ICard> secondPlayerCards = new List<ICard>();
            IList<ICard> secondPlayerTableCards = new List<ICard>();

            secondPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            secondPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.Ace));

            secondPlayerTableCards.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            secondPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Ace));
            secondPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Ten));

            ICharacter thirdPlayer = new Bot(new Point(0, 0), 10);
            IList<ICard> thirdPlayerCards = new List<ICard>();
            IList<ICard> thirdPlayerTableCards = new List<ICard>();

            thirdPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            thirdPlayerCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            thirdPlayerTableCards.Add(new Card(CardSuit.Hearts, CardRank.King));
            thirdPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Queen));
            thirdPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Queen));

            ICharacter fourthPlayer = new Bot(new Point(0, 0), 10);
            IList<ICard> fourthPlayerCards = new List<ICard>();
            IList<ICard> fourthPlayerTableCards = new List<ICard>();

            fourthPlayerCards.Add(new Card(CardSuit.Clubs, CardRank.King));
            fourthPlayerTableCards.Add(new Card(CardSuit.Diamonds, CardRank.King));

            fourthPlayerTableCards.Add(new Card(CardSuit.Hearts, CardRank.King));
            fourthPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Queen));
            fourthPlayerTableCards.Add(new Card(CardSuit.Spades, CardRank.Ten));

            ICharacter fifthPlayer = new Bot(new Point(0, 0), 10);
            IList<ICard> fifthPlayerCards = new List<ICard>();
            IList<ICard> fifthPlayerTableCards = new List<ICard>();

            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Six));
            fifthPlayerCards.Add(new Card(CardSuit.Hearts, CardRank.Seven));
            fifthPlayerTableCards.Add(new Card(CardSuit.Hearts, CardRank.Eight));
            fifthPlayerTableCards.Add(new Card(CardSuit.Hearts, CardRank.Nine));
            fifthPlayerTableCards.Add(new Card(CardSuit.Hearts, CardRank.Ten));

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
            ICharacter winner = playersOnTable[0];
            PrivateObject obj = new PrivateObject(typeof(Dealer));

            ICharacter result = (Bot)(obj.Invoke("DetermineTheWinner",
                playersOnTable, pot));

            Assert.AreNotEqual(result, winner);
        }


        #endregion

    }
}
