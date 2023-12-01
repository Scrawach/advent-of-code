using monkey_in_the_middle_src.Logic.TestPolicy.Abstract;

namespace monkey_in_the_middle_src.Logic.TestPolicy
{
    public class DivisibleWorryLevelPolicy : IWorryLevelPolicy
    {
        private readonly long _divisible;

        public DivisibleWorryLevelPolicy(long divisible) =>
            _divisible = divisible;
        
        public bool IsCriticalLevel(long worry) =>
            worry % _divisible == 0;
    }
}