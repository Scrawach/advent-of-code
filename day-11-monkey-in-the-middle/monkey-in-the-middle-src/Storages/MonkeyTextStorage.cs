using System;
using System.Collections.Generic;
using monkey_in_the_middle_src.Logic;
using monkey_in_the_middle_src.Storages.Abstract;

namespace monkey_in_the_middle_src.Storages
{
    public class MonkeyTextStorage : IMonkeyStorage
    {
        private readonly IText _text;
        private readonly IMonkeyParser _parser;

        public MonkeyTextStorage(IText text, IMonkeyParser parser)
        {
            _text = text;
            _parser = parser;
        }

        public IEnumerable<Monkey> All()
        {
            var monkeySetups = _text
                .All()
                .Split(Environment.NewLine + Environment.NewLine);

            foreach (var setup in monkeySetups)
                yield return _parser.Parse(setup);
        }
        
    }
}