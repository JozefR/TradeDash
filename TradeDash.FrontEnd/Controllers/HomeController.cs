using Microsoft.AspNetCore.Mvc;
using TradeDash.FrontEnd.Services;

namespace TradeDash.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiClient _apiClient;

        public HomeController(
            IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IActionResult Index()
        {
            var test = _apiClient.GetStrategiesAsync();

            return Ok();
        }

        public IActionResult LongTerm()
        {
            return View();
        }

        public IActionResult ShortTerm()
        {
            return View();
        }
    }
}
