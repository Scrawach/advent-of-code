using hill_climbing_algorithm_src.Data;

namespace hill_climbing_algorithm_src.Storages.Abstract
{
    public interface IHeightmap
    {
        int this[Vector2 position] { get; }
        public Vector2 Start { get; }
        public Vector2 Target { get; }
        bool Has(Vector2 position);
    }
}