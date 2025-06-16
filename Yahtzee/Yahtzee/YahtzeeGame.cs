using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{

    public enum YahtzeeCategory
    {
        Ones,
        Twos,
        Threes,
        Fours,
        Fives,
        Sixes,
        ThreeOfAKind,
        FourOfAKind,
        FullHouse,
        SmallStraight,
        LargeStraight,
        Yahtzee,
        Chance
    }


    public class YahtzeeGame
    {
        private int[] diceValues;
        private IRandomProvider randomProvider;

        public YahtzeeGame(IRandomProvider randomProvider)
        {
            diceValues = new int[5];
            this.randomProvider = randomProvider;
        }

        public YahtzeeGame()
        {
        }

        public void RollAllDice()
        {
            for (int i = 0; i < 5; i++)
            {
                diceValues[i] = randomProvider.Next(1, 7);
            }
        }

        public int CalculateYahtzeeValue(YahtzeeCategory category)
        {
            switch (category)
            {
                case YahtzeeCategory.Ones:
                    return diceValues.Count(d => d == 1);
                case YahtzeeCategory.Twos:
                    return diceValues.Count(d => d == 2) * 2;
                case YahtzeeCategory.Threes:
                    return diceValues.Count(d => d == 3) * 3;
                case YahtzeeCategory.Fours:
                    return diceValues.Count(d => d == 4) * 4;
                case YahtzeeCategory.Fives:
                    return diceValues.Count(d => d == 5) * 5;
                case YahtzeeCategory.Sixes:
                    return diceValues.Count(d => d == 6) * 6;
                case YahtzeeCategory.ThreeOfAKind:
                    return diceValues.GroupBy(d => d).Any(group => group.Count() >= 3)
                        ? diceValues.Sum()
                        : 0;
                case YahtzeeCategory.FourOfAKind:
                    return diceValues.GroupBy(d => d).Any(group => group.Count() >= 4)
                        ? diceValues.Sum()
                        : 0;
                case YahtzeeCategory.FullHouse:
                    return (diceValues.GroupBy(d => d).Any(group => group.Count() == 2) &&
                            diceValues.GroupBy(d => d).Any(group => group.Count() == 3))
                        ? 25
                        : 0;
                case YahtzeeCategory.SmallStraight:
                    return IsSmallStraight() ? 30 : 0;
                case YahtzeeCategory.LargeStraight:
                    return IsLargeStraight() ? 40 : 0;
                case YahtzeeCategory.Yahtzee:
                    return diceValues.All(d => d == diceValues[0]) ? 50 : 0;
                case YahtzeeCategory.Chance:
                    return diceValues.Sum();
                default:
                    return 0;
            }
        }

        public string GetDiceValues()
        {
            return string.Join(", ", diceValues);
        }

        private bool IsSmallStraight()
        {
            return diceValues.Distinct().OrderBy(d => d).SequenceEqual(new[] { 1, 2, 3, 4, 5 });
        }

        private bool IsLargeStraight()
        {
            return diceValues.Distinct().OrderBy(d => d).SequenceEqual(new[] { 2, 3, 4, 5, 6 });
        }
    }
}
