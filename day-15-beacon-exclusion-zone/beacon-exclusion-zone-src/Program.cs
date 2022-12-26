using System;
using beacon_exclusion_zone_src.Data;
using beacon_exclusion_zone_src.Factory;

namespace beacon_exclusion_zone_src
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var factory = new SolvesFactory("input.txt");

            var positionsWithoutBeacon = factory.PositionsWithoutBeacon(2000000);
            Console.WriteLine($"Fist Task Result: {positionsWithoutBeacon.TotalCount()}."); // First Task Result: 5176944.

            var positionsWithHiddenBeacon = factory.PositionsWithHiddenBeacon(new Vector2(0, 0), new Vector2(4000000, 4000000));
            Console.WriteLine($"Second Task Result: {positionsWithHiddenBeacon.TuningFrequency()}."); // Second Task Result: 13350458933732.
        }
    }
}