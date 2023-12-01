using hill_climbing_algorithm_src.Logic.Abstract;
using hill_climbing_algorithm_src.Storages.Abstract;

namespace hill_climbing_algorithm_src.Solves
{
    public class SearchPath
    {
        private readonly IPathfinding _pathfinding;
        private readonly IHeightmap _heightmap;

        public SearchPath(IPathfinding pathfinding, IHeightmap heightmap)
        {
            _pathfinding = pathfinding;
            _heightmap = heightmap;
        }

        public int TotalSteps() =>
            _pathfinding
                .Distances(fromPoint: _heightmap.Target)
                [_heightmap.Start];
    }
}