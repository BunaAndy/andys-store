using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Grocery_Store
{
    public class StoreContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Aisles> Aisles { get; set; }
    }
    public class Inventory
    {
        public int ProductID { get; set; }
        public string Product { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int AisleNum { get; set; }
    }

    public class Customers
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
    }

    public class Employees
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
    }

    public class Aisles
    {
        public int AisleNum { get; set; }
        public List<Inventory> Products { get; } = new List<Inventory>();
    }
}
