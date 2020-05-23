using BenchmarkDotNet.Running;
using System.Diagnostics;
using System.IO;

namespace CommonLibraries.Testing.EntityFrameworkCore.BenchmarkDotNet
{
    public static class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
            var processStartInfo = new ProcessStartInfo(
                "c:\\Program Files\\R\\R-3.6.2\\bin\\Rscript.exe",
                "BuildPlots.R")
            {
                WorkingDirectory = Path.GetFullPath(".\\DatabaseCreationBenchmarks\\results")
            };
            var process = Process.Start(processStartInfo);
            process.WaitForExit();
        }
    }
}
