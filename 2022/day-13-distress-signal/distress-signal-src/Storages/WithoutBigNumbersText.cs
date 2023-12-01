using System.Collections.Generic;
using System.Linq;
using distress_signal_src.Storages.Abstract;

namespace distress_signal_src.Storages
{
    public class WithoutBigNumbersText : IText
    {
        private readonly IText _text;

        public WithoutBigNumbersText(IText text) =>
            _text = text;

        public IEnumerable<string> Lines() =>
            _text
                .Lines()
                .Select(line => line.Replace("10", "A"));
    }
}