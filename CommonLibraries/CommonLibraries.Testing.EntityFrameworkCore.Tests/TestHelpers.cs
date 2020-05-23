using FluentAssertions;
using NorthwindDatabase;

namespace CommonLibraries.Testing.EntityFrameworkCore
{
    public class TestHelpers
    {
        public static void ShouldBePrepared(TestDbContext context)
        {
            context.Categories.Should().NotBeEmpty();
            context.Customers.Should().NotBeEmpty();
            context.Employees.Should().NotBeEmpty();
            context.EmployeeTerritories.Should().NotBeEmpty();
            context.OrderDetails.Should().NotBeEmpty();
            context.Orders.Should().NotBeEmpty();
            context.Products.Should().NotBeEmpty();
            context.Region.Should().NotBeEmpty();
            context.Shippers.Should().NotBeEmpty();
            context.Suppliers.Should().NotBeEmpty();
            context.Territories.Should().NotBeEmpty();
        }
    }
}
