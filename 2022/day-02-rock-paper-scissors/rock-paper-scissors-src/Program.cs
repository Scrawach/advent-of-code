using System;
using rock_paper_scissors_src.Factory;

namespace rock_paper_scissors_src
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var factory = new StrategyFactory("input.txt");

            var choiceBased = factory.ChoiceBased();
            Console.WriteLine($"First Task Result: {choiceBased.TotalScore()}."); // First Task Result: 12679.

            var resultBased = factory.ResultBased();
            Console.WriteLine($"Second Task Result: {resultBased.TotalScore()}."); // Second Task Result: 14470.
        }
    }
}