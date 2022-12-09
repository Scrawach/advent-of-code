using System;
using System.IO;
using System.Linq;
using tuning_trouble_src.Storages;

namespace tuning_trouble_src
{
    public static class Program
    {
        private static readonly string WorkingDirectory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];
        
        private static void Main(string[] args)
        {
            var text = new Text(Path.Combine(WorkingDirectory, "input.txt"));
            var packet = new Packet(text.Lines().First());
            
            Console.WriteLine($"First Task Result: {packet.Marker(4)}."); // First Task Result: 1210.
            Console.WriteLine($"Second Task Result: {packet.Marker(14)}."); // Second Task Result: 3476.
        }
    }
}