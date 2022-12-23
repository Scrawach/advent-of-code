using regolith_reservoir_src.Data;

namespace regolith_reservoir_src.Logic.Simulation
{
    public class Particle
    {
        public Vector2 Position;

        public Particle(Vector2 position) =>
            Position = position;
    }
}