using System;
using System.Collections.Generic;
using System.Linq;
using monkey_in_the_middle_src.Logic;
using monkey_in_the_middle_src.Logic.Data;
using monkey_in_the_middle_src.Logic.Modifiers;
using monkey_in_the_middle_src.Logic.Modifiers.Abstract;
using monkey_in_the_middle_src.Logic.TestPolicy;
using monkey_in_the_middle_src.Logic.TestPolicy.Abstract;
using monkey_in_the_middle_src.Storages.Abstract;

namespace monkey_in_the_middle_src.Storages
{
    public class MonkeyParser : IMonkeyParser
    {
        private readonly IWorryLevelModifier _extraModifier;

        public MonkeyParser(IWorryLevelModifier extraModifier) =>
            _extraModifier = extraModifier;
        
        public Monkey Parse(string setup)
        {
            var lines = setup.Split(Environment.NewLine);

            return new Monkey
            (
                new Brain
                (
                    TargetId(lines[4]),
                    TargetId(lines[5]),
                    new CombineWorryModifier(Modifier(lines[2]), _extraModifier),
                    WorryTestPolicy(lines[3])
                ),
                Items(lines[1]).ToList()
            );
        }

        private static IEnumerable<Item> Items(string input) =>
            input
                .Split(':')
                .Last()
                .Split(',')
                .Select(value => new Item(int.Parse(value)))
                .ToArray();

        private static IWorryLevelModifier Modifier(string input)
        {
            const string operationSeparator = ": new = ";
            
            var line = input
                .Split(operationSeparator)
                .Last()
                .Split(' ');
            
            var operation = line[1];
            var argument = line[2];

            return operation switch
            {
                "*" when argument == "old" => new SquaringWorryModifier(),
                "*" => new MultiplyWorryModifier(int.Parse(argument)),
                "+" => new SumWorryModifier(int.Parse(argument)),
                _ => throw new Exception()
            };
        }

        private static IWorryLevelPolicy WorryTestPolicy(string input)
        {
            var lines = input.Split(' ');

            if (lines.Contains("divisible"))
                return new DivisibleWorryLevelPolicy(int.Parse(lines.Last()));

            throw new ArgumentOutOfRangeException(nameof(WorryTestPolicy));
        }

        private static int TargetId(string input) =>
            int.Parse(input.Split(' ').Last());
    }
}