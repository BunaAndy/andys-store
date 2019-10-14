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
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public Employee Post(Employee employee)
        {
            var storeContext = new StoreContext();
            var employees = storeContext.Employees;
            employees.Add(employee);
            storeContext.SaveChanges();

            return employee;
        }

        [HttpGet("/employee/{employeeId}")]

        public Employee Get(int employeeId)
        {
            StoreContext storeContext = new StoreContext();
            var employee = storeContext.Employees.SingleOrDefault(employees => employees.EmployeeID == employeeId);
            return employee;
        }
    }
}
