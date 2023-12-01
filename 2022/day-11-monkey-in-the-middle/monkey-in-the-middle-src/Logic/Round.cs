using System;
using System.Collections.Generic;
using System.Linq;
using monkey_in_the_middle_src.Logic.Data;

namespace monkey_in_the_middle_src.Logic
{
    public class Round
    {
        private readonly Monkey[] _monkeys;

        public Round(Monkey[] monkeys) =>
            _monkeys = monkeys;

        public void Play()
        {
            foreach (var monkey in _monkeys)
            {
                if (monkey.HasItem)
                    ProcessThrowing(monkey.ThrowItems());
            }
        }

        private void ProcessThrowing(IEnumerable<ThrowingItem> throwingItems)
        {
            foreach (var throwing in throwingItems) 
                _monkeys[throwing.TargetMonkeyId].Catch(throwing.Item);
        }
    }
}