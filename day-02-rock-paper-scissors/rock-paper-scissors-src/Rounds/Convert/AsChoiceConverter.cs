using System.Collections.Generic;
using rock_paper_scissors_src.GameRules.Abstract;

namespace rock_paper_scissors_src.Rounds.Convert
{
    public class AsChoiceConverter : IConverter
    {
        private readonly IChoicesStorage _choices;
        private readonly Dictionary<string, int> _map;

        public AsChoiceConverter(IChoicesStorage choices)
        {
            _choices = choices;

            _map = new Dictionary<string, int>
            {
                ["a"] = 0,
                ["x"] = 0,

                ["b"] = 1,
                ["y"] = 1,

                ["c"] = 2,
                ["z"] = 2
            };
        }

        public Round Convert(string first, string second)
        {
            var firstChoice = _choices.AvailableChoices()[_map[first]];
            var secondChoice = _choices.AvailableChoices()[_map[second]];
            return new Round(secondChoice, firstChoice);
        }
    }
}