using System.Linq;
using regolith_reservoir_src.Data;
using regolith_reservoir_src.Extensions;
using regolith_reservoir_src.Logic.Abstract;

namespace regolith_reservoir_src.Logic
{
    public class Cave : ICave
    {
        private readonly ILine[] _lines;
        private int _highest = int.MinValue;

        public Cave(params ILine[] lines) =>
            _lines = lines;

        public int Height
        {
            get
            {
                if (_highest == int.MinValue)
                    _highest = _lines.HighestPoint();
                
                return _highest;
            }
        }

        public bool IsOccupied(Vector2 point) =>
            _lines.Any(line => line.IsCross(point));
    }
}