using System.Collections.Generic;
using System.Text.RegularExpressions;
using supply_stacks_src.Commands;
using supply_stacks_src.Commands.Abstract;
using supply_stacks_src.Storages.Abstract;

namespace supply_stacks_src.Storages
{
    public class CommandTextStorage : ICommandStorage
    {
        private readonly IText _text;

        public CommandTextStorage(IText text) =>
            _text = text;

        public IEnumerable<ICommand> All()
        {
            const string regex = @"move (\d+) from (\d+) to (\d+)";
            
            foreach (var line in _text.Lines())
            {
                var match = Regex.Match(line, regex);
                
                if (match.Success)
                    yield return CreateMoveCommand(match);
            }
        }

        private static ICommand CreateMoveCommand(Match match)
        {
            var count = int.Parse(match.Groups[1].Value);
            var fromStackIndex = int.Parse(match.Groups[2].Value);
            var toStackIndex = int.Parse(match.Groups[3].Value);
            return new MoveCommand(count, fromStackIndex, toStackIndex);
        }
    }
}