using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
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

        public async Task<IActionResult> Index()
        {
            var stocks = await _apiClient.GetStocksAsync("Aapl", "1y");

            var stocksVm = _mapper.Map<List<StockViewModel>>(stocks);

            return View(stocksVm);
        }       
        
        public async Task<IActionResult> Find(string ticker, string history)
        {
            var stocks = await _apiClient.GetStocksAsync(ticker, history);

            var stocksVm = _mapper.Map<List<StockViewModel>>(stocks);

            return View("Index", stocksVm);
        }
    }
}