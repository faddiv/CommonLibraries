using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Threading;

namespace CommonLibraries.Testing.EntityFrameworkCore
{
    public class BaseTestDatabaseFactory<TDbContext>
        where TDbContext : DbContext
    {
        private SqliteConnection _prototypeConnection;
        private object _syncLock = new object();
        private bool _initialized;
        private Lazy<Func<DbContextOptions, TDbContext>> _constructor;

        public BaseTestDatabaseFactory(
            string prototypeConnectionString = "Data Source=:memory:;",
            string instanceConnectionString = "Data Source=:memory:;")
        {
            PrototypeConnectionString = prototypeConnectionString;
            InstanceConnectionString = instanceConnectionString;
            _constructor = new Lazy<Func<DbContextOptions, TDbContext>>(
                CreateDbContextFactory, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public string PrototypeConnectionString { get; }
        public string InstanceConnectionString { get; }

        public TDbContext CreateDbContext()
        {
            LazyInitializer.EnsureInitialized(
                ref _prototypeConnection,
                ref _initialized,
                ref _syncLock,
                CreatePrototypeConnection);
            var instanceConnection = new SqliteConnection(InstanceConnectionString);
            instanceConnection.Open();
            _prototypeConnection.BackupDatabase(instanceConnection);
            return CreateDbContextInstance(instanceConnection);
        }
        private SqliteConnection CreatePrototypeConnection()
        {
            var prototypeConnection = new SqliteConnection(PrototypeConnectionString);
            if (ShouldRunDatabasePreparation(prototypeConnection))
            {
                prototypeConnection.Open();
                using (var dbContext = CreateDbContextInstance(prototypeConnection))
                {
                    dbContext.Database.Migrate();
                    PrepareDbContext(dbContext);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                prototypeConnection.Open();
            }
            return prototypeConnection;
        }

        private static bool ShouldRunDatabasePreparation(SqliteConnection prototypeConnection)
        {
            return string.Equals(prototypeConnection.DataSource, ":memory:", StringComparison.OrdinalIgnoreCase)
                || !File.Exists(prototypeConnection.DataSource);
        }

        private static Func<DbContextOptions, TDbContext> CreateDbContextFactory()
        {
            var constructor = typeof(TDbContext).GetConstructor(new[] { typeof(DbContextOptions) });
            if (constructor == null)
                throw new Exception($"Either CreateDbContextInstance must be overidden or {typeof(DbContextOptions).Name} needs a constructor with DbContextOptions parameter.");
            var parameter = Expression.Parameter(typeof(DbContextOptions), "options");
            var ctor = Expression.New(constructor, parameter);
            var lambda = Expression.Lambda<Func<DbContextOptions, TDbContext>>(ctor, parameter);
            return lambda.Compile();
        }

        protected virtual TDbContext CreateDbContextInstance(SqliteConnection connection)
        {
            var options = new DbContextOptionsBuilder<TDbContext>();
            options.UseSqlite(connection);
            
            return _constructor.Value(options.Options);
        }
        protected virtual void PrepareDbContext(TDbContext context)
        {
            throw new NotImplementedException("PrepareDbContext must be implemented.");
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _prototypeConnection?.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
