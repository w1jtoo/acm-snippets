using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Snippets.Math
{
    public static class Factorization
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Gcd(long a, long b)
        {
            while (a != 0 && b != 0)
                if (a > b)
                    a %= b;
                else
                    b %= a;

            return a | b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long Rho(long n)
        {
            if (n == 1 || n == 2 || n == 3 || n == 5 || n == 7)
                return n;
            if (n % 2 == 0)
                return 2;

            long xFixed = 2, x = 2, size = 2, loop = 1, factor, count;

            do
            {
                count = size;

                do
                {
                    x = FGenerator(n, x); // == x * x * x + 1 (mod n)
                    factor = Gcd(Abs(x, xFixed), n);
                } while (--count > 0 && factor == 1);

                size <<= 1;
                xFixed = x;
                loop++;
            } while (factor == 1);

            return factor;
        }

        public static IEnumerable<long> GetPrimeFactors(this long number)
        {
            var d = number;

            do
            {
                var dd = Rho(d);

                var firstDiv = dd.GetFirstDenominator();
                if (firstDiv != null)
                {
                    while (d % firstDiv.Value == 0)
                    {
                        d /= firstDiv.Value;
                        yield return firstDiv.Value;
                    }
                }
                else
                {
                    d /= dd;
                    yield return dd;
                }
            } while (d.GetFirstDenominator().HasValue);

            if (d != 1)
                yield return d;
        }


        /// <summary>
        ///     using Sieve of Eratosthenes O(n log n)
        /// </summary>
        public static IEnumerable<int> GetPrimeNumbers(int count)
        {
            var isPrime = new bool[count];

            for (var i = 0; i < count; i++) isPrime[i] = true;

            for (var i = 2; i < count; i++)
                if (isPrime[i])
                    for (var j = 2 * i; j < count; j += i)
                        isPrime[j] = false;

            for (var i = 0; i < isPrime.Length; i++)
                if (isPrime[i])
                    yield return i;
        }

        private static long Abs(long a, long b)
        {
            return a > b ? a - b : b - a;
        }

        private static long FGenerator(long n, long prev)
        {
            return (prev * prev * prev + 1) % n;
        }
    }
}