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
        
        public async Task<IActionResult> Edit(int id)
        {
            var strategy = await _apiClient.GetStrategyAsync(id);

            var strategyVm = _mapper.Map<StrategyViewModel>(strategy);
            
            return View("StrategyForm", strategyVm);
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

            var strategyDto = _mapper.Map<StrategyResponse>(strategy);

            if (strategy.Id == 0)
                await _apiClient.PostStrategyAsync(strategyDto);
            else
                await _apiClient.PutStrategyAsync(strategyDto);
            
            return RedirectToAction("Index", "Strategy");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _apiClient.DeleteStrategyAsync(id);

            return Ok();
        }
    }
}