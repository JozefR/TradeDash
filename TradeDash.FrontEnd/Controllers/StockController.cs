using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TradeDash.FrontEnd.Services;
using TradeDash.FrontEnd.ViewModels.Stock;

namespace TradeDash.FrontEnd.Controllers
{
    public class StockController : Controller
    {
        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;

        public StockController(IApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var stocks = await _apiClient.GetStocksAsync();

            var stocksVm = _mapper.Map<List<StockViewModel>>(stocks);

            return View(stocksVm);
        }
    }
}