using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Grocery_Store.Web;
using Newtonsoft.Json;
using Grocery_Store.Web.Models;

namespace Grocery_Store.Web.Controllers
{
    public class AisleController : Controller
    {
        private readonly ILogger<AisleController> _logger;

        public AisleController(ILogger<AisleController> logger)
        {
            _logger = logger;
        }

        static AisleController()
        {

        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            string resp = "";
            List<Aisle> aisles;
            HttpResponseMessage response = await client.GetAsync("https://localhost:44349/aisle");
            if (response.IsSuccessStatusCode)
            {
                resp = await response.Content.ReadAsStringAsync();
            }

            aisles = JsonConvert.DeserializeObject<List<Aisle>>(resp);

            var aisleViewModel = new AislesViewModel
            {
                Aisles = aisles
            };
            return View(aisleViewModel);
        }

        [Route("/aisle/{aisleId}")]
        public async Task<IActionResult> Aisle(int aisleId)
        {
            HttpClient client = new HttpClient();
            string resp = "";
            HttpResponseMessage response = await client.GetAsync("https://localhost:44349/aisle/" + aisleId);
            if (response.IsSuccessStatusCode)
            {
                resp = await response.Content.ReadAsStringAsync();
            }

            var aisle = JsonConvert.DeserializeObject<Aisle>(resp);


            var aisleViewModel = new AisleViewModel
            {
                Aisle = aisle
            };

            return View(aisleViewModel);
        }


    }
}
