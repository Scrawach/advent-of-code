using System.Collections.Generic;
using System.Linq;
using regolith_reservoir_src.Logic.Abstract;

namespace regolith_reservoir_src.Extensions
{
    public static class EnumerableExtensions
    {
        public static int HighestPoint(this IEnumerable<ILine> lines) =>
            lines
                .Aggregate(int.MinValue, (current, line) => line.Points
                    .Select(linePoint => linePoint.Y)
                    .Prepend(current)
                    .Max());
    }
}