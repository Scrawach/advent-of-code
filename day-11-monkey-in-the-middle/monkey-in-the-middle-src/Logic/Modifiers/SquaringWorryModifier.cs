using monkey_in_the_middle_src.Logic.Modifiers.Abstract;

namespace monkey_in_the_middle_src.Logic.Modifiers
{
    public class SquaringWorryModifier : IWorryLevelModifier
    {
        public long Calculate(long worry) =>
            worry * worry;
    }
}