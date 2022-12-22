using System.Collections.Generic;
using System.Linq;
using distress_signal_src.Storages.Abstract;

namespace distress_signal_src.Logic
{
    public class DecoderKey
    {
        private readonly IText _text;
        private readonly IComparer<string> _comparer;
        private readonly string[] _dividers;

        public DecoderKey(IText text, IComparer<string> comparer, string[] dividers)
        {
            _text = text;
            _comparer = comparer;
            _dividers = dividers;
        }

        public int Key() =>
            _text
                .Lines()
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Concat(_dividers)
                .OrderBy(line => line, _comparer)
                .Select((line, index) => (line, index + 1))
                .Where(tuple => _dividers.Contains(tuple.line))
                .Select(tuple => tuple.Item2)
                .Aggregate(1, (a, b) => a * b);
    }
}