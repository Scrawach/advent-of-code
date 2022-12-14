using System;
using System.IO;
using no_space_left_on_device_src.Disk;
using no_space_left_on_device_src.Solves;
using no_space_left_on_device_src.Storages;

namespace no_space_left_on_device_src
{
    public static class Program
    {
        public static readonly string Directory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];

        public static void Main(string[] args)
        {
            var path = Path.Combine(Directory, "input.txt");
            var device = new Device();
            var text = new Text(path);
            var commands = new CommandTextStorage(device, text);
            foreach (var command in commands.All()) command.Execute(device);
            
            var firstTask = new SumOfTotalSize(device, 100000);
            Console.WriteLine($"First Task Result: {firstTask.Solve()}."); // First TaskResult: 1348005.

            var secondTask = new SmallestDirectory(device, 70000000, 30000000);
            Console.WriteLine($"Second Task Result: {secondTask.Solve()}"); // Second Task Result: 12785886.
        }
    }
}
