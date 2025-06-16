using System;
using System.Collections.Generic;
using System.Linq;
using Yahtzee;



class Program
{
    static void Main()
    {
        YahtzeeGame game = new YahtzeeGame();

        game.RollAllDice();
        Console.WriteLine("Dice values: " + game.GetDiceValues());

        foreach (YahtzeeCategory category in Enum.GetValues(typeof(YahtzeeCategory)))
        {
            int categoryValue = game.CalculateYahtzeeValue(category);
            Console.WriteLine($"{category}: {categoryValue}");
        }
    }
}
