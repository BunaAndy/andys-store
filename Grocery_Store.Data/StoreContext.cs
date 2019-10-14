using Microsoft.EntityFrameworkCore;

namespace Grocery_Store.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Aisle> Aisles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=C:\\Users\\e92708\\source\\repos\\Grocery_Store\\Grocery_Store.Data\\store.db");
        }
    }
}
