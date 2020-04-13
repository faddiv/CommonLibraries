using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;

namespace Faddiv.Testing.EntityFrameworkCore.BenchmarkDotNet
{
    [HtmlExporter, RPlotExporter]
    [Orderer(SummaryOrderPolicy.Default)]
    [RankColumn(NumeralSystem.Arabic)]
    [Outliers(OutlierMode.RemoveAll)]
    public class BenchmarksBase
    {
    }
}
