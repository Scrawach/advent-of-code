using System.Collections.Generic;
using System.Linq;
using clamp_cleanup_src.Logic;
using clamp_cleanup_src.Storages.Abstract;

namespace clamp_cleanup_src.Storages
{
    public class PairRangeTextStorage
    {
        private readonly IText _text;

        public PairRangeTextStorage(IText text) =>
            _text = text;

        public IEnumerable<PairRange> All() =>
            _text.Lines()
                .Select(line => line.Split(','))
                .Select(input => new PairRange(CreateRange(input[0]), CreateRange(input[1])));

        private static Range CreateRange(string range)
        {
            var border = range.Split('-');
            return new Range(int.Parse(border[0]), int.Parse(border[1]));
        }
    }
}