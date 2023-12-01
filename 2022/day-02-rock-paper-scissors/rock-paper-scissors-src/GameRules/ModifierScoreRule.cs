using System;
using rock_paper_scissors_src.GameRules.Abstract;
using rock_paper_scissors_src.Rounds;

namespace rock_paper_scissors_src.GameRules
{
    public class ModifierScoreRule : IGameRule
    {
        private readonly Func<int, int> _modifier;
        private readonly IGameRule _rule;

        public ModifierScoreRule(IGameRule rule, Func<int, int> modifier)
        {
            _rule = rule;
            _modifier = modifier;
        }

        public int Score(Round round)
        {
            var result = _rule.Score(round);
            var roundScore = _modifier(result);
            return roundScore;
        }
    }
}