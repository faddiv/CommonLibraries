using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading;

namespace PocketTools.Testing.EntityFrameworkCore
{
    public class BaseTestDatabaseFactory
    {
        private SqliteConnection _prototypeConnection;
        private object _syncLock = new object();
        private bool _initialized;

        public BaseTestDatabaseFactory(
            string prototypeConnectionString = "Data Source=:memory:;",
            string instanceConnectionString = "Data Source=:memory:;")
        {
            PrototypeConnectionString = prototypeConnectionString;
            InstanceConnectionString = instanceConnectionString;
        }

        public string PrototypeConnectionString { get; }
        public string InstanceConnectionString { get; }

        public DbContext CreateDbContext()
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

        protected virtual DbContext CreateDbContextInstance(SqliteConnection connection)
        {
            throw new NotImplementedException("CreateDbContextInstance must be implemented.");
        }
        protected virtual void PrepareDbContext(DbContext context)
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
