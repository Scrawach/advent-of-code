using System;
using System.IO;
using clamp_cleanup_src.Logic;
using clamp_cleanup_src.Storages;

namespace clamp_cleanup_src.Factory
{
    public class CampFactory
    {
        private static readonly string WorkingDirectory =
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];

        private readonly string _inputFileName;

        public CampFactory(string inputFileName) =>
            _inputFileName = inputFileName;
        
        public Camp Create() =>
            new Camp(new PairRangeTextStorage(new Text(Path.Combine(WorkingDirectory, _inputFileName))));
    }
}