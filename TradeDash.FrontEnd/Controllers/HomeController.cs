using Microsoft.AspNetCore.Mvc;

namespace TradeDash.FrontEnd.Controllers
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

        public IActionResult ShortTerm()
        {
            return View();
        }
    }
}
