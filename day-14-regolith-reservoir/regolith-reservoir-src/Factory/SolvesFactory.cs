using System;
using System.IO;
using System.Linq;
using regolith_reservoir_src.Data;
using regolith_reservoir_src.Logic;
using regolith_reservoir_src.Logic.Abstract;
using regolith_reservoir_src.Logic.Simulation;
using regolith_reservoir_src.Solves;
using regolith_reservoir_src.Storages;

namespace regolith_reservoir_src.Factory
{
    public class SolvesFactory
    {
        private static readonly string WorkingDirectory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("/bin/", StringComparison.Ordinal)];

        private readonly string _fileName;

        public SolvesFactory(string fileName) =>
            _fileName = fileName;
        
        public FirstSolve FirstSolve(Vector2 pouringPoint) =>
            new FirstSolve(new SandSimulation(new Cave(CreateWalls()), pouringPoint));

        public SecondSolve SecondSolve(Vector2 pouringPoint) =>
            new SecondSolve(new SandSimulation(new CaveWithGround(CreateWalls()), pouringPoint));

        private ILine[] CreateWalls()
        {
            var path = Path.Combine(WorkingDirectory, _fileName);
            var storage = new LineTextStorage(new Text(path));
            return storage.All().ToArray();
        }
    }
}