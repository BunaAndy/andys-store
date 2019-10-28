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

        public Aisle AddAisle(Aisle aisle)
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
        public Aisle Get(int aisleId)
        {
            StoreContext storeContext = new StoreContext();
            var aisles = storeContext.Aisles.Where(aisles => aisles.AisleId == aisleId);
            var products = storeContext.Products.Where(product => product.AisleId == aisleId);
            var aislesList = aisles.ToList();

            var aisle = aislesList[0];
            aisle.Products = products.ToList();
            aisle.Tag = aislesList[0].Tag;

            return aisle;
        }

        [HttpGet("/aisle")]
        public List<Aisle> Get()
        {
            StoreContext storeContext = new StoreContext();
            var aisle = storeContext.Aisles;
            return aisle.ToList();
        }

        //[HttpPost("/aisle/{aisleId}/changeTag/{description}")]
        //public string Buy(int aisleId, string description)
        //{
        //    StoreContext storeContext = new StoreContext();
        //    var aisle = storeContext.Aisles.SingleOrDefault(aisles => aisles.AisleId == aisleId);
        //    aisle.Tag = description;
        //    storeContext.SaveChanges();
        //    return aisle.Tag;
        //}

    }
}
