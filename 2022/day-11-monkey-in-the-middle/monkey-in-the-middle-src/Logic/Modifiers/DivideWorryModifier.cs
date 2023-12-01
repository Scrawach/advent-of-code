using monkey_in_the_middle_src.Logic.Modifiers.Abstract;

namespace monkey_in_the_middle_src.Logic.Modifiers
{
    public class DivideWorryModifier : IWorryLevelModifier
    {
        private readonly long _value;

        public DivideWorryModifier(long value) =>
            _value = value;

        public long Calculate(long worry) =>
            worry / _value;
    }
}