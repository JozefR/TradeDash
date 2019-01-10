using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TradeDash.BackEnd.Infrastructure;
using TradeDash.BackEnd.Services;
using TradeDash.DTO;
using TradeDash.Strategies;

namespace TradeDash.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : Controller
    {
        private readonly IApiClient _apiClient;
        private readonly ISpecificStrategy _strategy;

        public StocksController(IApiClient apiClient, ISpecificStrategy strategy)
        {
            _apiClient = apiClient;
            _strategy = strategy;
        }

        [HttpGet("{ticker}/{history}/{strategyType}")]
        public async Task<IActionResult> Get([FromRoute] string ticker, string history, StrategyType strategyType)
        {
            var stocks = await _apiClient.GetStocksAsync(ticker, history);

            if (stocks == null)
            {
                return null;
            }

            var results = MapDataResponse(stocks, ticker);

            IStrategy strategy = _strategy.GetStrategyType(StrategyType.ConnorRsi);

            if (strategy != null)
            {
                results = strategy.Execute(results.ToList());
            }
            
            return Ok(results);
        }

        private static IEnumerable<StockResponse> MapDataResponse(IEnumerable<JObject> stocks, string ticker)
        {
            int number = 0;
            
            var response = stocks.Select(x => x.MapDataResponse(ticker, ++number));
            
            return response;
        }
    }
}