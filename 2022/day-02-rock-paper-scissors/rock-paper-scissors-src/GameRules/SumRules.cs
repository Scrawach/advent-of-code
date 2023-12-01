using System.Linq;
using rock_paper_scissors_src.GameRules.Abstract;
using rock_paper_scissors_src.Rounds;

namespace rock_paper_scissors_src.GameRules
{
    public class SumRules : IGameRule
    {
        private readonly IGameRule[] _rules;

        public SumRules(params IGameRule[] rules) =>
            _rules = rules;

        public int Score(Round round) =>
            _rules.Select(rule => rule.Score(round)).Sum();
    }
}