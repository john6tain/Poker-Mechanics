namespace Poker.Character
{
    using Interfacees;
    using Interfaces;
    using Poker.GameConstants;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class DecisionMaker : IDecisionMaker
    {
        /// <summary>
        /// Tell us the specified straight combination.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botIndex">Index of the bot.</param>
        /// <param name="botPower">The bot power.</param>
        private void Straight(ICharacter character, ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded,
            int botIndex, double botPower)
        {
            Random straightRandomGenerator = new Random();
            int chanceToCall = straightRandomGenerator.Next(3, 6);
            int chanceToRaise = straightRandomGenerator.Next(3, 8);

            if (botPower >= 404 && botPower <= 480)
            {
                ChooseBotsMoveThirdWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, chanceToCall, chanceToRaise);
            }
        }

        /// <summary>
        /// Tell us the specified flush combination.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botIndex">Index of the bot.</param>
        /// <param name="botPower">The bot power.</param>
        private void Flush(ICharacter character, ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded,
            int botIndex, double botPower)
        {
            Random flushRandomGenerator = new Random();
            int chanceToCall = flushRandomGenerator.Next(2, 6);
            int chanceToRaise = flushRandomGenerator.Next(3, 7);
            ChooseBotsMoveThirdWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, chanceToCall, chanceToRaise);
        }

        /// <summary>
        /// Tell us the specified full house combination
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botIndex">Index of the bot.</param>
        /// <param name="botPower">The bot power.</param>
        private void FullHouse(ICharacter character, ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded,
            int botIndex, double botPower)
        {
            Random fullHouseRandomGenerator = new Random();
            int chanceToCall = fullHouseRandomGenerator.Next(1, 5);
            int chanceToRaise = fullHouseRandomGenerator.Next(2, 6);

            if (botPower <= 626 && botPower >= 602)
            {
                ChooseBotsMoveThirdWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, chanceToCall, chanceToRaise);
            }
        }

        /// <summary>
        /// Tell us if we have four of a kind cards
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botIndex">Index of the bot.</param>
        /// <param name="botPower">The bot power.</param>
        private void FourOfAKind(ICharacter character, ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded,
            int botIndex, double botPower)
        {
            Random fourOfAKindRandomGenerator = new Random();
            int chanceToCall = fourOfAKindRandomGenerator.Next(1, 4);
            int chanceToRaise = fourOfAKindRandomGenerator.Next(2, 5);

            if (botPower <= 752 && botPower >= 704)
            {
                ChooseBotsMoveThirdWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, chanceToCall, chanceToRaise);
            }
        }

        /// <summary>
        /// Tell us if we have straight flush combination
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botIndex">Index of the bot.</param>
        /// <param name="botPower">The bot power.</param>
        private void StraightFlush(ICharacter character, ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded,
            int botIndex, double botPower)
        {
            Random straightFlushRandomGenerator = new Random();
            int chanceToCall = straightFlushRandomGenerator.Next(1, 3);
            int chanceToRaise = straightFlushRandomGenerator.Next(1, 3);

            if (botPower <= 913 && botPower >= 804)
            {
                ChooseBotsMoveThirdWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, chanceToCall, chanceToRaise);
            }
        }

        /// <summary>
        /// Decision manager decide who has biggest winning combination
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="cardCollection">The card collection.</param>
        /// <param name="firstCard">The first card.</param>
        /// <param name="secondCard">The second card.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botIndex">Index of the bot.</param>
        /// <param name="botPower">The bot power.</param>
        /// <param name="behaviourPower">The bot current.</param>
        public void MakeDecision(ICharacter character,
                                 int firstCard, int secondCard, ref int botChips, bool isOnTurn,
                                 ref bool isFinalTurn, Label hasFolded, int botIndex, double botPower,
                                 double behaviourPower)
        {
            IList<ICard> cardCollection = character.CharacterCardsCollection;

            if (!isFinalTurn)
            {
                if (behaviourPower == (Constants.HighCardBehaviourPower))
                {
                    HighCard(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botPower);
                }
                if (behaviourPower == 0)
                {
                    PairTable(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botPower);
                }
                if (behaviourPower == Constants.PairFromHandBehaviourPower)
                {
                    PairHand(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botPower);
                }
                if (behaviourPower == 2)
                {
                    TwoPairs(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botPower);
                }
                if (behaviourPower == Constants.ThreeOfAKindBehaviourPower)
                {
                    ThreeOfAKind(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, botPower);
                }
                if (behaviourPower == Constants.StraightBehaviourPower)
                {
                    Straight(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, botPower);
                }
                if (behaviourPower == Constants.LittleFlushBehaviourPower || behaviourPower == Constants.BigFlushBehaviourPower)
                {
                    Flush(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, botPower);
                }
                if (behaviourPower == Constants.FullHouseBehaviourPower)
                {
                    FullHouse(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, botPower);
                }
                if (behaviourPower == Constants.FourOfAKindBehavourPower)
                {
                    FourOfAKind(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, botPower);
                }
                if (behaviourPower == Constants.LittleStraightFlushBehaviourPower || behaviourPower == Constants.BigStraightFlushBehaviourPower)
                {
                    StraightFlush(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, botPower);
                }
            }
            if (isFinalTurn)
            {
                cardCollection[firstCard].IsVisible = false;
                cardCollection[secondCard].IsVisible = false;
            }
        }

        /// <summary>
        /// Tell us the highest card
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botPower">The bot power.</param>
        private void HighCard(ICharacter character, ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded, double botPower)
        {
            ChooseBotsMoveFirstWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botPower, 20, 25);
        }

        /// <summary>
        /// Tell us if we have a pair of some combination
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botPower">The bot power.</param>
        private void PairTable(ICharacter character, ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded, double botPower)
        {
            ChooseBotsMoveFirstWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botPower, 16, 25);
        }

        /// <summary>
        /// Tell us if we have a pair hand
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botPower">The bot power.</param>
        private void PairHand(ICharacter character, ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded, double botPower)
        {
            Random pairHandRandom = new Random();
            int rCall = pairHandRandom.Next(10, 16);
            int rRaise = pairHandRandom.Next(10, 13);

            if (botPower <= 199 && botPower >= 140)
            {
                ChooseBotsMoveSecondWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, rCall, 6, rRaise);
            }
            if (botPower <= 139 && botPower >= 128)
            {
                ChooseBotsMoveSecondWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, rCall, 7, rRaise);
            }
            if (botPower < 128 && botPower >= 101)
            {
                ChooseBotsMoveSecondWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, rCall, 9, rRaise);
            }
        }

        /// <summary>
        /// Tell us if we have combination of two pairs.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botPower">The bot power.</param>
        private void TwoPairs(ICharacter character, ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded, double botPower)
        {
            Random twoPairsRandom = new Random();
            int rCall = twoPairsRandom.Next(6, 11);
            int rRaise = twoPairsRandom.Next(6, 11);

            if (botPower <= 290 && botPower >= 246)
            {
                ChooseBotsMoveSecondWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, rCall, 3, rRaise);
            }
            if (botPower <= 244 && botPower >= 234)
            {
                ChooseBotsMoveSecondWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, rCall, 4, rRaise);
            }
            if (botPower < 234 && botPower >= 201)
            {
                ChooseBotsMoveSecondWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, rCall, 4, rRaise);
            }
        }

        /// <summary>
        /// Tell us if we have combination of three pairs.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isOnTurn">if set to <c>true</c> [is on turn].</param>
        /// <param name="isFinalTurn">if set to <c>true</c> [is final turn].</param>
        /// <param name="hasFolded">The has folded.</param>
        /// <param name="botIndex">Index of the bot.</param>
        /// <param name="botPower">The bot power.</param>
        private void ThreeOfAKind(ICharacter character, ref int botChips, ref bool isOnTurn, ref bool isFinalTurn, Label hasFolded, int botIndex, double botPower)
        {
            Random threeOfAKindRandom = new Random();
            int tCall = threeOfAKindRandom.Next(3, 7);
            int tRaise = threeOfAKindRandom.Next(4, 8);

            if (botPower <= 390 && botPower >= 303)
            {
                ChooseBotsMoveThirdWay(character, ref botChips, ref isOnTurn, ref isFinalTurn, hasFolded, botIndex, tCall, tRaise);
            }
        }

        /// <summary>
        /// Calculate the maximum amount of money that the bot can play with on this particular turn
        /// </summary>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="behaviourFactor">The behaviour factor.</param>
        /// <returns>System.Double.</returns>
        private static double CalculateMaximumBidAbilityOfTheBot(int botChips, int behaviourFactor)
        {
            double maximumBidChips = Math.Round((botChips / behaviourFactor) / 100d, 0) * 100;
            return maximumBidChips;
        }

        private int call = 500;
        private double raise;
        /// <summary>
        /// Chooses the bot's move if it has a "High Card" or "Pair" from table combination
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="botFolds">if set to <c>true</c> [bot folds].</param>
        /// <param name="statusLabel">The status label.</param>
        /// <param name="botPower">The bot power.</param>
        /// <param name="carefulBehaviourFactor">The careful behaviour factor.</param>
        /// <param name="riskyBehaviourFactor">The risky behaviour factor.</param>
        private void ChooseBotsMoveFirstWay(ICharacter character, ref int botChips, ref bool isBotsTurn, ref bool botFolds, Label statusLabel, double botPower, int carefulBehaviourFactor, int riskyBehaviourFactor)
        {
            Random botHighCardPairRandom = new Random();
            int botHighCardRandom = botHighCardPairRandom.Next(1, 4);

            if (call <= 0)
            {
                character.ChangeStatusToChecking(ref isBotsTurn, statusLabel);
            }
            else if (call > 0)
            {
                if (botHighCardRandom == 1)
                {
                    if (call <= CalculateMaximumBidAbilityOfTheBot(botChips, carefulBehaviourFactor))
                    {
                        character.Call(ref botChips, ref isBotsTurn, statusLabel, potChips);
                    }
                    else
                    {
                        character.Fold(ref isBotsTurn, ref botFolds, statusLabel);
                    }
                }

                if (botHighCardRandom == 2)
                {
                    if (call <= CalculateMaximumBidAbilityOfTheBot(botChips, riskyBehaviourFactor))
                    {
                        character.Call(ref botChips, ref isBotsTurn, statusLabel, potChips);
                    }
                    else
                    {
                        character.Fold(ref isBotsTurn, ref botFolds, statusLabel);
                    }
                }
            }

            if (botHighCardRandom == 3)
            {

                if (raise == 0)
                {
                    raise = call * 2;
                    character.RaiseBet(ref botChips, ref isBotsTurn, statusLabel, potChips);
                }
                else
                {
                    if (raise <= CalculateMaximumBidAbilityOfTheBot(botChips, carefulBehaviourFactor))
                    {
                        raise = call * 2;
                        character.RaiseBet(ref botChips, ref isBotsTurn, statusLabel, potChips);
                    }
                    else
                    {
                        character.Fold(ref isBotsTurn, ref botFolds, statusLabel);
                    }
                }
            }
            if (botChips <= 0)
            {
                botFolds = true;
            }
        }

        private double rounds;
        /// <summary>
        ///Chooses the bot's move if it has a "Pair" in the hand or "Two pairs" combinations - not sure about the combinations???
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="botFolds">if set to <c>true</c> [bot folds].</param>
        /// <param name="labelStatus">The label status.</param>
        /// <param name="raiseBehaviourFactor">The raise behaviour factor.</param>
        /// <param name="behaviourFactorBasedOnBotPower">The behaviour factor based on bot power.</param>
        /// <param name="callBehaviourFactor">The call behaviour factor.</param>
        private void ChooseBotsMoveSecondWay(ICharacter character, ref int botChips, ref bool isBotsTurn, ref bool botFolds, Label labelStatus, int raiseBehaviourFactor, int behaviourFactorBasedOnBotPower, int callBehaviourFactor)
        {
            Random pairsRandom = new Random();
            int randomNumber = pairsRandom.Next(1, 3);

            if (rounds < 2)
            {
                if (call <= 0)
                {
                    character.ChangeStatusToChecking(ref isBotsTurn, labelStatus);
                }
                if (call > 0)
                {
                    if (call >= CalculateMaximumBidAbilityOfTheBot(botChips, behaviourFactorBasedOnBotPower))
                    {
                        character.Fold(ref isBotsTurn, ref botFolds, labelStatus);
                    }
                    if (raise > CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor))
                    {
                        character.Fold(ref isBotsTurn, ref botFolds, labelStatus);
                    }
                    if (!botFolds)
                    {
                        if (call >= CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor) && call <= CalculateMaximumBidAbilityOfTheBot(botChips, behaviourFactorBasedOnBotPower))
                        {
                            character.Call(ref botChips, ref isBotsTurn, labelStatus, potChips);
                        }
                        if (raise <= CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor) && raise >= (CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor)) / 2)
                        {
                            character.Call(ref botChips, ref isBotsTurn, labelStatus, potChips);
                        }
                        if (raise <= (CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor)) / 2)
                        {
                            if (raise > 0)
                            {
                                raise = CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor);
                                character.RaiseBet(ref botChips, ref isBotsTurn, labelStatus, potChips);
                            }
                            else
                            {
                                raise = call * 2;
                                character.RaiseBet(ref botChips, ref isBotsTurn, labelStatus, potChips);
                            }
                        }

                    }
                }
            }
            if (rounds >= 2)
            {
                if (call > 0)
                {
                    if (call >= CalculateMaximumBidAbilityOfTheBot(botChips, behaviourFactorBasedOnBotPower - randomNumber))
                    {
                        character.Fold(ref isBotsTurn, ref botFolds, labelStatus);
                    }
                    if (raise > CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor - randomNumber))
                    {
                        character.Fold(ref isBotsTurn, ref botFolds, labelStatus);
                    }
                    if (!botFolds)
                    {
                        if (call >= CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor - randomNumber) && call <= CalculateMaximumBidAbilityOfTheBot(botChips, behaviourFactorBasedOnBotPower - randomNumber))
                        {
                            character.Call(ref botChips, ref isBotsTurn, labelStatus, potChips);
                        }
                        if (raise <= CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor - randomNumber) && raise >= (CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor - randomNumber)) / 2)
                        {
                            character.Call(ref botChips, ref isBotsTurn, labelStatus, potChips);
                        }
                        if (raise <= (CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor - randomNumber)) / 2)
                        {
                            if (raise > 0)
                            {
                                raise = CalculateMaximumBidAbilityOfTheBot(botChips, raiseBehaviourFactor - randomNumber);
                                character.RaiseBet(ref botChips, ref isBotsTurn, labelStatus, potChips);
                            }
                            else
                            {
                                raise = call * 2;
                                character.RaiseBet(ref botChips, ref isBotsTurn, labelStatus, potChips);
                            }
                        }
                    }
                }
                if (call <= 0)
                {
                    raise = CalculateMaximumBidAbilityOfTheBot(botChips, callBehaviourFactor - randomNumber);
                    character.RaiseBet(ref botChips, ref isBotsTurn, labelStatus, potChips);
                }
            }
            if (botChips <= 0)
            {
                botFolds = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="botChips"></param>
        /// <param name="isBotsTurn"></param>
        /// <param name="labelStatus"></param>
        private void FixCall(ICharacter character, ref int botChips, ref bool isBotsTurn, Label labelStatus)
        {
            if (rounds != 4)
            {
                if (labelStatus.Text.Contains("Raise"))
                {
                    character.RaiseBet(ref botChips, ref isBotsTurn, labelStatus, potChips);
                }
                if (labelStatus.Text.Contains("Call"))
                {
                    character.Call(ref botChips, ref isBotsTurn, labelStatus, potChips);
                }
                if (labelStatus.Text.Contains("Check"))
                {
                    character.ChangeStatusToChecking(ref isBotsTurn, labelStatus);
                }
            }
        }

        private readonly TextBox potChips;
        private bool isRaising;
        /// <summary>
        ///Chooses the bot's move if it has a "ThreeOfAKind", "Straight", "FullHouse", "Flush", "FourOfAKind" or "StraightFlush" combination - not sure about the combinations??? 
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="botChips">The bot chips.</param>
        /// <param name="isBotsTurn">if set to <c>true</c> [is bots turn].</param>
        /// <param name="botFolds">if set to <c>true</c> [bot folds].</param>
        /// <param name="botStatus">The bot status.</param>
        /// <param name="botIndex">Index of the bot.</param>
        /// <param name="behaviourFactor">The behaviour factor.</param>
        /// <param name="r">The r.</param>
        private void ChooseBotsMoveThirdWay(ICharacter character, ref int botChips, ref bool isBotsTurn, ref bool botFolds, Label botStatus, int botIndex, int behaviourFactor, int r)
        {
            Random randomCombination = new Random();
            int combination = randomCombination.Next(1, 3);

            if (call <= 0)
            {
                character.ChangeStatusToChecking(ref isBotsTurn, botStatus);
            }
            else
            {
                if (call >= CalculateMaximumBidAbilityOfTheBot(botChips, behaviourFactor))
                {
                    if (botChips > call)
                    {
                        character.Call(ref botChips, ref isBotsTurn, botStatus, potChips);
                    }
                    else if (botChips <= call)
                    {
                        isRaising = false;
                        isBotsTurn = false;
                        botChips = 0;
                        botStatus.Text = "Call " + botChips;
                        potChips.Text = (int.Parse(potChips.Text) + botChips).ToString();
                    }
                }
                else
                {
                    if (raise > 0)
                    {
                        if (botChips >= raise * 2)
                        {
                            raise *= 2;
                            character.RaiseBet(ref botChips, ref isBotsTurn, botStatus, potChips);
                        }
                        else
                        {
                            character.Call(ref botChips, ref isBotsTurn, botStatus, potChips);
                        }
                    }
                    else
                    {
                        raise = call * 2;
                        character.RaiseBet(ref botChips, ref isBotsTurn, botStatus, potChips);
                    }
                }
            }
            if (botChips <= 0)
            {
                botFolds = true;
            }
        }
    }
}