using Microsoft.AspNetCore.Mvc;

namespace TradeDash.FrontEnd.Controllers
{
    public class StockController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}