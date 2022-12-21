using monkey_in_the_middle_src.Logic.Modifiers.Abstract;

namespace monkey_in_the_middle_src.Logic.Modifiers
{
    public class MultiplyWorryModifier : IWorryLevelModifier
    {
        private readonly long _multiplyValue;

        public MultiplyWorryModifier(long multiplyValue) =>
            _multiplyValue = multiplyValue;
        
        public long Calculate(long worry) =>
            worry * _multiplyValue;
    }
}