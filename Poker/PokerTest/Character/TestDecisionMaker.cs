namespace PokerTest.Character
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker.Enumerations;
    using Poker.Interfacees;
    using Poker.Table;
    using System.Collections.Generic;

    [TestClass]
    public class TestDecisionMaker
    {
        private IList<ICard> cardCollection;

        [TestInitialize]
        public void SettingUpInitialization()
        {
            this.cardCollection = new List<ICard>();
        }

        [TestMethod]
        public void Test_MakeDecision_ShouldPass()
        {
            this.cardCollection.Add(new Card(CardSuit.Spades, CardRank.Five));
            this.cardCollection.Add(new Card(CardSuit.Clubs, CardRank.King));

            Assert.AreEqual(2, cardCollection.Count, "Right decision made");
        }
    }
}