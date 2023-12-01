using System;
using rope_bridge_src.Factory;

namespace rope_bridge_src
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var factory = new SolvesFactory("input.txt");

            var series = factory.SeriesOfMotions();
            Console.WriteLine($"First Task Result: {series.Simulate()}."); // First Task Result: 6384.
            Console.WriteLine($"First Task Result: {series.Simulate(9)}."); // First Task Result: 2734.
        }
    }
}