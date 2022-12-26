using System;
using pyroclastic_flow_src.Factory;

namespace pyroclastic_flow_src
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var factory = new SolvesFactory("input.txt", "shapes.txt");
            var tunnel = factory.CreateTunnel();
            
            Console.WriteLine($"First Task Result: {tunnel.AddRocks(2022).Height}."); // First Task Result: 3114.
        }
    }
}