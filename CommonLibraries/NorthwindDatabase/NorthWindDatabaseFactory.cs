using CommonLibraries.Testing.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace NorthwindDatabase
{
    public class NorthWindDatabaseFactory : BaseTestDatabaseFactory<TestDbContext>
    {
        private readonly DatabaseScaffold _scaffold;
        public static Lazy<string> sqliteLocation = new Lazy<string>(SqliteLocation);

        public event Action Prepared;

        public NorthWindDatabaseFactory(DatabaseScaffold scaffold = null, bool snapshot = false)
            : base(
                  snapshot ? $"Data Source={sqliteLocation.Value};" : "Data Source=:memory:;"
                  )
        {
            _scaffold = scaffold ?? new DatabaseScaffold();
        }

        private static string SqliteLocation()
        {
            var directory = Environment.CurrentDirectory;
            var file = GetFile(directory);
            while (!File.Exists(file))
            {
                var parent = new DirectoryInfo(directory).Parent;
                if (parent == null)
                {
                    return GetFile(Environment.CurrentDirectory);
                }
                directory = parent.FullName;
                file = GetFile(directory);
            }
            return file;
        }

        private static string GetFile(string directory)
        {
            return Path.Combine(directory, "prototype.db");
        }
        /*
        protected override TestDbContext CreateDbContextInstance(SqliteConnection connection)
        {
            return TestDbContextProvider.CreateDbContext(connection);
        }
        */
        protected override void PrepareDbContext(TestDbContext context)
        {
            _scaffold.Run(context);
            Prepared?.Invoke();
        }
    }
}
