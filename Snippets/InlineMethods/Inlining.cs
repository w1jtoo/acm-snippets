using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Tests.Experiments
{

    [SimpleJob(RuntimeMoniker.Mono)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    public class Inlining
    {
        [Benchmark]
        public long Default() => A.Default.Method();
        
        [Benchmark]
        public long Inlined() => A.Inlined.Method();

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