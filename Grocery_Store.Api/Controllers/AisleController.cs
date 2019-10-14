using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Grocery_Store.Data;
using System.Threading.Tasks;

namespace Grocery_Store.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AisleController : ControllerBase
    {
        private readonly ILogger<AisleController> _logger;
        public AisleController(ILogger<AisleController> logger)
        {
            _logger = logger;
        }

        [HttpPost]

        public Aisle Post(Aisle aisle)
        {

            // add to database

            using (var storeContext = new StoreContext())
            {
                var aisles = storeContext.Aisles;
                aisles.Add(aisle);
                storeContext.SaveChanges();
            }

            // end add to database

            return aisle;
        }

        [HttpGet("/aisle/{aisleId}")]
        public List<Product> Get(int aisleId)
        {
            StoreContext storeContext = new StoreContext();
            var aisle = storeContext.Products.Where(products => products.AisleId == aisleId);
            return aisle.ToList();
        }

        public List<Aisle> Get()
        {
            StoreContext storeContext = new StoreContext();
            var aisle = storeContext.Aisles;
            return aisle.ToList();
        }

    }
}
