using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Interfacees;
using Poker.Interfaces;

namespace Poker.Table
{
    public static class Dealer
    {
        private const int UniqueThreeOfAKindCardCombinationCode = 3;
        private const int UniqueHighCardCombinationCode = -1;


        static Dealer()
        {
            RankList = new List<ICombination>();
        }

        private static IList<ICombination> RankList { get; set; }


        //This method checks if the character has card combination "Three of a kind"
        private static bool CheckForThreeOfAKind(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection, string characterName, bool finalCheck)
        {
            IList<ICard> joinedCardCollection =
                charactersCardsCollection.Union(tableCardsCollection.Where(x => x.isVisible)).ToList();

            foreach (var element in joinedCardCollection)
            {
                IList<ICard> sameRankCardsCollection = joinedCardCollection.Where(x => x.Rank == element.Rank).ToList();

                if (sameRankCardsCollection.Count == 3)
                {
                    //When all cards are down and the Dealer has to name the winner, add the combination to the RankList.
                    if (finalCheck)
                    {
                        int cardCombinationCode = UniqueThreeOfAKindCardCombinationCode;
                        double power = (int)sameRankCardsCollection[0].Rank * 3 + cardCombinationCode * 100;

                        UpdateRankList(characterName, joinedCardCollection, sameRankCardsCollection, cardCombinationCode, power);
                    }

                    return true;
                }
            }

            return false;
        }


        //This method checks for a "High card" combination
        private static bool CheckForHighCard(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection, string characterName, bool finalCheck)
        {
            double power = Math.Max((double)charactersCardsCollection[0].Rank, (double)charactersCardsCollection[1].Rank);
            int cardCombinationCode = UniqueHighCardCombinationCode;

            IList<ICard> joinedCardCollection =
    charactersCardsCollection.Union(tableCardsCollection.Where(x => x.isVisible)).OrderByDescending(x => x.Rank).ToList();

            IList<ICard> combinationCards = new List<ICard>();
            combinationCards.Add(joinedCardCollection[0]);


            UpdateRankList(characterName, joinedCardCollection, combinationCards, cardCombinationCode, power);

            return true;
        }

        //Add information about the combination to the RankList.
        private static void UpdateRankList(string characterName, IList<ICard> joinedCardCollection, IList<ICard> combinationCards, int cardCombinationCode, double power)
        {
            IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination = new List<ICard>();

            foreach (var card in joinedCardCollection)
            {
                if (!combinationCards.Contains(card))
                {
                    theOtherCardsFromTheHandNotIncludedInTheCombination.Add(card);
                }
            }

            theOtherCardsFromTheHandNotIncludedInTheCombination =
                theOtherCardsFromTheHandNotIncludedInTheCombination.OrderByDescending(x => x.Rank).ToList();

            Dealer.RankList.Add(new Combination(power, cardCombinationCode, characterName,
                theOtherCardsFromTheHandNotIncludedInTheCombination));
            Dealer.RankList =
                Dealer.RankList.OrderByDescending(x => x.CardCombinationCode).ThenByDescending(y => y.Power).ToList();
        }
    }
}