using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Faddiv.DotNet.Linq
{
    public class TestDbContextProvider : Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<TestDbContext>
    {
        public TestDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<TestDbContext>();
            options.UseSqlite("Data Source=:memory:");
            return new TestDbContext(options.Options);
        }

        public static TestDbContext CreateDbContext(SqliteConnection connection)
        {
            var options = new DbContextOptionsBuilder<TestDbContext>();
            options.UseSqlite(connection);
            return new TestDbContext(options.Options);
        }
    }
}
