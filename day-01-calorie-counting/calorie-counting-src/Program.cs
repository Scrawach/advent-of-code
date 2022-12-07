using System;
using System.IO;

namespace day_01_calorie_counting
{
    public static class Program
    {
        private static readonly string WorkingDirectory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];
        
        private static void Main(string[] args)
        {
            var path = Path.Combine(WorkingDirectory, "input.txt");
            
            var mostCalories = new MostCalories(new InventoryDatabase(new Text(path)));
            Console.WriteLine($"First Task Result: {mostCalories.Solve()}."); // First Task Result: 68923

            var mostCaloriesSum = new MostCalories(3, new InventoryDatabase(new Text(path)));
            Console.WriteLine($"Second Task Result: {mostCaloriesSum.Solve()}"); // First Task Result: 200044
        }
    }
}