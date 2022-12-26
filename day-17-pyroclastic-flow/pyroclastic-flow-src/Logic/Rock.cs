using System.Collections.Generic;
using System.Linq;
using pyroclastic_flow_src.Data;

namespace pyroclastic_flow_src.Logic
{
    public class Rock
    {
        public readonly Cell[,] Shape;
        
        public Vector2 Position;

        public Rock(Vector2 position, Cell[,] shape)
        {
            Position = position;
            Shape = shape;
        }

        public Cell this[Vector2 index] => Shape[index.Y, index.X];
        
        public int Height => Shape.GetLength(0);

        public int Width => Shape.GetLength(1);

        public IEnumerable<Vector2> Area() =>
            from y in Enumerable.Range(0, Shape.GetLength(0))
            from x in Enumerable.Range(0, Shape.GetLength(1))
            select new Vector2(x, y);
    }
}