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
using System.Net.Http.Headers;
using System.Text;

namespace Grocery_Store.Web.Controllers
{
    public class AisleController : Controller
    {
        private readonly ILogger<AisleController> _logger;

        private readonly IHttpClientFactory _clientFactory;

        public AisleController(ILogger<AisleController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = _clientFactory.CreateClient();
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
            HttpClient client = _clientFactory.CreateClient();
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

        [HttpGet]
        public IActionResult AddAisle()
        {
            var aisle = new Aisle();

            return View(aisle);
        }

        [HttpPost]
        public async Task<IActionResult> AddAisle(Aisle aisle)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var aisleJsonString = JsonConvert.SerializeObject(aisle);
            var stringContent = new StringContent(aisleJsonString, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("https://localhost:44349/aisle", stringContent);
            return View("Index");
        }

    }
}
