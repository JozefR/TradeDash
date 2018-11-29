using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TradeDash.FrontEnd.Services;
using TradeDash.FrontEnd.ViewModels;
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
    }
}