using System;

namespace Other
{
    public static class MathExtentions
    {
        public static bool IsNegative<T>(this T value) where T : struct, IComparable
        {
            return value.CompareTo(default) < 0;
        }

        public static bool IsInRange<T>(this T value, T min, T max) where T : struct, IComparable
        {
            return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
        } 
    }
}