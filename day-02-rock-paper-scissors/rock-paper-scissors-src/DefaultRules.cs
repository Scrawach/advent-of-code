using System.Collections.Generic;

namespace rock_paper_scissors_src
{
    public class DefaultRules : IGameRule
    {
        private const string Rock = "Rock";
        private const string Paper = "Paper";
        private const string Scissors = "Scissors";

        private readonly IGameRule _rule;

        public DefaultRules() =>
            _rule = new Rules
            (
                new FirstMoreThanSecond(Rock, Scissors),
                new FirstMoreThanSecond(Scissors, Paper),
                new FirstMoreThanSecond(Paper, Rock)
            );

        public IEnumerable<string> AvailableChoices() =>
            new[] {Rock, Paper, Scissors};

        public int Score(string first, string second) =>
            _rule.Score(first, second);
    }
}