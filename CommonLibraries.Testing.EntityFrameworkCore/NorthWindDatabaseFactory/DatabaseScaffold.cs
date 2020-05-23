using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using NorthWindDatabase.Properties;
using System.Globalization;
using System.IO;

namespace NorthwindDatabase
{
    public class DatabaseScaffold
    {
        public DatabaseScaffold()
        {
        }

        public void Run(TestDbContext context)
        {
            LoadTable(context.Categories);
            LoadTable(context.Customers);
            LoadTable(context.Employees);
            LoadTable(context.EmployeeTerritories);
            LoadTable(context.OrderDetails);
            LoadTable(context.Orders);
            LoadTable(context.Products);
            LoadTable(context.Region);
            LoadTable(context.Shippers);
            LoadTable(context.Suppliers);
            LoadTable(context.Territories);
            context.SaveChanges();
        }

        private void LoadTable<TEntity>(DbSet<TEntity> table)
             where TEntity : class
        {
            var name = typeof(TEntity).Name;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
                HasHeaderRecord = true,
                Delimiter = "\t",
                Escape = '\\',
            };
            var map = config.AutoMap(typeof(TEntity));
            map.ReferenceMaps.Clear();
            foreach (var item in map.MemberMaps)
            {
                item.TypeConverterOption.NullValues("", "NULL");
            }

            using var reader = new StringReader(Resources.ResourceManager.GetString(name));
            using var csv = new CsvReader(reader, config);
            foreach (var item in csv.GetRecords<TEntity>())
            {
                table.Add(item);
            }
        }
    }
}
