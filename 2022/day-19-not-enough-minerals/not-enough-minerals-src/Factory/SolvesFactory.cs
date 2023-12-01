using System;
using System.IO;
using not_enough_minerals_src.Logic;
using not_enough_minerals_src.Storages;

namespace not_enough_minerals_src.Factory
{
    public class SolvesFactory
    {
        private static readonly string WorkingDirectory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];

        private readonly string _fileName;

        public SolvesFactory(string fileName) =>
            _fileName = fileName;
        
        public QualityLevels QualityLevels(int minutes)
        {
            var path = Path.Combine(WorkingDirectory, "input.txt");
            var text = new Text(path);
            var storage = new BlueprintTextStorage(text);
            var brain = new Brain(24);
            return new QualityLevels(brain, storage);
        }
    }
}