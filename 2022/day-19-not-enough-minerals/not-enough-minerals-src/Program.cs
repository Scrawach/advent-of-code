using System;
using System.Linq;
using not_enough_minerals_src.Factory;

namespace not_enough_minerals_src
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var factory = new SolvesFactory("input.txt");

            var qualityLevels = factory.QualityLevels(24);
            Console.WriteLine($"First Task Result: {qualityLevels.All().Sum()}."); // First Task Result: 2341.
        }
    }
}