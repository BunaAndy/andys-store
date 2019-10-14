using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grocery_Store.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
    }
}
