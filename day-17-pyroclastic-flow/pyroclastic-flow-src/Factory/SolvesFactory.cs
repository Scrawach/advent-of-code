using System;
using System.IO;
using System.Linq;
using pyroclastic_flow_src.Data;
using pyroclastic_flow_src.Logic;
using pyroclastic_flow_src.Storages;

namespace pyroclastic_flow_src.Factory
{
    public class SolvesFactory
    {
        private static readonly string WorkingDirectory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];

        private readonly string _fileName;
        private readonly string _shapesFileName;

        public SolvesFactory(string fileName, string shapesFileName)
        {
            _fileName = fileName;
            _shapesFileName = shapesFileName;
        }

        public Tunnel CreateTunnel()
        {
            var path = Path.Combine(WorkingDirectory, _fileName);
            var shapesPath = Path.Combine(WorkingDirectory, _shapesFileName);
            
            var sequence = new MovementTextSequence(new Text(path));
            var storage = new ShapeTextStorage(new Text(shapesPath));
            var shapes = new CyclicSelectPolicy(storage.All().ToArray());
            var rocks = new RocksFactory(shapes);
            return new Tunnel(sequence, rocks, 7, new Vector2(2, 3));
        }
    }
}