using System.Collections.Generic;
using System.Linq;
using regolith_reservoir_src.Data;
using regolith_reservoir_src.Logic;
using regolith_reservoir_src.Logic.Abstract;
using regolith_reservoir_src.Storages.Abstract;

namespace regolith_reservoir_src.Storages
{
    public class LineTextStorage : ILineTextStorage
    {
        private readonly IText _text;

        public LineTextStorage(IText text) =>
            _text = text;
        
        public IEnumerable<ILine> All() =>
            _text
                .Lines()
                .Select(line => line.Split(" -> "))
                .Select(coords => coords
                    .Select(coord => coord.Split(','))
                    .Select(values => new Vector2(int.Parse(values[0]), int.Parse(values[1]))))
                .Select(points => new RectangularLine(points.ToArray()));
    }
}