using System;
using monkey_in_the_middle_src.Factory;

namespace monkey_in_the_middle_src
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var factory = new MonkeyBusinessFactory("input.txt");

            var firstTask = factory.FirstTask();
            Console.WriteLine($"First Task Result: {firstTask.Simulate(20)}."); // First Task Result: 55458.

            var second = factory.SecondTask();
            Console.WriteLine($"Second Task Result: {second.Simulate(10000)}."); // Second Task Result: 14508081294.
        }
        
    }
}