using cathode_ray_tube_src.Logic.Strengths.Abstract;

namespace cathode_ray_tube_src.Logic.Strengths
{
    public class MultiplyByNumberOfCycle : IStrengthCalculatePolicy
    {
        private readonly int _expectedNumberOfCycle;

        public MultiplyByNumberOfCycle(int expectedNumberOfCycle) =>
            _expectedNumberOfCycle = expectedNumberOfCycle;

        public int Calculate(int numberOfCycle, int value) =>
            _expectedNumberOfCycle == numberOfCycle 
                ? _expectedNumberOfCycle * value 
                : 0;
    }
}