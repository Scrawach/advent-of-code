using System;
using System.IO;
using rope_bridge_src.Solves;
using rope_bridge_src.Storages;

namespace rope_bridge_src.Factory
{
    public class SolvesFactory
    {
        private static readonly string Directory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];

        private readonly string _fileName;

        public SolvesFactory(string fileName) =>
            _fileName = fileName;

        public SeriesOfMotions SeriesOfMotions()
        {
            var path = Path.Combine(Directory, _fileName);
            return new SeriesOfMotions(new CommandsTextStorage(new Text(path)));
        }
    }
}