using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradeDash.FrontEnd.Services;
using TradeDash.FrontEnd.ViewModels;

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

        public async Task<IActionResult> Index()
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

        public async Task<IActionResult> Strategies()
        {
            var strategies = await _apiClient.GetStrategiesAsync();

            var strategiesVm = new List<StrategyViewModel>();
            
            foreach (var strategy in strategies)
            {
                var vm = new StrategyViewModel
                {
                    Name = strategy.Name,
                    StrategyType = Enum.GetName(strategy.StrategyType.GetType(), strategy.StrategyType)
                };
                strategiesVm.Add(vm);
            }
            
            return View(strategiesVm);
        }
    }
}
