using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Enumerations;
using Poker.Interfacees;
using Poker.Interfaces;

namespace Poker.Table
{
    public static class Dealer
    {
        private const double HighCardBehaviourPower = -1;
        private const double ThreeOfAKindBehaviourPower = 3;


        //This method checks if the character has card combination "Three of a kind"
        private static bool CheckForThreeOfAKind(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection, ICharacter character)
        {
            IList<ICard> joinedCardCollection =
                charactersCardsCollection.Union(tableCardsCollection.Where(x => x.isVisible)).ToList();

            foreach (var element in joinedCardCollection)
            {
                IList<ICard> sameRankCardsCollection = joinedCardCollection.Where(x => x.Rank == element.Rank).ToList();

                if (sameRankCardsCollection.Count == 3)
                {
                    double power = (int)sameRankCardsCollection[0].Rank * 3 + ThreeOfAKindBehaviourPower * 100;

                    IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination = joinedCardCollection.Where(x => !sameRankCardsCollection.Contains(x)).ToList();

                    if (character.CardsCombination == null || character.CardsCombination.Type < CombinationType.ThreeOfAKind)
                    {
                        character.CardsCombination = new Combination(power, CombinationType.ThreeOfAKind, ThreeOfAKindBehaviourPower, theOtherCardsFromTheHandNotIncludedInTheCombination);
                    }

                    return true;
                }
            }

            return false;
        }


        //This method checks for a "High card" combination
        private static bool CheckForHighCard(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection, ICharacter character)
        {
            double power = Math.Max((double)charactersCardsCollection[0].Rank, (double)charactersCardsCollection[1].Rank);

            IList<ICard> joinedCardCollection =
    charactersCardsCollection.Union(tableCardsCollection.Where(x => x.isVisible)).OrderByDescending(x => x.Rank).ToList();

            IList<ICard> combinationCards = new List<ICard>();
            combinationCards.Add(joinedCardCollection[0]);

            IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination = joinedCardCollection.Where(x => !combinationCards.Contains(x)).ToList();

            if (character.CardsCombination == null || character.CardsCombination.Type < CombinationType.HighCard)
            {
                character.CardsCombination = new Combination(power, CombinationType.HighCard, HighCardBehaviourPower, theOtherCardsFromTheHandNotIncludedInTheCombination);
            }

            return true;
        }
    }
}