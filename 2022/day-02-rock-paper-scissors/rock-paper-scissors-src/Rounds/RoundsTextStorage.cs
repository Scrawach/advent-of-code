using System.Collections.Generic;
using rock_paper_scissors_src.Rounds.Abstract;
using rock_paper_scissors_src.Rounds.Convert;

namespace rock_paper_scissors_src.Rounds
{
    public class RoundsTextStorage : IRoundsStorage
    {
        private readonly IConverter _converter;
        private readonly IText _text;

        public RoundsTextStorage(IConverter converter, IText text)
        {
            _converter = converter;
            _text = text;
        }

        public IEnumerable<Round> Rounds()
        {
            const char delimiter = ' ';

            foreach (var line in _text.Lines())
            {
                var choices = line.Split(delimiter);
                yield return _converter.Convert(choices[0].ToLower(), choices[1].ToLower());
            }
        }
    }
}