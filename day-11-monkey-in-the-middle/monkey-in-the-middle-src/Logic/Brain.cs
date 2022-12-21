using monkey_in_the_middle_src.Logic.Abstract;
using monkey_in_the_middle_src.Logic.Data;
using monkey_in_the_middle_src.Logic.Modifiers.Abstract;
using monkey_in_the_middle_src.Logic.TestPolicy.Abstract;

namespace monkey_in_the_middle_src.Logic
{
    public class Brain : IBrain
    {
        private readonly int _passedTarget;
        private readonly int _failedTarget;
        private readonly IWorryLevelModifier _worryModifier;
        private readonly IWorryLevelPolicy _worryPolicy;

        public Brain(int passedTarget, int failedTarget, IWorryLevelModifier worryModifier, IWorryLevelPolicy worryPolicy)
        {
            _passedTarget = passedTarget;
            _failedTarget = failedTarget;
            _worryModifier = worryModifier;
            _worryPolicy = worryPolicy;
        }
        
        public int NextTarget(Item item)
        {
            item.WorryLevel = _worryModifier.Calculate(item.WorryLevel);
            
            return _worryPolicy.IsCriticalLevel(item.WorryLevel)
                ? _passedTarget
                : _failedTarget;
        }
    }
}