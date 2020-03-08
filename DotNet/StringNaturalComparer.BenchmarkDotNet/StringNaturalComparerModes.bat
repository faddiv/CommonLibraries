dotnet benchmark StringNaturalComparer.BenchmarkDotNet.dll --runtimes net472 netcoreapp2.2 --filter *.StringNaturalComparerModes.* --artifacts ./StringNaturalComparerModes
cd ".\StringNaturalComparerModes\results"
"c:\Program Files\R\R-3.6.2\bin\Rscript.exe" BuildPlots.R
cd ..
cd ..