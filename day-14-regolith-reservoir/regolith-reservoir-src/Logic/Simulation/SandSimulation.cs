using System.Collections.Generic;
using regolith_reservoir_src.Data;
using regolith_reservoir_src.Logic.Abstract;

namespace regolith_reservoir_src.Logic.Simulation
{
    public class SandSimulation
    {
        private readonly ICave _cave;
        private readonly Vector2 _pouringPoint;
        private readonly List<Particle> _particles;
        private readonly HashSet<Vector2> _inRestSands;
        
        private readonly Vector2[] _fallDirections;
        
        private int _highestParticle;
        
        public SandSimulation(ICave cave, Vector2 pouringPoint)
        {
            _cave = cave;
            _pouringPoint = pouringPoint;
            _particles = new List<Particle>();
            _inRestSands = new HashSet<Vector2>();
            
            _fallDirections = new[]
            {
                Vector2.Up,
                Vector2.Up + Vector2.Left,
                Vector2.Up + Vector2.Right
            };
        }

        public void Simulate(int steps = 1)
        {
            for (var i = 0; i < steps; i++)
            {
                if (TryParticleGrounded(out var particle))
                    _particles.Remove(particle);
                
                _particles.Add(new Particle(_pouringPoint));
            }
        }

        public bool IsPouringNotBlocked() =>
            !_inRestSands.Contains(_pouringPoint);

        public bool IsParticlesInsideCave() =>
            _highestParticle < _cave.Height;

        public int CountOfRestSands() =>
            _inRestSands.Count;

        private bool TryParticleGrounded(out Particle grounded)
        {
            grounded = null;
            
            foreach (var particle in _particles)
            {
                var nextPosition = NextPosition(particle.Position, _fallDirections, _cave, _inRestSands);

                if (nextPosition == particle.Position)
                {
                    grounded = particle;
                    _inRestSands.Add(grounded.Position);
                }
                else
                {
                    particle.Position = nextPosition;
            
                    if (nextPosition.Y >= _highestParticle)
                        _highestParticle = nextPosition.Y;
                }
            }

            return grounded != null;
        }

        private static Vector2 NextPosition(Vector2 current, Vector2[] directions, ICave walls, ICollection<Vector2> sands)
        {
            for (var i = 0; i < directions.Length; i++)
            {
                var next = current + directions[i];
                if (IsAvailablePosition(next, walls, sands))
                    return next;
            }

            return current;
        }

        private static bool IsAvailablePosition(Vector2 point, ICave walls, ICollection<Vector2> otherSand) =>
            !walls.IsOccupied(point) && !otherSand.Contains(point);
    }
}