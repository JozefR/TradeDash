using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TradeDash.BackEnd.Infrastructure;
using TradeDash.BackEnd.Services;
using TradeDash.DTO;

namespace TradeDash.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : Controller
    {
        private readonly IApiClient _apiClient;

        public StocksController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet("{ticker}/{history}")]
        public async Task<IActionResult> Get([FromRoute] string ticker, string history)
        {
            var stocks = await _apiClient.GetStocksIexDataAsync(ticker, history);

            if (stocks == null)
            {
                return null;
            }
            
            var dataResponse = ProcessDataResponse(stocks, ticker);
            
            return Ok(dataResponse);
        }

        private static IEnumerable<StockResponse> ProcessDataResponse(IEnumerable<JObject> stocks, string ticker)
        {
            var orderResults = stocks.OrderBy(x => DateTime.Parse(x["date"].ToString()));

            int number = 0;
            var results = new List<StockResponse>();

            foreach (var result in orderResults)
            {
                ++number;
                var dataResponse = result.MapDataResponse(ticker, number);
                
                results.Add(dataResponse);
            }

            return results;
        }
    }
}