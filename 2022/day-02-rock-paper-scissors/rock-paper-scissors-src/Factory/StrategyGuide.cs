using System.Linq;
using rock_paper_scissors_src.GameRules.Abstract;
using rock_paper_scissors_src.Rounds.Abstract;

namespace rock_paper_scissors_src.Factory
{
    public class StrategyGuide
    {
        private readonly IGameRule _rules;
        private readonly IRoundsStorage _storage;

        public StrategyGuide(IGameRule rules, IRoundsStorage storage)
        {
            _rules = rules;
            _storage = storage;
        }

        public int TotalScore() =>
            _storage.Rounds()
                .Select(round => _rules.Score(round))
                .Sum();
    }
}