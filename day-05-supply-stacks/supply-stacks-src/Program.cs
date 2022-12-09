using System;
using supply_stacks_src.Factory;

namespace supply_stacks_src
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var factory = new RearrangementFactory("input.txt");

            var withDefaultMover = factory.CreateWithDefaultMover();
            Console.WriteLine($"First Task Result: {withDefaultMover.WorkResult()}."); // First Task Result: RFFFWBPNS.

            var withMover9001 = factory.CreateWithMover9001();
            Console.WriteLine($"Second Task Result: {withMover9001.WorkResult()}."); // Second Task Result: CQQBBJFCS.
        }
    }
}