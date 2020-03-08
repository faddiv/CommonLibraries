using Microsoft.EntityFrameworkCore;

namespace Faddiv.DotNet.Linq
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Data> Datas => Set<Data>();

        public DbSet<Data2> Data2s => Set<Data2>();

    }
}
