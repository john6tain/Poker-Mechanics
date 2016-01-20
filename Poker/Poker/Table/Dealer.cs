using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
        private const double FullHouseBehaviourPower = 6; 
       

        private static readonly int[] AllCardsOnTable = new int[17];

        private static Label playerStatus;

        private static readonly PictureBox[] Holder = new PictureBox[52];

        

        public static void SetGameRules(
            int card1,
            int card2,
            string playerName,
            ref double currentCardsValue,
            ref double power,
            bool foldedTurn, 
            IList<ICard> charactersCardCollection,
            IList<ICard> tableCardsCollection,
            ICharacter character)
        {
            
            if (!foldedTurn || card1 == 0 && card2 == 1 && playerStatus.Text.Contains("Fold") == false)
            {
                #region Variables

                bool done = false;
                bool vf = false;

                int[] littleStraight = new int[5];
                int[] bigStraight = new int[7];

                bigStraight[0] = AllCardsOnTable[card1];
                bigStraight[1] = AllCardsOnTable[card2];
                littleStraight[0] = bigStraight[2] = AllCardsOnTable[12];
                littleStraight[1] = bigStraight[3] = AllCardsOnTable[13];
                littleStraight[2] = bigStraight[4] = AllCardsOnTable[14];
                littleStraight[3] = bigStraight[5] = AllCardsOnTable[15];
                littleStraight[4] = bigStraight[6] = AllCardsOnTable[16];

                int[] straightOfClubs = bigStraight.Where(o => o % 4 == 0).ToArray();
                int[] straightOfDiamonds = bigStraight.Where(o => o % 4 == 1).ToArray();
                int[] straightOfHearts = bigStraight.Where(o => o % 4 == 2).ToArray();
                int[] straightOfSpades = bigStraight.Where(o => o % 4 == 3).ToArray();

                int[] straightOfClubsValue = straightOfClubs.Select(o => o / 4).Distinct().ToArray();
                int[] straightOfDiamondsValue = straightOfDiamonds.Select(o => o / 4).Distinct().ToArray();
                int[] straightOfHeartsValue = straightOfHearts.Select(o => o / 4).Distinct().ToArray();
                int[] straightOfSpadesValue = straightOfSpades.Select(o => o / 4).Distinct().ToArray();

                Array.Sort(bigStraight);
                Array.Sort(straightOfClubsValue);
                Array.Sort(straightOfDiamondsValue);
                Array.Sort(straightOfHeartsValue);
                Array.Sort(straightOfSpadesValue);

                #endregion

                for (int i = 1; i < AllCardsOnTable.Length; i++)
                {
                    if (AllCardsOnTable[i] == int.Parse(Holder[card1].Tag.ToString()) &&
                        AllCardsOnTable[i + 1] == int.Parse(Holder[card2].Tag.ToString()))
                    {
                        //Pair from Hand curentCardsValue = 1
                        //CheckForPairFromHand(ref curentCardsValue, ref power);

                        //Pair or Two Pairs from Table curentCardsValue = 2 || 0
                        //CheckForPairTwoPair(ref curentCardsValue, ref power);

                        //Two Pairs curentCardsValue = 2
                        //CheckForTwoPair(ref curentCardsValue, ref power);

                        //Three of a kind curentCardsValue = 3
                        CheckForThreeOfAKind(charactersCardCollection, tableCardsCollection, character);

                        //Straight curentCardsValue = 4
                        //rStraight(ref curentCardsValue, ref power, bigStraight);

                        //Flush curentCardsValue = 5 || 5.5
                        //rFlush(ref curentCardsValue, ref power, ref vf, littleStraight);

                        //Full House curentCardsValue = 6
                        //rFullHouse(ref curentCardsValue, ref power, ref done, bigStraight);

                        //Four of a Kind curentCardsValue = 7
                        //rFourOfAKind(ref curentCardsValue, ref power, bigStraight);

                        //Straight Flush curentCardsValue = 8 || 9
                        //CheckForStraightFlush(ref curentCardsValue, ref power, straightOfClubsValue, straightOfDiamondsValue, straightOfHeartsValue, straightOfSpadesValue);

                        //High Card curentCardsValue = -1
                        CheckForHighCard(charactersCardCollection, tableCardsCollection, character);
                    }
                }
            }
        }

        //This method checks if the character has card combination "Full House"
        private static bool CheckForFullHouse(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection,
            ICharacter character)
        {
            bool hasFullHouse = false;

            List<ICard> joinedCardCollection = charactersCardsCollection.Union(tableCardsCollection.Where(x => x.isVisible)).ToList();

            bool characterHasThreeOfAKind = CheckForThreeOfAKind(charactersCardsCollection, tableCardsCollection,
                character);

            List<ICard> threeOfAKindCards = new List<ICard>();

            int threeOfAKindRank = -1;

            if (characterHasThreeOfAKind)
            {
                threeOfAKindRank = GetThreeOfAKindCardRank(charactersCardsCollection, tableCardsCollection);

                //removes the three-of-a-kind cards from the joinedCardCollection (hand+table cards)
                // and adds them to the threeOfAKindCards list
                foreach (ICard card in joinedCardCollection)
                {
                    if ((int) card.Rank == threeOfAKindRank)
                    {
                        threeOfAKindCards.Add(card);
                        joinedCardCollection.Remove(card);
                    }
                }

                //checks if there is a pair in the remaining collection
                //if yes -> the player has a full house combination
                int maxPairRank = -1;
                foreach (ICard card in joinedCardCollection)
                {
                    List<ICard> remainingEqualRankCards =
                        joinedCardCollection.Where(x => x.Rank == card.Rank).ToList();

                    if (remainingEqualRankCards.Count == 2)
                    {
                        hasFullHouse = true;

                        //This is a check for multiple pairs in the remaining cards
                        //If there is more than one pair, the highest one is taken
                        if (card.Rank == 0 || maxPairRank == 0)
                        {
                            maxPairRank = 0; // because -> rank 0 is ACE (strongest card)
                        }
                        else
                        {
                            maxPairRank = Math.Max(maxPairRank, (int)card.Rank); // if neither pair is ACE -> take the one with the higher rank
                        }

                        List<ICard> theOtherCardsFromTheHandNotIncludedInTheCombination =
                            joinedCardCollection.Where(x => x != remainingEqualRankCards[0]).ToList();

                        List<ICard> fullHouseCards = threeOfAKindCards;
                        fullHouseCards.AddRange(remainingEqualRankCards);

                        double power = 0;  //TODO: figure how to calculate power...

                        if (character.CardsCombination == null ||
                            character.CardsCombination.Type < CombinationType.FullHouse)
                        {
                            character.CardsCombination = new Combination(power, CombinationType.FullHouse, FullHouseBehaviourPower, fullHouseCards, theOtherCardsFromTheHandNotIncludedInTheCombination);
                        }

                    }
                }
            }

            return hasFullHouse;
        }

        //This method gets the rank (number) of the cards that make up a three-of-a-kind
        private static int GetThreeOfAKindCardRank(IList<ICard> charactersCardsCollection, IList<ICard> tableCardsCollection)
        {
            int cardRank = -1;

            IList<ICard> joinedCardCollection =
                charactersCardsCollection.Union(tableCardsCollection.Where(x => x.isVisible)).ToList();

            foreach (var element in joinedCardCollection)
            {
                IList<ICard> sameRankCardsCollection = joinedCardCollection.Where(x => x.Rank == element.Rank).ToList();

                if (sameRankCardsCollection.Count == 3)
                {
                    cardRank = (int)element.Rank;
                }
            }

            return cardRank;
        }


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