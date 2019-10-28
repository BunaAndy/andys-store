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
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        private readonly IHttpClientFactory _clientFactory;

        public ProductController(ILogger<ProductController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            this._clientFactory = clientFactory;
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
            HttpClient client = _clientFactory.CreateClient();
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
            HttpClient client = _clientFactory.CreateClient();
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

        [HttpGet]
        public IActionResult AddProduct()
        {
            var product = new Product();

            return View(product);
        }

        [HttpPost]
        public async Task<Product> AddProduct(Product product)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var productJsonString = JsonConvert.SerializeObject(product);
            var stringContent = new StringContent(productJsonString, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("https://localhost:44349/product", stringContent);
            return product;
        }

        [HttpGet]
        public IActionResult Remove()
        {
            var product = new Product();

            return View(product);
        }

        [HttpPost]
        public Product Remove(Product product)
        {
            
        }

    }
}
