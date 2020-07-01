using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace OrderingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            var selection = form["PaymentType"].FirstOrDefault();

            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:51373/payments"),
                Content = new StringContent(JsonConvert.SerializeObject(new { Selection = selection }), System.Text.Encoding.UTF8, "application/json")
            };

            var response = _httpClient.SendAsync(httpRequest).Result;

            if (response.IsSuccessStatusCode)
                ViewBag.Result = response.Content.ReadAsStringAsync().Result;

            return View();
        }
    }
}
