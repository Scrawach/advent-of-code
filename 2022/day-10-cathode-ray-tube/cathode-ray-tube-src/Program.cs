using System;
using cathode_ray_tube_src.Factory;

namespace cathode_ray_tube_src
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var factory = new SolvesFactory("input.txt");

            var counter = factory.CreateCounter();
            var firstTask = factory.CreateProcessor(counter);
            firstTask.Execute();
            Console.WriteLine($"First Task Result: {counter.Total}."); // First Task Result: 14420.

            var tube = factory.CreateTube();
            var secondTask = factory.CreateProcessor(tube);
            secondTask.Execute();
            Console.WriteLine($"Second Task Result:"); 
            foreach (var symbol in tube.Screen()) 
                Console.Write(symbol);
            /*
            Second Task Result:
            ###...##..#....###..###..####..##..#..#.
            #..#.#..#.#....#..#.#..#....#.#..#.#..#.
            #..#.#....#....#..#.###....#..#..#.#..#.
            ###..#.##.#....###..#..#..#...####.#..#.
            #.#..#..#.#....#.#..#..#.#....#..#.#..#.
            #..#..###.####.#..#.###..####.#..#..##..
            */
        }
    }
}