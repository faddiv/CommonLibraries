dotnet benchmark StringNaturalComparer.BenchmarkDotNet.dll --runtimes net472 netcoreapp2.2 --filter *.SortNumbersBenchmarks.* --artifacts ./SortNumbersBenchmarks
cd ".\SortNumbersBenchmarks\results"
"c:\Program Files\R\R-3.6.2\bin\Rscript.exe" BuildPlots.R
cd ..
cd ..