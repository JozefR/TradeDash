using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TradeDash.BackEnd.Data;
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
        private readonly ApplicationDbContext _db;

        public StocksController(
            IApiClient apiClient,
            ISpecificStrategy strategy,
            ApplicationDbContext db)
        {
            _apiClient = apiClient;
            _strategy = strategy;
            _db = db;
        }

        [HttpGet("{ticker}/{history}")]
        public async Task<IActionResult> Get([FromRoute] string ticker, string history)
        {
            var stocks = await _apiClient.GetStocksAsync(ticker, history);

            if (stocks == null)
            {
                return null;
            }

            var results = MapDataResponse(stocks, ticker, history);
         
            return Ok(results);
        }

        [HttpGet("Calculate/{ticker}/{history}/{strategyType}")]
        public async Task<IActionResult> Calculate([FromRoute] string ticker, string history, StrategyType strategyType)
        {
            var stocks = await _apiClient.GetStocksAsync(ticker, history);

            if (stocks == null)
            {
                return null;

            }
            var results = MapDataResponse(stocks, ticker, history);
            
            IStrategy strategy = _strategy.GetStrategyType(strategyType);

            if (strategy != null)
            {
                results = strategy.Execute(results.ToList());
            }
         
            return Ok(results);
        }

        [HttpPost("Save/{ticker}/{history}/{strategyId}")]
        public async Task<IActionResult> CalculatePost([FromRoute]string ticker, string history, int strategyId)
        {
            var strategy = await _db.Strategies.FindAsync(strategyId);

            if (strategy == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stocks = await _apiClient.GetStocksAsync(ticker, history);

            if (stocks == null)
            {
                return null;
            }

            var results = MapDataResponse(stocks, ticker, history);
            var strategyDto = strategy.MapStrategyToDTO();

            IStrategy specificStrategy = _strategy.GetStrategyType(strategy.StrategyType);

            if (specificStrategy != null)
            {
                results = specificStrategy.Execute(results.ToList(), strategyDto);
            }

            return Ok();
        }
        
        #region Private helpers

        private static IEnumerable<StockResponse> MapDataResponse(IEnumerable<JObject> stocks, string ticker,string history)
        {
            int number = 0;
            
            var response = stocks.Select(x => x.MapDataResponse(ticker, history, ++number));
            
            return response;
        }

        #endregion
    }
}