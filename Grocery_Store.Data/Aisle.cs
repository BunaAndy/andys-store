﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery_Store.Data
{
    public class Aisle
    {
        public int AisleId { get; set; }
        public List<Product> Products { get; } = new List<Product>();
    }
}