using System.Linq;

namespace rock_paper_scissors_src
{
    public class Rules : IGameRule
    {
        private readonly IGameRule[] _rules;

        public Rules(params IGameRule[] rules) =>
            _rules = rules;
        
        public int Score(string first, string second) =>
            _rules.Select(rule => rule.Score(first, second)).Sum();
    }
}