using System;
using treetop_tree_house_src.Factory;

namespace treetop_tree_house_src
{
    public static class Program
    {

        public static void Main(string[] args)
        {
            var factory = new SolvesFactory("input.txt");

            var firstTask = factory.VisibleTrees();
            Console.WriteLine($"First Task Result: {firstTask.TotalCount()}."); // First Task Result: 1825.

            var secondTask = factory.ScenicTrees();
            Console.WriteLine($"Second Task Result: {secondTask.HighestScore()}."); // Second Task Result: 235200.
        }
    }
}