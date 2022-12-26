using System;
using System.IO;
using boiling_boulders_src.Logic;
using boiling_boulders_src.Storages;

namespace boiling_boulders_src.Factory
{
    public class SolvesFactory
    {
        private static readonly string WorkingDirectory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];

        private readonly string _fileName;

        public SolvesFactory(string fileName) =>
            _fileName = fileName;

        public LavaDroplet CreateDroplet()
        {
            var path = Path.Combine(WorkingDirectory, _fileName);
            var text = new Text(path);
            var storage = new CubeTextStorage(text);
            return new LavaDroplet(storage);
        }
    }
}