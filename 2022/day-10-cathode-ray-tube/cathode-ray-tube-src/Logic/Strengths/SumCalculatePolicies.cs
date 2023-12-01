using System.Linq;
using cathode_ray_tube_src.Logic.Strengths.Abstract;

namespace cathode_ray_tube_src.Logic.Strengths
{
    public class SumCalculatePolicies : IStrengthCalculatePolicy
    {
        private readonly IStrengthCalculatePolicy[] _policies;

        public SumCalculatePolicies(params IStrengthCalculatePolicy[] policies) =>
            _policies = policies;
        
        
        public int Calculate(int numberOfCycle, int value) =>
            _policies.Sum(policy => policy.Calculate(numberOfCycle, value));
    }
}