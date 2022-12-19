using System;
using System.Collections.Generic;
using System.Linq;
using cathode_ray_tube_src.Instructions;
using cathode_ray_tube_src.Instructions.Abstract;
using cathode_ray_tube_src.Storages.Abstract;

namespace cathode_ray_tube_src.Storages
{
    public class InstructionTextMemory : IInstructionMemory
    {
        private readonly IText _text;

        public InstructionTextMemory(IText text) =>
            _text = text;
        
        public IEnumerable<IInstruction> All() =>
            _text.Lines()
                .Select(Parse);

        private IInstruction Parse(string line)
        {
            var args = line.Split(' ');
            return args[0] switch
            {
                "noop" => new NoOperationInstruction(),
                "addx" => new AddXInstruction(int.Parse(args[1])),
                _ => throw new ArgumentOutOfRangeException(nameof(Parse))
            };
        }
    }
}