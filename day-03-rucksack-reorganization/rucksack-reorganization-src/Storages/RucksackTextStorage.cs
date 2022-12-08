using System.Collections.Generic;
using System.Linq;
using rucksack_reorganization_src.Logic;
using rucksack_reorganization_src.Logic.Abstract;
using rucksack_reorganization_src.Storages.Abstract;

namespace rucksack_reorganization_src.Storages
{
    public class RucksackTextStorage : IRucksackStorage
    {
        private readonly IText _text;

        public RucksackTextStorage(IText text) =>
            _text = text;

        public IEnumerable<IRucksack> All() =>
            _text
                .Lines()
                .Select(line => new Rucksack(line[..(line.Length/2)], line[(line.Length/2)..]));
    }
}