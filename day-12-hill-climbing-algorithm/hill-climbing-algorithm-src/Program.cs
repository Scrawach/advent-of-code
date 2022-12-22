using System;
using hill_climbing_algorithm_src.Factory;

namespace hill_climbing_algorithm_src
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var factory = new PathFactory("input.txt");
            
            var firstTask = factory.SearchPath();
            Console.WriteLine($"First Task Result: {firstTask.TotalSteps()}."); // First Task Result: 534.

            var secondTask = factory.ScenicPath();
            Console.WriteLine($"Second Task Result: {secondTask.TotalSteps()}."); // Second Task Result: 525.
        }
    }
}