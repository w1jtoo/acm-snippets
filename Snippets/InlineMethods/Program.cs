using BenchmarkDotNet.Running;

namespace InlineMethods
{
    public static class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<Inlining>();
        }
    }
}