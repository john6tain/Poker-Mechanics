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
        private const double PairFromHandBehaviourPower = 1;



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
                        character.CardsCombination = new Combination(power, CombinationType.ThreeOfAKind, ThreeOfAKindBehaviourPower, sameRankCardsCollection, theOtherCardsFromTheHandNotIncludedInTheCombination);
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
                character.CardsCombination = new Combination(power, CombinationType.HighCard, HighCardBehaviourPower, combinationCards, theOtherCardsFromTheHandNotIncludedInTheCombination);
            }

            return true;
        }

        //This method checks if the two cards which the character has make a pair or if one of the character's cards makes a pair with one card from the table.
        private static bool CheckForPairFromHand(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character)
        {
            bool hasPairFromHand = false;

            hasPairFromHand = CheckIfTheCharactersCardsMakeAPair(charactersCardsCollection, tableCardsCollection, character, hasPairFromHand);

            foreach (var element in tableCardsCollection)
            {
                hasPairFromHand = CheckIfTheFirstCharactersCardMakesAPairWithOneFromTheTable(charactersCardsCollection, tableCardsCollection, character, element, hasPairFromHand);

                hasPairFromHand = CheckIfTheOtherCharactersCardMakesAPairWithOneFromTheTable(charactersCardsCollection, tableCardsCollection, character, element, hasPairFromHand);
            }

            return hasPairFromHand;
        }

        private static bool CheckIfTheOtherCharactersCardMakesAPairWithOneFromTheTable(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character, ICard element, bool hasPairFromHand)
        {
            if (charactersCardsCollection[1].Rank == element.Rank)
            {
                if (charactersCardsCollection[1].Rank == element.Rank)
                {
                    double power = (int) charactersCardsCollection[1].Rank*4 + PairFromHandBehaviourPower*100;

                    IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                        tableCardsCollection.Where(x => x != element).ToList();
                    theOtherCardsFromTheHandNotIncludedInTheCombination.Add(charactersCardsCollection[0]);

                    IList<ICard> combinationCards = new List<ICard>();
                    combinationCards.Add(element);
                    combinationCards.Add(charactersCardsCollection[1]);

                    if (character.CardsCombination == null || character.CardsCombination.Type < CombinationType.OnePair ||
                        character.CardsCombination.Power < power)
                    {
                        character.CardsCombination = new Combination(power, CombinationType.OnePair, PairFromHandBehaviourPower,
                            combinationCards, theOtherCardsFromTheHandNotIncludedInTheCombination);
                    }
                }

                hasPairFromHand = true;
            }
            return hasPairFromHand;
        }

        private static bool CheckIfTheFirstCharactersCardMakesAPairWithOneFromTheTable(IList<ICard> charactersCardsCollection,
            IList<ICard> tableCardsCollection, ICharacter character, ICard element, bool hasPairFromHand)
        {
            if (charactersCardsCollection[0].Rank == element.Rank)
            {
                double power = (int) charactersCardsCollection[0].Rank*4 + PairFromHandBehaviourPower*100;

                IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                    tableCardsCollection.Where(x => x != element).ToList();
                theOtherCardsFromTheHandNotIncludedInTheCombination.Add(charactersCardsCollection[1]);

                IList<ICard> combinationCards = new List<ICard>();
                combinationCards.Add(element);
                combinationCards.Add(charactersCardsCollection[0]);

                if (character.CardsCombination == null || character.CardsCombination.Type < CombinationType.OnePair ||
                    character.CardsCombination.Power < power)
                {
                    character.CardsCombination = new Combination(power, CombinationType.OnePair, PairFromHandBehaviourPower,
                        combinationCards, theOtherCardsFromTheHandNotIncludedInTheCombination);
                }

                hasPairFromHand = true;
            }
            return hasPairFromHand;
        }

        private static bool CheckIfTheCharactersCardsMakeAPair(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection,
            ICharacter character, bool hasPairFromHand)
        {
            if (charactersCardsCollection[0].Rank == charactersCardsCollection[1].Rank)
            {
                double power = (int) charactersCardsCollection[0].Rank*4 + PairFromHandBehaviourPower*100;

                IList<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination = tableCardsCollection;

                if (character.CardsCombination == null || character.CardsCombination.Type < CombinationType.OnePair ||
                    character.CardsCombination.Power < power)
                {
                    character.CardsCombination = new Combination(power, CombinationType.OnePair, PairFromHandBehaviourPower,
                        charactersCardsCollection, theOtherCardsFromTheHandNotIncludedInTheCombination);
                }

                hasPairFromHand = true;
            }

            return hasPairFromHand;
        }
    }
}