using monkey_in_the_middle_src.Logic.Modifiers.Abstract;

namespace monkey_in_the_middle_src.Logic.Modifiers
{
    public class SumWorryModifier : IWorryLevelModifier
    {
        private readonly long _addValue;

        public SumWorryModifier(long addValue) =>
            _addValue = addValue;
        
        public long Calculate(long worry) =>
            worry + _addValue;
    }
}