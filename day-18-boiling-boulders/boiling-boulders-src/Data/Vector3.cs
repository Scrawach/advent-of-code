using System;

namespace boiling_boulders_src.Data
{
    public readonly struct Vector3
    {
        public readonly int X;
        public readonly int Y;
        public readonly int Z;

        public Vector3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString() =>
            $"({X},{Y},{Z})";

        public bool Equals(Vector3 other) =>
            X == other.X && Y == other.Y && Z == other.Z;

        public override bool Equals(object obj) =>
            obj is Vector3 other && Equals(other);

        public override int GetHashCode() =>
            HashCode.Combine(X, Y, Z);

        public static Vector3 Left => new Vector3(-1, 0, 0);
        public static Vector3 Right => new Vector3(1, 0, 0);
        public static Vector3 Up => new Vector3(0, 1, 0);
        public static Vector3 Down => new Vector3(0, -1, 0);
        public static Vector3 Forward => new Vector3(0, 0, 1);
        public static Vector3 Back => new Vector3(0, 0, -1);

        public static Vector3 operator +(Vector3 left, Vector3 right) =>
            new Vector3
            (
                left.X + right.X,
                left.Y + right.Y,
                left.Z + right.Z
            );

        public static bool operator ==(Vector3 left, Vector3 right) =>
            left.Equals(right);

        public static bool operator !=(Vector3 left, Vector3 right) =>
            !(left == right);
    }
}