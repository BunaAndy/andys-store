using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Grocery_Store.Data;

namespace Grocery_Store.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]

        public Customer Post(Customer customer)
        {
            var storeContext = new StoreContext();
            var customers = storeContext.Customers;
            customers.Add(customer);
            storeContext.SaveChanges();

            return customer;
        }

        [HttpGet("/customer/{customerId}")]

        public Customer Get(int customerId)
        {
            StoreContext storeContext = new StoreContext();
            var customer = storeContext.Customers.SingleOrDefault(customers => customers.CustomerId == customerId);
            return customer;
        }

    }
}
