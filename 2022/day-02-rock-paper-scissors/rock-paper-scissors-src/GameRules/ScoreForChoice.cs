using System;
using System.Collections.Generic;
using rock_paper_scissors_src.GameRules.Abstract;
using rock_paper_scissors_src.Rounds;

namespace rock_paper_scissors_src.GameRules
{
    public class ScoreForChoice : IGameRule
    {
        private readonly IChoicesStorage _choices;

        public ScoreForChoice(IChoicesStorage choices) =>
            _choices = choices;

        public int Score(Round round) =>
            IndexOf(_choices.AvailableChoices(), round.Player);

        private static int IndexOf(IEnumerable<string> choices, string element)
        {
            var score = 0;

            foreach (var choice in choices)
            {
                score += 1;

                if (choice == element)
                    return score;
            }

            throw new ArgumentException(nameof(IndexOf));
        }
    }
}