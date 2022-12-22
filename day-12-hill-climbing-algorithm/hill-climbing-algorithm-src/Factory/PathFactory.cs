using System;
using hill_climbing_algorithm_src.Logic;
using hill_climbing_algorithm_src.Logic.Abstract;
using hill_climbing_algorithm_src.Solves;
using hill_climbing_algorithm_src.Storages;
using hill_climbing_algorithm_src.Storages.Abstract;

namespace hill_climbing_algorithm_src.Factory
{
    public class PathFactory
    {
        private static readonly string WorkingDirectory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("/bin/", StringComparison.Ordinal)];

        private readonly string _fileName;

        public PathFactory(string fileName) =>
            _fileName = fileName;

        public SearchPath SearchPath()
        {
            var (pathfinding, heightmap) = CreateMap();
            return new SearchPath(pathfinding, heightmap);
        }

        public ScenicPath ScenicPath()
        {
            var (pathfinding, heightmap) = CreateMap();
            return new ScenicPath(pathfinding, heightmap);
        }

        private (IPathfinding pathfinding, IHeightmap map) CreateMap()
        {
            var path = System.IO.Path.Combine(WorkingDirectory, _fileName);
            var heightmap = new Heightmap(new Text(path));
            var pathfinding = new BreadthFirstSearch(heightmap);
            heightmap.Load();
            return (pathfinding, heightmap);
        }
    }
}