using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TradeDash.FrontEnd.Services;
using TradeDash.FrontEnd.ViewModels;

namespace TradeDash.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;

        public HomeController(
            IApiClient apiClient, 
            IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
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

            var strategiesVm = _mapper.Map<List<StrategyViewModel>>(strategies);
            
            return View(strategiesVm);
        }
    }
}
