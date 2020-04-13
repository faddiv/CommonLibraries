Targeting multiple framework: https://docs.microsoft.com/en-us/dotnet/standard/frameworks#how-to-specify-target-frameworks

# LeftJoin
Provides an one line LeftJoin for Linq. This can be runned in memory and against the database also. The implementation uses the well known "linq left join trick":
```cs 
            return outer.GroupJoin(inner, outerKeySelector, innerKeySelector, (i, o) => new { i, o })
                .SelectMany(e => e.o.DefaultIfEmpty(), (t, e) => resultSelector(t.i, e));
```

# StringNaturalComparer
Provides a StringComparer in C# which can be used to sort strings in a human friendly manner. So numbers parts are treated like real numbers not character sequences. My goal is to provide the fastest and most complete implementation of this algorithm in the .net space.

I (also) recommend using StringNaturalComparer.Ordinal and StringNaturalComparer.OrdinalIgnoreCase since these are the fastest implementations. Also the rest uses caching that takes 128k each variant which I think is quite a lot.

I owe a thanks for the developers of StringComparer. I studied a lot that implementation and I also used the most important part from it which helped a lot.

# CollectionExtensions
This contains some commonly used method which is not in the .net.

## AddRange
Only List&lt;T&gt; contains AddRange but sometimes it is accessed only through interface. Also there is some special class that implements ICollection&lt;T&gt; but doesn't have AddRange. This method extend the ICollection&lt;T&gt; so it is everywhere usable where it is possible.

## AddElements
This is a nicce to have extension that helps add more than one element in one line. This and AddRange also chainable so in these situation where it makes sense you can use it.

## FindAndRemove
Sometimes I process element and immediatelly remove. In this cases  at the end I want to know which element wasn't processed and I want to do something with these. Most common case when I map detail DTO-s to database entities. Here is a generic example:
```cs 
   var detailEntities = orderEntity.Details.ToList();
   foreach(var dto in detailDtos) {
       var detailEntity = detailEntities.FindAndRemove(e => e.Id == dto.Id);
       if(detailEntity != null) {
           Map(dto, detailEntity);
       } else {
           CreateFromDto(dto);
       }
   }
   db.RemoveAll(detailEntities); // Rest are deleted. Remove them.
```

# Faddiv.Testing.Moq.Extensions
I love using Moq because it makes easier creating unit tests. One thing I found troublesome when I want to test if a method gets the right parameters.
Normally I make a callback and I memorize the input parameters but it is too much code, it makes the unit test messy. The Moq framework also supports get the Invocation parameters after the test call but it needs too much and ugly code to retrieve. I found a more elegant solution and I put into this library.
With this you can retrieve the parameters like this:
```cs 
    // Create mock
    var mock = new Mock<IMockedInterface>();
    // Call
    mock.Object.Function2("test", 10);
    // Retrieve the parameters.
    mock.GetLastInvocationArguments(mock.Object.Function2,
        out string actual1,
        out int actual2);
```

# Faddiv.Testing.EntityFrameworkCore
Testing code that uses EF Core can be troublesome but usually it is important since (like or not) there are some logic in the queries also. There are several aproach doing this. For me the [the SQLite approach](https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/#approach-2-sqlite) suits the best. With the sqlite in memory database it is possible to test fast and without outside dependency. Unfortunatelly when a projects get bigger and more version is added to the migration, the startup times seriously slows down. I addressed this with this package. The idea was an in memory database can restored faster than created from scratch before every testrun and this worked perfectly. You can inherit from BaseTestDatabaseFactory make it static and it creates a new instance of a fully prepared database on every CreateDbContext() call.