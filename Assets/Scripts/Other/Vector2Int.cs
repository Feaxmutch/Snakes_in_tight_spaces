using System;
using UnityEngine;
using DG.Tweening;

namespace Other
{
    public readonly struct Vector2Int
    {
        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2Int(Vector2Int vector2Int) : this(vector2Int.X, vector2Int.Y) { }

        public static Vector2Int Zero => new Vector2Int(0, 0);

        public int X { get; }

        public int Y { get; }

        public Vector2Int Normalized => Normalize();

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Vector2 ConvertToVector2()
        {
            return new Vector2(X, Y);
        }

        public static float Distance(Vector2Int a, Vector2Int b)
        {
            float num = a.X - b.X;
            float num2 = a.Y - b.Y;
            return (float)Math.Sqrt(num * num + num2 * num2);
        }

        private Vector2Int Normalize()
        {
            int x = Math.Clamp(X, -1, 1);
            int y = Math.Clamp(Y, -1, 1);
            return new Vector2Int(x, y);
        }

        public static Vector2Int operator +(Vector2Int left, Vector2Int right)
        {
            return new Vector2Int(left.X + right.X, left.Y + right.Y);
        }

        public static Vector2Int operator -(Vector2Int left, Vector2Int right)
        {
            return new Vector2Int(left.X - right.X, left.Y - right.Y);
        }

        public static Vector2Int operator *(Vector2Int left, int right)
        {
            return new Vector2Int(left.X * right, left.Y * right);
        }

        public static bool operator ==(Vector2Int left, Vector2Int right)
        {
            bool xEquals = left.X == right.X;
            bool yEquals = left.Y == right.Y;
            return xEquals && yEquals;
        }

        public static bool operator !=(Vector2Int left, Vector2Int right)
        {
            return (left == right) == false;
        }
    }
}