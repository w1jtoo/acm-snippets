using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace InlineMethods
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.Mono)]
    public class Inlining
    {
        [Benchmark]
        public long Default()
        {
            return A.Default.Method();
        }

        [Benchmark]
        public long Inlined()
        {
            return A.Inlined.Method();
        }

        [Benchmark]
        public long Optimized()
        {
            return A.Optimized.Method();
        }
    }

    internal static class A
    {
        internal static class Default
        {
            private static long snail;

            public static long Method()
            {
                var i = 0;
                while (i < Domain.Count)
                {
                    Domain.DefaultMethod(ref snail);
                    Domain.DefaultMethod(ref snail);
                    Domain.DefaultMethod(ref snail);
                    Domain.DefaultMethod(ref snail);
                    Domain.DefaultMethod(ref snail);
                    Domain.DefaultMethod(ref snail);
                    i++;
                }

                return snail;
            }
        }

        internal static class Inlined
        {
            private static long snail;

            public static long Method()
            {
                var i = 0;
                while (i < Domain.Count)
                {
                    Domain.InlinedMethod(ref snail);
                    Domain.InlinedMethod(ref snail);
                    Domain.InlinedMethod(ref snail);
                    Domain.InlinedMethod(ref snail);
                    Domain.InlinedMethod(ref snail);
                    Domain.InlinedMethod(ref snail);
                    i++;
                }

                return snail;
            }
        }
        internal static class Optimized
        {
            private static long snail;

            public static long Method()
            {
                var i = 0;
                while (i < Domain.Count)
                {
                    Domain.OptimizedMethod(ref snail);
                    Domain.OptimizedMethod(ref snail);
                    Domain.OptimizedMethod(ref snail);
                    Domain.OptimizedMethod(ref snail);
                    Domain.OptimizedMethod(ref snail);
                    Domain.OptimizedMethod(ref snail);
                    i++;
                }

                return snail;
            }
        }

        private static class Domain
        {
            public const int Count = 1_000_000 * 10;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void InlinedMethod(ref long snail)
            {
                var i = 0;
                while (i < 5)
                {
                    snail += i;
                    i++;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public static void OptimizedMethod(ref long snail)
            {
                var i = 0;
                while (i < 5)
                {
                    snail += i;
                    i++;
                }
            }

            public static void DefaultMethod(ref long snail)
            {
                var i = 0;
                while (i < 5)
                {
                    snail += i;
                    i++;
                }
            }
        }
    }
}