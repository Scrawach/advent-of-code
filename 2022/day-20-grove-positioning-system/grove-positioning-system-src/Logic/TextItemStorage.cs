using System.Collections.Generic;
using System.Linq;
using grove_positioning_system_src.Logic.Abstract;
using grove_positioning_system_src.Storages.Abstract;

namespace grove_positioning_system_src.Logic
{
    public class TextItemStorage : IItemStorage
    {
        private readonly IText _text;

        public TextItemStorage(IText text) =>
            _text = text;

        public IEnumerable<Item> All() =>
            _text.Lines()
                .Select(int.Parse)
                .Select(number => new Item(number));
    }
}