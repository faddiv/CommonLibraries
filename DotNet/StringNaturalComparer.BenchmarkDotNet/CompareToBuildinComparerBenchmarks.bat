dotnet benchmark StringNaturalComparer.BenchmarkDotNet.dll --runtimes net472 netcoreapp2.2 --filter *.CompareToBuildinComparerBenchmarks.* --artifacts ./CompareToBuildinComparerBenchmarks
cd ".\CompareToBuildinComparerBenchmarks\results"
"c:\Program Files\R\R-3.6.2\bin\Rscript.exe" BuildPlots.R
move "*-barplot.png" "../"
move "*.html" "../"
del "*.*"
cd ..
rmdir "results"
cd ..