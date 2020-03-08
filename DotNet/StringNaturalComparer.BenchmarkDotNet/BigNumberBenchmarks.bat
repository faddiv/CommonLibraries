dotnet benchmark StringNaturalComparer.BenchmarkDotNet.dll --runtimes net472 netcoreapp2.2 --filter *.BigNumberBenchmarks.* --artifacts ./BigNumberBenchmarks
cd ".\BigNumberBenchmarks\results"
"c:\Program Files\R\R-3.6.2\bin\Rscript.exe" BuildPlots.R
cd ..
cd ..