using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Grocery_Store.Data;
using Microsoft.EntityFrameworkCore;

namespace Grocery_Store.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{

        //}

        [HttpPost]

        public Product AddProduct(Product product)
        {

            // add to database

            using (var storeContext = new StoreContext())
            {
                var products = storeContext.Products;
                products.Add(product);
                storeContext.SaveChanges();
            }

            // end add to database

            return product;


        }

        [HttpGet("/product")]
        public List<Product> Get()
        {
            StoreContext storeContext = new StoreContext();
            var product = storeContext.Products;
            return product.ToList();
        }

        [HttpGet("/product/{productId}")]
        public Product Get(int productId)
        {
            StoreContext storeContext = new StoreContext();
            var product = storeContext.Products.SingleOrDefault(products => products.ProductID == productId);
            return product;
        }

        [HttpPost]
        public int Buy(int productId, int amount)
        {
            StoreContext storeContext = new StoreContext();
            var product = storeContext.Products.SingleOrDefault(products => products.ProductID == productId);
            product.Amount -= amount;
            storeContext.SaveChanges();
            return product.Amount;
        }

        [HttpPost]
        public Product Remove(Product product)
        {
            StoreContext storeContext = new StoreContext();
            var productRemove = storeContext.Products.SingleOrDefault(products => products.ProductID == product.ProductID);
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Product> test = storeContext.Products.Remove(product);
            storeContext.SaveChanges();
            return product;
        }

    }

}
