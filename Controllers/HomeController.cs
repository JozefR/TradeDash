using Microsoft.AspNetCore.Mvc;

namespace TradeDash.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LongTerm()
        {
            return View();
        }
    }
}
