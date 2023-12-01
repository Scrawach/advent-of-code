using System.Collections.Generic;
using System.Linq;
using regolith_reservoir_src.Data;
using regolith_reservoir_src.Logic.Abstract;

namespace regolith_reservoir_src.Logic
{
    public class RectangularLine : ILine
    {
        private readonly Vector2[] _breakpoints;

        public RectangularLine(Vector2[] breakpoints) =>
            _breakpoints = breakpoints;

        public IEnumerable<Vector2> Points => 
            _breakpoints;

        public bool IsCross(Vector2 point)
        {
            var result = false;
            var previous = _breakpoints[0];
            
            for (var i = 1; i < _breakpoints.Length; i++)
            {
                var current = _breakpoints[i];

                if (previous.X == current.X)
                    result |= point.X == previous.X && IsInside(point.Y, previous.Y, current.Y);
                else if (previous.Y == current.Y) 
                    result |= point.Y == previous.Y && IsInside(point.X, previous.X, current.X);

                previous = current;
            }

            return result;
        }

        private static bool IsInside(int value, int left, int right) =>
            value >= left && value <= right
            || value <= left && value >= right;

        public override string ToString() =>
            _breakpoints.Aggregate("Line: ", (line, point) => $"{line}{point},");
    }
}