using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Enumerations;
using Poker.Interfacees;
using Poker.Table;
using System.Drawing;

namespace PokerTest.Dealer
{
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
    }
}
