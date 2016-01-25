using System.Linq;
using System.Net.Mime;
using Poker.Character;
using Poker.Interfaces;

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
        public void Check_ThreeOfAKindCollection_ShouldPass()
        {
            bool hasThreeOfAKind = true;
            characterCardsCollection.Add(new Card(CardSuit.Clubs, CardRank.Ace));
            characterCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Eight));

            tableCardsCollection.Add(new Card(CardSuit.Diamonds, CardRank.Ace));
            tableCardsCollection.Add(new Card(CardSuit.Hearts, CardRank.Jack));
            tableCardsCollection.Add(new Card(CardSuit.Spades, CardRank.Ace));

            tableCardsCollection[0].IsVisible = true;
            tableCardsCollection[1].IsVisible = true;
            tableCardsCollection[2].IsVisible = true;
            
            Assert.AreEqual(Dealer.CheckForThreeOfAKind(characterCardsCollection, tableCardsCollection, character),
                hasThreeOfAKind, "Player should form three of a kind");
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
