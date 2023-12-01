using System.Collections.Generic;
using System.Linq;
using hill_climbing_algorithm_src.Data;
using hill_climbing_algorithm_src.Logic.Abstract;
using hill_climbing_algorithm_src.Storages.Abstract;

namespace hill_climbing_algorithm_src.Logic
{
    public class BreadthFirstSearch : IPathfinding
    {
        private readonly IHeightmap _heightmap;

        public BreadthFirstSearch(IHeightmap heightmap) =>
            _heightmap = heightmap;
        
        public Dictionary<Vector2, int> Distances(Vector2 fromPoint)
        {
            var distances = new Dictionary<Vector2, int> {[fromPoint] = 0};
            var searchQueue = new Queue<Vector2>(new[] {fromPoint});

            while (searchQueue.Count > 0)
            {
                var point = searchQueue.Dequeue();
                
                foreach (var neighbour in Neighbours(point)
                    .Where(p => NotMuchHeightDifference(point, p))
                    .Where(p => !distances.ContainsKey(p)))
                {
                    distances[neighbour] = distances[point] + 1;
                    searchQueue.Enqueue(neighbour);
                }
            }

            return distances;
        }
        
        private bool NotMuchHeightDifference(Vector2 point, Vector2 neighbour) =>
            _heightmap[point] - _heightmap[neighbour] <= 1;
        
        private IEnumerable<Vector2> Neighbours(Vector2 point)
        {
            var directions = new[] {Vector2.Left, Vector2.Up, Vector2.Right, Vector2.Down};
            foreach (var direction in directions)
            {
                var neighbour = point + direction;

                if (_heightmap.Has(neighbour))
                    yield return neighbour;
            }
        }
    }
}