using System.Collections.Generic;
using System.Linq;
using hill_climbing_algorithm_src.Data;
using hill_climbing_algorithm_src.Logic.Abstract;
using hill_climbing_algorithm_src.Storages.Abstract;

namespace hill_climbing_algorithm_src.Solves
{
    public class ScenicPath
    {
        private readonly IPathfinding _pathfinding;
        private readonly IHeightmap _heightmap;

        public ScenicPath(IPathfinding pathfinding, IHeightmap heightmap)
        {
            _pathfinding = pathfinding;
            _heightmap = heightmap;
        }
        
        public int TotalSteps() =>
            _pathfinding
                .Distances(fromPoint: _heightmap.Target)
                .Where(IsEquivalentStartPoint)
                .Min(pair => pair.Value);

        private bool IsEquivalentStartPoint(KeyValuePair<Vector2, int> pair) =>
            _heightmap[pair.Key] == _heightmap[_heightmap.Start];
    }
}