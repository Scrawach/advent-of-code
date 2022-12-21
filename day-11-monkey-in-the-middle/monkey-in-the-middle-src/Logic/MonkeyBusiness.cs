using System.Collections.Generic;
using System.Linq;
using monkey_in_the_middle_src.Extensions;

namespace monkey_in_the_middle_src.Logic
{
    public class MonkeyBusiness
    {
        private readonly Monkey[] _monkeys;
        private readonly int _leaderCount;

        public MonkeyBusiness(Monkey[] monkeys, int leaderCount)
        {
            _monkeys = monkeys;
            _leaderCount = leaderCount;
        }

        public long Simulate(int rounds)
        {
            var round = new Round(_monkeys);
                
            for (var i = 0; i < rounds; i++)
                round.Play();

            return InspectionCountLeaders(_leaderCount)
                .Multiply(monkey => monkey.InspectionCount);
        }

        private IEnumerable<Monkey> InspectionCountLeaders(int count) =>
            _monkeys
                .OrderByDescending(monkey => monkey.InspectionCount)
                .Take(count);
    }
}