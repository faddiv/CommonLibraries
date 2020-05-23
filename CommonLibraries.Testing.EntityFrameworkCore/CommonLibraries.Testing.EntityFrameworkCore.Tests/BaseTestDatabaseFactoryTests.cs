using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NorthwindDatabase;
using System.Data;
using Xunit;

namespace CommonLibraries.Testing.EntityFrameworkCore
{
    public class BaseTestDatabaseFactoryTests
    {
        [Fact]
        public void Constructor_uses_default_parameters()
        {
            // Arrange
            // Act
            var instance = new NorthWindDatabaseFactory();

            // Assert
            instance.PrototypeConnectionString.Should().Be("Data Source=:memory:;");
            instance.InstanceConnectionString.Should().Be("Data Source=:memory:;");
        }

        [Fact]
        public void CreateDbContext_creates_an_instance()
        {
            // Arrange
            var instance = new NorthWindDatabaseFactory();

            // Act
            var dbContext = instance.CreateDbContext();

            // Assert
            dbContext.Should().NotBeNull();
        }

        [Fact]
        public void CreateDbContext_opens_the_database()
        {
            // Arrange
            var instance = new NorthWindDatabaseFactory();

            // Act
            var dbContext = instance.CreateDbContext();

            // Assert
            var connection = dbContext.Database.GetDbConnection();
            connection.State.Should().Be(ConnectionState.Open);
        }

        [Fact]
        public void CreateDbContext_prepares_the_db_context()
        {
            // Arrange
            var instance = new NorthWindDatabaseFactory();

            // Act
            var dbContext = instance.CreateDbContext();

            // Assert
            dbContext.Should().NotBeNull();
            TestHelpers.ShouldBePrepared(dbContext);
        }

        [Fact]
        public void CreateDbContext_calls_prepare_only_once()
        {
            // Arrange
            var count = 0;
            var instance = new NorthWindDatabaseFactory();
            instance.Prepared += () => count++;

            // Act
            instance.CreateDbContext();
            var dbContext = instance.CreateDbContext();

            // Assert
            count.Should().Be(1);
            TestHelpers.ShouldBePrepared(dbContext);
        }

        [Fact]
        public void Constructor_can_work_snapshot_mode()
        {
            // Arrange
            var count = 0;
            var instance = new NorthWindDatabaseFactory(snapshot: true);
            instance.Prepared += () => count++;

            // Act
            instance.CreateDbContext();
            var dbContext = instance.CreateDbContext();

            // Assert
            count.Should().Be(0);
            TestHelpers.ShouldBePrepared(dbContext);
        }

    }
}
