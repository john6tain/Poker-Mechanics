using System.Linq;

namespace PokerTest.Dealer
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker.Enumerations;
    using Poker.Interfacees;
    using Poker.Table;

    [TestClass]
    public class DealerTests
    {
        private IList<ICard> cardsCollection;

        [TestInitialize]
        public void InitializeList()
        {
            this.cardsCollection = new List<ICard>();
        }

        [TestMethod]
        public void Test_CheckPairFromHand_ShoudPass()
        {
            this.cardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Two));
            this.cardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Two));

            CardRank firstPlayersCard = this.cardsCollection[0].Rank;
            CardRank secondPlayersCard = this.cardsCollection[1].Rank;

            Assert.AreEqual(firstPlayersCard, secondPlayersCard, "Cards in player's hand should be with equal rank");
        }

        [TestMethod]
        public void Test_CheckPairFromHand_ShouldFail()
        {
            this.cardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.cardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Eight));

            CardRank firstPlayerCard = this.cardsCollection[0].Rank;
            CardRank secondPlayerCard = this.cardsCollection[1].Rank;

            Assert.AreNotEqual(firstPlayerCard, secondPlayerCard, "Cards with different ranc cannot form pair");
        }

        [TestMethod]
        public void Test_CheckingPlayerMakingPairWihtTable_ShouldPass()
        {
            this.cardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.cardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Eight));
            this.cardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Five));
            this.cardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ace));

            bool hasPair = false;
            for (int i = 0; i < this.cardsCollection.Count - 1; i++)
            {
                for (int j = i + 1; j < this.cardsCollection.Count; j++)
                {
                    if (cardsCollection[i].Rank == cardsCollection[j].Rank)
                    {
                        hasPair = true;
                    }
                }
            }

            Assert.IsTrue(hasPair, "If there are two cards with same rank player forms pair");
        }

        [TestMethod]
        public void Test_CheckingIfPlayerDoesntMakePair_ShouldPass()
        {
            this.cardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.cardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Eight));
            this.cardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Five));
            this.cardsCollection.Add(new Card(CardSuit.Spades, CardRank.Nine));

            bool hasPair = false;
            for (int i = 0; i < this.cardsCollection.Count - 1; i++)
            {
                for (int j = i + 1; j < this.cardsCollection.Count; j++)
                {
                    if (cardsCollection[i].Rank == cardsCollection[j].Rank)
                    {
                        hasPair = true;
                    }
                }
            }

            Assert.IsFalse(hasPair, "If there aren't two cards with same rank player doesn't forms pair");
        }

        [TestMethod]
        public void Test_CheckIfPlayerFormsTwoPairs_ShouldPass()
        {
            this.cardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.cardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Eight));
            this.cardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            this.cardsCollection.Add(new Card(CardSuit.Spades, CardRank.Nine));
            this.cardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Eight));

            int count = 0;
            for (int i = 0; i < this.cardsCollection.Count - 1; i++)
            {
                for (int j = i + 1; j < this.cardsCollection.Count; j++)
                {
                    if (cardsCollection[i].Rank == cardsCollection[j].Rank)
                    {
                        count++;
                    }
                }
            }

            Assert.AreEqual(count, 2, "If there are two different cases of cards with same rank, player forms two pairs");
        }

        [TestMethod]
        public void Test_CheckIfPlayerFormsTwoPairs_ShouldFail()
        {
            this.cardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.cardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Eight));
            this.cardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            this.cardsCollection.Add(new Card(CardSuit.Spades, CardRank.Nine));
            this.cardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Jack));

            int count = 0;
            for (int i = 0; i < this.cardsCollection.Count - 1; i++)
            {
                for (int j = i + 1; j < this.cardsCollection.Count; j++)
                {
                    if (cardsCollection[i].Rank == cardsCollection[j].Rank)
                    {
                        count++;
                    }
                }
            }

            Assert.AreNotEqual(count, 2, "If there are not two different cases of cards with same rank, player doesn't form two pairs");
        }

        [TestMethod]
        public void Test_CheckIfPlayerFormsThreeOfAKind_ShouldPass()
        {
            this.cardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            this.cardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Eight));
            this.cardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            this.cardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ace));
            this.cardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Jack));

            int cards = 0;
            foreach (var card in cardsCollection)
            {
                IList<ICard> threeOfAKindCollection = cardsCollection.Where(x => x.Rank == card.Rank).ToList();
                cards = threeOfAKindCollection.Count;
            }
            
            Assert.AreEqual(cards, 3, "If player has three cards with same rank, he forms three of a kind combination");
        }



        //CheckForThreeOfAKind(charactersCardsCollection, tableCardsCollection, character);

        //CheckForStraight(charactersCardsCollection, tableCardsCollection, character);

        //CheckForFlush(charactersCardsCollection, tableCardsCollection, character);

        //CheckForFullHouse(charactersCardsCollection, tableCardsCollection, character);

        //CheckForFourOfAKind(charactersCardsCollection, tableCardsCollection, character);

        // CheckForStraightFlushOfSpades(charactersCardsCollection, tableCardsCollection, character);
        //CheckForStraightFlushOfDiamonds(charactersCardsCollection, tableCardsCollection, character);
        // CheckForStraightFlushOfHearts(charactersCardsCollection, tableCardsCollection, character);
        // CheckForStraightFlushOfClubs(charactersCardsCollection, tableCardsCollection, character);

        //CheckForHighCard(charactersCardsCollection, tableCardsCollection, character);

    }
}
