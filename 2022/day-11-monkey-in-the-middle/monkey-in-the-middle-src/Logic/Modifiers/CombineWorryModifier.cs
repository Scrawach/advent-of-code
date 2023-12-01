using System.Linq;
using monkey_in_the_middle_src.Logic.Modifiers.Abstract;

namespace monkey_in_the_middle_src.Logic.Modifiers
{
    public class CombineWorryModifier : IWorryLevelModifier
    {
        private readonly IWorryLevelModifier[] _modifiers;

        public CombineWorryModifier(params IWorryLevelModifier[] modifiers) =>
            _modifiers = modifiers;
        
        public long Calculate(long worry) =>
            _modifiers.Aggregate(worry, (current, modifier) => modifier.Calculate(current));
    }
}