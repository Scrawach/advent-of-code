using System;
using distress_signal_src.Factory;

namespace distress_signal_src
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var factory = new SolvesFactory("input.txt");

            var firstTask = factory.CreateSignal();
            Console.WriteLine($"First Task Result: {firstTask.SumOfIndicesRightPairs()}."); // First Task Result: 4894.

            var secondTask = factory.CreateDecoder();
            Console.WriteLine($"Second Task Result: {secondTask.Key()}."); // Second Task Result: 24180.
        }
    }
}