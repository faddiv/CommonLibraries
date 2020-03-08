using BenchmarkDotNet.Running;

namespace StringNaturalComparerNS
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringComparerBenchmarks>();
        }
    }
}
