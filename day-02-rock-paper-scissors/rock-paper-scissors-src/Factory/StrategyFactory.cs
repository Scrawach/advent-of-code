using System;
using System.IO;
using rock_paper_scissors_src.GameRules;
using rock_paper_scissors_src.Rounds;
using rock_paper_scissors_src.Rounds.Convert;

namespace rock_paper_scissors_src.Factory
{
    public sealed class StrategyFactory
    {
        private static readonly string WorkingDirectory =
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];

        private readonly string _inputFile;

        public StrategyFactory(string input) =>
            _inputFile = input;

        public StrategyGuide ChoiceBased()
        {
            var rules = new DefaultRules();
            return Create(_inputFile, rules, new AsChoiceConverter(rules));
        }

        public StrategyGuide ResultBased()
        {
            var rules = new DefaultRules();
            return Create(_inputFile, rules, new AsRoundResultConverter(rules, rules));
        }

        private static StrategyGuide Create(string fileName, DefaultRules rules, IConverter converter)
        {
            var path = Path.Combine(WorkingDirectory, fileName);
            return new StrategyGuide
            (
                new SumRules
                (
                    new ModifierScoreRule(rules, ScoreModifier),
                    new ScoreForChoice(rules)
                ),
                new RoundsTextStorage(converter, new Text(path))
            );
        }

        private static int ScoreModifier(int value) =>
            (value + 1) * 3;
    }
}