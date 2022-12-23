using System;
using regolith_reservoir_src.Data;
using regolith_reservoir_src.Factory;

namespace regolith_reservoir_src
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var pouringPoint = new Vector2(500, 0);
            var factory = new SolvesFactory("input.txt");

            var firstTask = factory.FirstSolve(pouringPoint);
            Console.WriteLine($"First Task Result: {firstTask.CountOfRestSands()}."); // First Task Result: 817.

            var secondTask = factory.SecondSolve(pouringPoint);
            Console.WriteLine($"Second Task Result: {secondTask.CountOfRestSands()}."); // Second Task Result: 23416.
        }
    }
}