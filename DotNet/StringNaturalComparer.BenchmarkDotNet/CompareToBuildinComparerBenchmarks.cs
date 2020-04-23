using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace StringNaturalComparerNS
{
    [ArtifactsPath(".\\CompareToBuildinComparerBenchmarks")]
    public class CompareToBuildinComparerBenchmarks : BenchmarksBase
    {
        private readonly IComparer<string> stringNaturalComparerOrdinal = 
            Faddiv.DotNet.Text.StringNaturalComparer.Ordinal;
        private readonly IComparer<string> stringComparer = 
            System.StringComparer.Ordinal;

        private readonly IComparer<string> stringNaturalComparerOrdinalIgnoreCase =
            Faddiv.DotNet.Text.StringNaturalComparer.OrdinalIgnoreCase;
        private readonly IComparer<string> stringComparerOrdinalIgnoreCase =
            System.StringComparer.OrdinalIgnoreCase;

        private readonly IComparer<string> stringNaturalComparerInvariant =
            Faddiv.DotNet.Text.StringNaturalComparer.InvariantCulture;
        private readonly IComparer<string> stringComparerInvariant =
            System.StringComparer.InvariantCulture;

        private readonly IComparer<string> stringNaturalComparerInvariantIgnoreCase =
            Faddiv.DotNet.Text.StringNaturalComparer.InvariantCultureIgnoreCase;
        private readonly IComparer<string> stringComparerInvariantIgnoreCase =
            System.StringComparer.InvariantCultureIgnoreCase;

        private readonly string[][] dataSets = new[] {
            new[] {
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit.a",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit.b"
            } ,new[] {
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit.a",
            new string("Lorem ipsum dolor sit amet, consectetur adipiscing elit.a".ToCharArray())
            }
        };
        private string left;
        private string right;

        public enum Examples
        {
            LongTextNumberNE,
            LongTextNumberEQ
        }

        [Params(Examples.LongTextNumberNE, Examples.LongTextNumberEQ)]
        public Examples Pairs;

        [GlobalSetup]
        public void Setup()
        {
            left = dataSets[(int)Pairs][0];
            right = dataSets[(int)Pairs][1];
        }

        [Benchmark]
        public int NaturalOrdinal()
        {
            return stringNaturalComparerOrdinal.Compare(left, right);
        }

        [Benchmark]
        public int BasicOrdinal()
        {
            return stringComparer.Compare(left, right);
        }

        [Benchmark]
        public int NaturalOrdinalIgnoreCase()
        {
            return stringNaturalComparerOrdinalIgnoreCase.Compare(left, right);
        }

        [Benchmark]
        public int BasicOrdinalIgnoreCase()
        {
            return stringComparerOrdinalIgnoreCase.Compare(left, right);
        }

        [Benchmark]
        public int NaturalInvariant()
        {
            return stringNaturalComparerInvariant.Compare(left, right);
        }

        [Benchmark]
        public int BasicInvariant()
        {
            return stringComparerInvariant.Compare(left, right);
        }

        [Benchmark]
        public int NaturalInvariantIgnoreCase()
        {
            return stringNaturalComparerInvariantIgnoreCase.Compare(left, right);
        }

        [Benchmark]
        public int BasicInvariantIgnoreCase()
        {
            return stringComparerInvariantIgnoreCase.Compare(left, right);
        }
    }
}
