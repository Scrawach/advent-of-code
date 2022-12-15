using System;
using no_space_left_on_device_src.Solves;

namespace no_space_left_on_device_src
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var factory = new SolveFactory("input.txt");

            var firstTask = factory.SumOfTotalSize(100000);
            Console.WriteLine($"First Task Result: {firstTask.Solve()}."); // First TaskResult: 1348005.

            var secondTask = factory.SmallestDirectory(70000000, 30000000);
            Console.WriteLine($"Second Task Result: {secondTask.Solve()}"); // Second Task Result: 12785886.
        }
    }
}
