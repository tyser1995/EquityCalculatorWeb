using EquityCalculatorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EquityCalculatorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Calculate([FromBody] EquityCalculation reservation)
        {
            string apiUrl = "http://localhost:22712/Equity/calculate";

            var httpClient = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var resultReservation = JsonConvert.DeserializeObject<EquityCalculation>(jsonResponse);

                return PartialView("_Result", resultReservation);
            }
            else
            {
                return StatusCode((int)response.StatusCode, $"Error: {response.ReasonPhrase}");
            }
        }
    }
}
