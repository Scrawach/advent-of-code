using System;
using boiling_boulders_src.Factory;

namespace boiling_boulders_src
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var factory = new SolvesFactory("input.txt");
            var droplet = factory.CreateDroplet();
            
            Console.WriteLine($"First Task Result: {droplet.SurfaceArea()}."); // First Task Result: 4300.
        }
    }
}