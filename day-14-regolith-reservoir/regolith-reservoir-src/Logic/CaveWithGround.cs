using System.Linq;
using regolith_reservoir_src.Data;
using regolith_reservoir_src.Extensions;
using regolith_reservoir_src.Logic.Abstract;

namespace regolith_reservoir_src.Logic
{
    public class CaveWithGround : ICave
    {
        private readonly ILine[] _lines;
        private ILine _ground;

        public CaveWithGround(params ILine[] lines) =>
            _lines = lines;

        public int Height { get; private set; }

        public bool IsOccupied(Vector2 point)
        {
            _ground ??= FindGround();

            if (_ground.IsCross(point))
                return true;

            foreach (var line in _lines)
            {
                if (line.IsCross(point))
                    return true;
            }

            return false;
        }
        
        private ILine FindGround()
        {
            Height = _lines.HighestPoint() + 2;

            return new RectangularLine(new[]
            {
                new Vector2(int.MinValue, Height),
                new Vector2(int.MaxValue, Height)
            });
        }
    }
}