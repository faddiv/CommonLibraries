using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace Faddiv.DotNet.Linq
{
    public class LeftJoinTests
    {
        [Fact]
        public void LeftJoin_works_on_Enumerable_as_left_join()
        {
            var list1 = GetList(3, 1, "l1");
            var list2 = GetList(2, 1, "l2");

            var result = list1
                .LeftJoin(list2, l => l.Id, l => l.Id, (o, i) => new { o, i })
                .ToList();

            result.Should().HaveCount(3);
            result.Should().Contain(e => e.o != null && e.i == null);
        }

        [Fact]
        public void LeftJoin_requires_all_arguments()
        {
            var list1 = GetList(2, 1, "l1");
            var list2 = GetList(2, 1, "l2");

            Assert.Throws<ArgumentNullException>("outer", () =>
            {
                Data[] outer = null;
                return outer
                    .LeftJoin(list2, l => l.Id, l => l.Id, (o, i) => new { o, i })
                    .ToList();
            });

            Assert.Throws<ArgumentNullException>("inner", () =>
            {
                return list1
                    .LeftJoin((Data[])null, l => l.Id, l => l.Id, (o, i) => new { o, i })
                    .ToList();
            });

            Assert.Throws<ArgumentNullException>("outerKeySelector", () =>
            {
                return list1
                    .LeftJoin(list2, null, l => l.Id, (o, i) => new { o, i })
                    .ToList();
            });

            Assert.Throws<ArgumentNullException>("innerKeySelector", () =>
            {
                return list1
                    .LeftJoin(list2, l => l.Id, null, (o, i) => new { o, i })
                    .ToList();
            });
            Assert.Throws<ArgumentNullException>("resultSelector", () =>
            {
                Func<Data, Data, object> resultSelector = null;
                return list1
                    .LeftJoin(list2, l => l.Id, l => l.Id, resultSelector)
                    .ToList();
            });
        }

        [Fact]
        public void LeftJoin_works_on_db_as_left_join()
        {
            using var db = CreateDb();
            var list1 = GetList(3, 1, "l1");
            db.AddRange(list1);
            db.AddRange(GetList2(2, 1, "l2", list1));
            db.SaveChanges();

            var result = db.Datas
                .LeftJoin(db.Data2s, l => l.Id, l => l.DataId, (o, i) => new { o, i })
                .ToList();

            result.Should().HaveCount(3);
            result.Should().Contain(e => e.o != null && e.i == null);
        }

        [Fact]
        public void Queriable_LeftJoin_requires_all_arguments()
        {
            using var db = CreateDb();
            var list1 = db.Datas;
            var list2 = db.Data2s;
            Assert.Throws<ArgumentNullException>("outer", () =>
            {
                DbSet<Data> outer = null;
                return outer
                    .LeftJoin(list2, l => l.Id, l => l.Id, (o, i) => new { o, i })
                    .ToList();
            });

            Assert.Throws<ArgumentNullException>("inner", () =>
            {
                return list1
                    .LeftJoin((Data[])null, l => l.Id, l => l.Id, (o, i) => new { o, i })
                    .ToList();
            });

            Assert.Throws<ArgumentNullException>("outerKeySelector", () =>
            {
                return list1
                    .LeftJoin(list2, null, l => l.Id, (o, i) => new { o, i })
                    .ToList();
            });

            Assert.Throws<ArgumentNullException>("innerKeySelector", () =>
            {
                return list1
                    .LeftJoin(list2, l => l.Id, null, (o, i) => new { o, i })
                    .ToList();
            });
            Assert.Throws<ArgumentNullException>("resultSelector", () =>
            {
                Expression<Func<Data, Data2, object>> resultSelector = null;
                return list1
                    .LeftJoin(list2, l => l.Id, l => l.Id, resultSelector)
                    .ToList();
            });
        }


        private TestDbContext CreateDb()
        {
            var sql = new SqliteConnection("Data Source=:memory:");
            sql.Open();
            var db = TestDbContextProvider.CreateDbContext(sql);
            db.Database.Migrate();
            return db;
        }

        private static Data[] GetList(int size, int seed, string name)
        {
            return Enumerable.Range(seed, size)
                .Select(i => new Data(i,
                    $"{name} element{i}"))
                .ToArray();
        }

        private static Data2[] GetList2(int size, int seed, string name, Data[] joined)
        {
            return Enumerable.Range(seed, size)
                .Select(i => new Data2(i,
                    $"{name} element{i}")
                {
                    Data = joined[i - seed]
                })
                .ToArray();
        }
    }
}