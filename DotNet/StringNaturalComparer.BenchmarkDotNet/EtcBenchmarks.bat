dotnet benchmark StringNaturalComparer.BenchmarkDotNet.dll --runtimes net472 netcoreapp2.2 --filter *.EtcBenchmarks.* --artifacts ./EtcBenchmarks
cd ".\EtcBenchmarks\results"
"c:\Program Files\R\R-3.6.2\bin\Rscript.exe" BuildPlots.R
cd ..
cd ..