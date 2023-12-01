using System;
using System.Collections.Generic;
using System.Linq;
using rock_paper_scissors_src.GameRules.Abstract;

namespace rock_paper_scissors_src.Rounds.Convert
{
    public class AsRoundResultConverter : IConverter
    {
        private readonly IChoicesStorage _choices;

        private readonly Dictionary<string, int> _map = new Dictionary<string, int>
        {
            ["a"] = 0,
            ["b"] = 1,
            ["c"] = 2
        };

        private readonly IGameRule _rule;

        public AsRoundResultConverter(IChoicesStorage choices, IGameRule rule)
        {
            _choices = choices;
            _rule = rule;
        }

        public Round Convert(string first, string second) =>
            second switch
            {
                "x" => CreateLoseRound(first),
                "y" => CreateDrawRound(first),
                "z" => CreateWinRound(first),
                _ => throw new ArgumentException(nameof(Convert))
            };

        private Round CreateWinRound(string opponentKey) =>
            AvailableRounds(opponentKey)
                .OrderByDescending(round => round.Score)
                .First()
                .Round;

        private Round CreateLoseRound(string opponentKey) =>
            AvailableRounds(opponentKey)
                .OrderBy(round => round.Score)
                .First()
                .Round;

        private Round CreateDrawRound(string opponentKey) =>
            AvailableRounds(opponentKey)
                .First(round => round.Score == 0)
                .Round;

        private IEnumerable<(int Score, Round Round)> AvailableRounds(string opponentKey)
        {
            var choices = _choices.AvailableChoices();
            var opponentChoice = choices[_map[opponentKey]];

            return choices
                .Select(choice => new Round(choice, opponentChoice))
                .Select(round => (_rule.Score(round), round));
        }
    }
}