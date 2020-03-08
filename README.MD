Targeting multiple framework: https://docs.microsoft.com/en-us/dotnet/standard/frameworks#how-to-specify-target-frameworks

# LeftJoin
Provides an onle line LeftJoin for Linq. This can be runned in memory and against the database also. The implementation uses the well known "linq left join trick":
```cs 
            return outer.GroupJoin(inner, outerKeySelector, innerKeySelector, (i, o) => new { i, o })
                .SelectMany(e => e.o.DefaultIfEmpty(), (t, e) => resultSelector(t.i, e));
```

# StringNaturalComparer
Provides a StringComparer in C# which can be used to sort strings in a human friendly manner. So numbers parts are treated like real numbers not character sequences. My goal is to provide the fastest and most complete implementation of this algorithm.