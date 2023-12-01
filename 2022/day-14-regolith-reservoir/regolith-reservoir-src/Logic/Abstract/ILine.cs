using System.Collections.Generic;
using regolith_reservoir_src.Data;

namespace regolith_reservoir_src.Logic.Abstract
{
    public interface ILine
    {
        IEnumerable<Vector2> Points { get; }
        bool IsCross(Vector2 point);
    }
}