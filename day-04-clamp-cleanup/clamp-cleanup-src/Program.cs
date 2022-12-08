using System;
using clamp_cleanup_src.Factory;

namespace clamp_cleanup_src
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var factory = new CampFactory("input.txt");
            var camp = factory.Create();
            
            Console.WriteLine($"First Task Result: {camp.TotalContainsPairs()}."); // First Task Result: 571.
            Console.WriteLine($"Second Task Result: {camp.TotalOverlapPairs()}."); // Second Task Result: 917.
        }
    }
}