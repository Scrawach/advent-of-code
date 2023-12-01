using System;
using System.Collections.Generic;
using rope_bridge_src.Commands;
using rope_bridge_src.Commands.Abstract;
using rope_bridge_src.Data;
using rope_bridge_src.Storages.Abstract;

namespace rope_bridge_src.Storages
{
    public class CommandsTextStorage : ICommandsStorage
    {
        private readonly IText _text;

        public CommandsTextStorage(IText text) =>
            _text = text;
        
        public IEnumerable<IHeadCommand> All()
        {
            foreach (var line in _text.All())
            {
                var (direction, steps) = Parse(line);
                
                for (var i = 0; i < steps; i++)
                {
                    yield return new MoveCommand(direction);
                }
            }
        }

        private static (Vector2 direction, int steps) Parse(string line)
        {
            var args = line.Split(' ');
            return (DirectionFromSymbol(args[0]), int.Parse(args[1]));
        }
        
        private static Vector2 DirectionFromSymbol(string symbol) =>
            symbol switch
            {
                "R" => Vector2.Right,
                "U" => Vector2.Up,
                "L" => Vector2.Left,
                "D" => Vector2.Down,
                _ => throw new ArgumentException(nameof(DirectionFromSymbol))
            };
    }
}