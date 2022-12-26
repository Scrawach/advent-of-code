using System.Collections.Generic;
using System.Linq;
using pyroclastic_flow_src.Data;
using pyroclastic_flow_src.Logic.Abstract;
using pyroclastic_flow_src.Storages.Abstract;

namespace pyroclastic_flow_src.Logic
{
    public class Tunnel : ITunnel
    {
        private readonly IMovementSequence _movementSequence;
        private readonly IRockFactory _rocksFactory;
        private readonly List<Cell[]> _tunnel;

        private Vector2 _spawnPosition;

        public Tunnel(IMovementSequence movementSequence, IRockFactory rocksFactory, long width, Vector2 spawnPosition)
        {
            _movementSequence = movementSequence;
            _rocksFactory = rocksFactory;
            _spawnPosition = spawnPosition;
            _tunnel = new List<Cell[]>();
            Width = width;
        }

        public long Height { get; private set; }
        public long Width { get; }

        public ITunnel AddRocks(long amount)
        {
            for (var i = 0; i < amount; i++) 
                SimulateRockFalling();
            
            return this;
        }

        private void SimulateRockFalling()
        {
            var rock = _rocksFactory.Create(at: _spawnPosition);
            ExpandTunnel(_spawnPosition.Y + rock.Height + 10);
            var notGrounded = true;
            
            while (notGrounded)
            {
                TryMove(rock, _movementSequence.NextDirection());
                
                if (!TryMove(rock, Vector2.Down))
                    notGrounded = false;
            }

            Store(rock);
        }

        private void ExpandTunnel(int desiredHeight)
        {
            for (var i = _tunnel.Count; i < desiredHeight; i++)
                _tunnel.Add(new Cell[Width]);
        }

        private bool TryMove(Rock rock, Vector2 toDirection)
        {
            var nextPosition = rock.Position + toDirection;

            if (IsCollide(rock, at: nextPosition))
                return false;

            rock.Position = nextPosition;
            return true;
        }

        private bool IsCollide(Rock rock, Vector2 at) =>
            rock
                .Area()
                .Where(index => rock[index] == Cell.Rock)
                .Any(index => FromTunnel(index + at) == Cell.Rock);

        private Cell FromTunnel(Vector2 position)
        {
            if (position.Y < 0 || position.X < 0 || position.X >= Width)
                return Cell.Rock;
            
            return _tunnel[position.Y][position.X];
        }

        private void Store(Rock rock)
        {
            foreach (var index in rock.Area())
            {
                if (rock[index] == Cell.Rock)
                    _tunnel[rock.Position.Y + index.Y][rock.Position.X + index.X] = Cell.Rock;
            }

            var height = rock.Position.Y + rock.Height;
            
            if (height > Height)
                Height = height;

            _spawnPosition = new Vector2(2, (int)Height + 3);
        }
    }
}