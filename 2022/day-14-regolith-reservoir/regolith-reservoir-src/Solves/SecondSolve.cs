using regolith_reservoir_src.Logic;
using regolith_reservoir_src.Logic.Simulation;

namespace regolith_reservoir_src.Solves
{
    public class SecondSolve
    {
        private readonly SandSimulation _simulation;

        public SecondSolve(SandSimulation simulation) =>
            _simulation = simulation;

        public int CountOfRestSands()
        {
            while (_simulation.IsPouringNotBlocked()) 
                _simulation.Simulate();
            return _simulation.CountOfRestSands();
        }
    }
}