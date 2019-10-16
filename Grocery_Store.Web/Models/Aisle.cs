using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery_Store.Web.Models
{
    public class Aisle
    {
        public int AisleId { get; set; }
        public List<Product> Products { get; } = new List<Product>();
    }
}
