using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Snippets
{
    public static class FastMath
    {
        /// <summary>
        ///     Approximation pow
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveInlining)]
        public static double FastPow(this double @base, double exp)
        {
            var tmp = (int) (BitConverter.DoubleToInt64Bits(@base) >> 32);
            var tmp2 = (int) (exp * (tmp - 1072632447) + 1072632447);
            return BitConverter.Int64BitsToDouble((long) tmp2 << 32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveInlining)]
        public static int IntegerPow(this int @base, int exp)
        {
            var result = 1;
            while (exp > 0)
            {
                if ((exp & 1) != 0) result *= @base;
                exp >>= 1;
                @base *= @base;
            }

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveInlining)]
        public static bool IsPrime(this int number)
        {
            const int doubleMaxDelta = 2 * 100;
            if (number <= 2) return true;
            if (number % 2 == 0) return false;
            var top = Math.Min(((float) number).Sqrt2() + doubleMaxDelta, number - 1);
            for (var i = 3; i <= top; i += 2)
                if (number % i == 0)
                    return false;
            return true;
        }

        /// <summary>
        ///     Approximation sqrt
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveInlining)]
        public static float Sqrt2(this float z)
        {
            if (z == 0) return 0;
            FloatIntUnion u;
            u.@int = 0;
            var half = 0.5f * z;
            u.@float = z;
            u.@int = 0x5f375a86 - (u.@int >> 1);
            u.@float *= (1.5f - half * u.@float * u.@float);
            return u.@float * z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveInlining)]
        public static int IntSqrt(this int num)
        {
            if (0 == num) return 0;
            var n = num / 2 + 1;
            var n1 = (n + num / n) / 2;
            while (n1 < n)
            {
                n = n1;
                n1 = (n + num / n) / 2;
            }

            return n;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct FloatIntUnion
        {
            [FieldOffset(0)] public float @float;

            [FieldOffset(0)] public int @int;
        }
    }
}