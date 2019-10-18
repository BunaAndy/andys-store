using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Newtonsoft.Json;
using Grocery_Store.Web.Models;

namespace Grocery_Store.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        private readonly IHttpClientFactory clientFactory;

        public ProductController(ILogger<ProductController> logger, IHttpClientFactory _clientFactory)
        {
            _logger = logger;
            clientFactory = _clientFactory;
        }

        //[Route("/product")]
        //public async Task<string> Index()
        //{
        //    HttpClient client = new HttpClient();
        //    string resp = "";
        //    HttpResponseMessage response = await client.GetAsync("https://localhost:44349/product");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        resp = await response.Content.ReadAsStringAsync();
        //    }



        //    return resp;
        //}

        public async Task<IActionResult> Index()
        {
            HttpClient client = clientFactory.CreateClient();
            string resp = "";
            List<Product> products;
            HttpResponseMessage response = await client.GetAsync("https://localhost:44349/product");
            if (response.IsSuccessStatusCode)
            {
                resp = await response.Content.ReadAsStringAsync();
            }

            products = JsonConvert.DeserializeObject<List<Product>>(resp);

            var productViewModel = new ProductViewModel
            {
                Products = products
            };
            return View(productViewModel);
        }

        [Route("/product/{productId}")]
        public async Task<IActionResult> Product(string productId)
        {
            HttpClient client = clientFactory.CreateClient();
            string resp = "";
            Product product;
            HttpResponseMessage response = await client.GetAsync("https://localhost:44349/product/" + productId);
            if (response.IsSuccessStatusCode)
            {
                resp = await response.Content.ReadAsStringAsync();
            }

            product = JsonConvert.DeserializeObject<Product>(resp);

            return View(product);
        }

    }
}
