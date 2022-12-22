using System.Collections.Generic;
using hill_climbing_algorithm_src.Data;

namespace hill_climbing_algorithm_src.Logic.Abstract
{
    public interface IPathfinding
    {
        Dictionary<Vector2, int> Distances(Vector2 fromPoint);
    }
}