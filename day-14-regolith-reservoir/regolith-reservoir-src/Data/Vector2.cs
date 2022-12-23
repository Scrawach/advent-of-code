using System;

namespace regolith_reservoir_src.Data
{
    public readonly struct Vector2
    {
        public readonly int X;
        public readonly int Y;

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() =>
            $"({X},{Y})";

        public bool Equals(Vector2 other) =>
            X == other.X && Y == other.Y;

        public override bool Equals(object obj) =>
            obj is Vector2 other && Equals(other);

        public override int GetHashCode() =>
            HashCode.Combine(X, Y);

        public static Vector2 Up => new Vector2(0, 1);
        public static Vector2 Down => new Vector2(0, -1);
        public static Vector2 Left => new Vector2(-1, 0);
        public static Vector2 Right => new Vector2(1, 0);

        public static Vector2 operator +(Vector2 left, Vector2 right) =>
            new Vector2(left.X + right.X, left.Y + right.Y);

        public static Vector2 operator -(Vector2 left, Vector2 right) =>
            new Vector2(left.X - right.X, left.Y - right.Y);

        public static bool operator ==(Vector2 left, Vector2 right) =>
            left.X == right.X && left.Y == right.Y;

        public static bool operator !=(Vector2 left, Vector2 right) =>
            !(left == right);
    }
}