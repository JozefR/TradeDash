using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TradeDash.DTO;
using TradeDash.FrontEnd.Services;
using TradeDash.FrontEnd.ViewModels.Strategy;

namespace TradeDash.FrontEnd.Controllers
{
    public class StrategyController : Controller
    {
        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;

        public StrategyController(IApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var strategies = await _apiClient.GetStrategiesAsync();

            var strategiesVm = _mapper.Map<List<StrategyViewModel>>(strategies);
        
            return View(strategiesVm);
        }

        public IActionResult New()
        {
            var vm = new StrategyViewModel();

            return View("StrategyForm", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Save(StrategyViewModel strategy)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StrategyViewModel()
                {
                    Name = strategy.Name,
                    StrategyType = strategy.StrategyType,
                };

                return View("StrategyForm", viewModel);
            }

            var strategyDto = _mapper.Map<Strategy>(strategy);

            if (strategy.Id == 0)
                await _apiClient.PostStrategyAsync(strategyDto);
            else
                await _apiClient.PutStrategyAsync(strategyDto);
            
            return RedirectToAction("Index", "Strategy");
        }
    }
}