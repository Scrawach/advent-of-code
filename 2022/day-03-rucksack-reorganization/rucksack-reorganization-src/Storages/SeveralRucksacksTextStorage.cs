using System.Collections.Generic;
using rucksack_reorganization_src.Logic;
using rucksack_reorganization_src.Logic.Abstract;
using rucksack_reorganization_src.Storages.Abstract;

namespace rucksack_reorganization_src.Storages
{
    public class SeveralRucksacksTextStorage : IRucksackStorage
    {
        private readonly IText _text;
        private readonly string[] _previous;

        public SeveralRucksacksTextStorage(IText text, int count = 3)
        {
            _text = text;
            _previous = new string[count];
        }

        public IEnumerable<IRucksack> All()
        {
            var count = 0;
            foreach (var line in _text.Lines())
            {
                _previous[count] = line;
                count++;

                if (count != _previous.Length) 
                    continue;
                
                yield return new Rucksack(_previous);
                count = 0;
            }
        }
    }
}