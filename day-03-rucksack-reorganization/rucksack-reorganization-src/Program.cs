using System;
using rucksack_reorganization_src.Factory;

namespace rucksack_reorganization_src
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ReorganizationFactory("input.txt");

            var firstTask = factory.Single();
            Console.WriteLine($"First Task Result: {firstTask.TotalPriorityScore()}."); // First Task Result: 8123.

            var secondTask = factory.Group();
            Console.WriteLine($"Second Task Result: {secondTask.TotalPriorityScore()}."); // Second Task Result: 2620.
        }
    }
}