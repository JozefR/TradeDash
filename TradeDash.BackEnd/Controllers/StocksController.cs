using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TradeDash.BackEnd.Data;
using TradeDash.BackEnd.Infrastructure;
using TradeDash.BackEnd.Services;
using TradeDash.DTO;
using TradeDash.Strategies;
using TradeDash.Strategies.Interfaces;
using Stock = TradeDash.BackEnd.Data.Stock;

namespace TradeDash.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : Controller
    {
        private readonly IApiClient _apiClient;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IStrategyEngine _strategyEngine;

        public StocksController(
            IApiClient apiClient,
            ApplicationDbContext db,
            IMapper mapper,
            IStrategyEngine strategyEngine)
        {
            _apiClient = apiClient;
            _db = db;
            _mapper = mapper;
            _strategyEngine = strategyEngine;
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
            var response = MapDataResponse(stocks, ticker, history).ToList();

            var results = _strategyEngine.Execute(response, strategyType);

            return Ok(results);
        }

        [HttpPost("Save/{ticker}/{history}/{name}")]
        public async Task<IActionResult> CalculatePost([FromRoute]string ticker, string history, string name)
        {
            // TODO: rewrite this controller
            var strategy = await _db.Strategies.SingleOrDefaultAsync(x => x.Name == name);

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

            var test = _strategyEngine.Execute(results.ToList(), StrategyType.ConnorRsi);

            List<Stock> model = _mapper.Map<List<Stock>>(results);

            // TODO: refactor, create controller for specific strategies
            var createStrategy = new CrossMaStrategy
            {
                Name = strategy.Name + strategy.StrategyType,
                StrategyType = strategy.StrategyType,
            };

            _db.Strategies.Update(createStrategy);
            await _db.SaveChangesAsync();

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