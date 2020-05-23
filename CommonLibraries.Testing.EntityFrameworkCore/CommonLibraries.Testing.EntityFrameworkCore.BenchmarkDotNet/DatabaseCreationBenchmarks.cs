using BenchmarkDotNet.Attributes;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NorthwindDatabase;
using System;
using System.IO;

namespace CommonLibraries.Testing.EntityFrameworkCore.BenchmarkDotNet
{
    [ArtifactsPath(".\\DatabaseCreationBenchmarks")]
    public class DatabaseCreationBenchmarks : BenchmarksBase
    {
        private DatabaseScaffold scaffold;
        private NorthWindDatabaseFactory factory;
        [GlobalSetup]
        public void Setup()
        {
            scaffold = new DatabaseScaffold();
            factory = new NorthWindDatabaseFactory(scaffold);
            factory.CreateDbContext();
            // Pre-Create snapshot db.
            var snapshot = new NorthWindDatabaseFactory(scaffold, snapshot: true);
            snapshot.CreateDbContext().Dispose();
        }

        [Benchmark]
        public DbContext ClassicCreation()
        {
            using var connection = new SqliteConnection("Data Source=:memory:;");
            connection.Open();
            using var context = TestDbContextProvider.CreateDbContext(connection);
            context.Database.Migrate();
            scaffold.Run(context);
            return context;
        }

        [Benchmark]
        public DbContext FastCreation()
        {
            return factory.CreateDbContext();
        }

        [Benchmark]
        public DbContext SnapshotCreation()
        {
            var snapshot = new NorthWindDatabaseFactory(scaffold, snapshot: true);
            snapshot.CreateDbContext();
            return snapshot.CreateDbContext();
        }
    }
}
