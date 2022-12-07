using System.Collections.Generic;
using rock_paper_scissors_src.GameRules.Abstract;
using rock_paper_scissors_src.Rounds;

namespace rock_paper_scissors_src.GameRules
{
    public class DefaultRules : IGameRule, IChoicesStorage
    {
        public const string Rock = "Rock";
        public const string Paper = "Paper";
        public const string Scissors = "Scissors";
        private readonly string[] _choices = {Rock, Paper, Scissors};

        private readonly IGameRule _rule;

        public DefaultRules() =>
            _rule = new SumRules
            (
                new FirstMoreThanSecond(Rock, Scissors),
                new FirstMoreThanSecond(Scissors, Paper),
                new FirstMoreThanSecond(Paper, Rock)
            );

        public IReadOnlyList<string> AvailableChoices() =>
            _choices;

        public int Score(Round round) =>
            _rule.Score(round);
    }
}