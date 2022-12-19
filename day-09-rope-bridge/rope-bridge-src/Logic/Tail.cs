using System;
using System.Collections.Generic;
using rope_bridge_src.Data;

namespace rope_bridge_src.Logic
{
    public class Tail : IMovable
    {
        public IMovable Head { get; }
        
        public Vector2 Position { get; private set; }
        
        public HashSet<Vector2> UniquePositions { get; }
        
        public Tail(IMovable head)
        {
            Head = head;
            UniquePositions = new HashSet<Vector2> { Position };
        }

        public void Update()
        {
            var directionToHead = Head.Position - Position;

            if (IsOneStepToHead(directionToHead))
                return;

            Move(OneStep(directionToHead, -1, 1));
            UniquePositions.Add(Position);
        }

        private void Move(Vector2 direction) =>
            Position += direction;
        
        private static Vector2 OneStep(Vector2 direction, int min, int max)
        {
            var x = Math.Clamp(direction.X, min, max);
            var y = Math.Clamp(direction.Y, min, max);
            return new Vector2(x, y);
        }

        private static bool IsOneStepToHead(Vector2 direction) =>
            direction.Magnitude() == 1;
    }
}