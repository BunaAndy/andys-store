using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery_Store.Data
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int AisleId { get; set; }
    }
}
