using regolith_reservoir_src.Logic;
using regolith_reservoir_src.Logic.Simulation;

namespace regolith_reservoir_src.Solves
{
    public class FirstSolve
    {
        private readonly SandSimulation _simulation;

        public FirstSolve(SandSimulation simulation) =>
            _simulation = simulation;

        public int CountOfRestSands()
        {
            while(_simulation.IsParticlesInsideCave())
                _simulation.Simulate();
            return _simulation.CountOfRestSands();
        }
    }
}