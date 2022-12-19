using cathode_ray_tube_src.Logic.Abstract;
using cathode_ray_tube_src.Logic.Strengths.Abstract;

namespace cathode_ray_tube_src.Logic
{
    public class StrengthCounter : IWaitCycle
    {
        private readonly IStrengthCalculatePolicy _calculatePolicy;

        public StrengthCounter(IStrengthCalculatePolicy calculatePolicy) =>
            _calculatePolicy = calculatePolicy;
        
        public int Total { get; private set; }
        
        public void OnCycleDone(int numberOfCycle, int registerValue) =>
            Total += _calculatePolicy.Calculate(numberOfCycle, registerValue);
    }
}