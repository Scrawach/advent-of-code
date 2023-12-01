using System.Collections.Generic;
using System.Linq;
using boiling_boulders_src.Data;
using boiling_boulders_src.Storages.Abstract;

namespace boiling_boulders_src.Logic
{
    public class LavaDroplet
    {
        private readonly ICubeStorage _cubeStorage;

        private readonly Vector3[] _directions = {
            Vector3.Left, Vector3.Right, Vector3.Up,
            Vector3.Down, Vector3.Forward, Vector3.Back
        };

        public LavaDroplet(ICubeStorage cubeStorage) =>
            _cubeStorage = cubeStorage;
        
        public int SurfaceArea()
        {
            var map = new HashSet<Vector3>();
            
            foreach (var center in _cubeStorage.All())
                map.Add(center);

            return _cubeStorage
                .All()
                .Sum(center => Neighbours(center)
                    .Count(neighbour => !map.Contains(neighbour)));
        }
        
        private IEnumerable<Vector3> Neighbours(Vector3 center) =>
            _directions.Select(direction => center + direction);
    }
}