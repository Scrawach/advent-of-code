using System.Collections.Generic;

namespace rock_paper_scissors_src
{
    public class DefaultRules
    {
        private const string Rock = "Rock";
        private const string Paper = "Paper";
        private const string Scissors = "Scissors";

        public IEnumerable<string> AvailableChoices() =>
            new[] {Rock, Paper, Scissors};

        public int Score(string first, string second)
        {
            if (first == second)
                return 0;
            return -1;
        }
    }
}