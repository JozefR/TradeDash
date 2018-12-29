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
            
            var dataResponse = ProcessDataResponse(stocks, ticker).ToArray();
            CalculateIndicatorsForDataResponse(dataResponse);
            
            return Ok(dataResponse);
        }

        private static void CalculateIndicatorsForDataResponse(StockResponse[] dataResponse)
        {
            double[] stockClosePrices = dataResponse.Select(x => x.Close).ToArray();
            
            double[] longSma = Indicators.SMA.Calculate(stockClosePrices, 200);
            double[] shortSma = Indicators.SMA.Calculate(stockClosePrices, 5);
            double[] rsi = Indicators.RSI.Calculate(stockClosePrices, 10);
            
            for (int i = 0; i < dataResponse.Length; i++)
            {
                dataResponse[i].ConnorIndicators.LongSMA = longSma[i];
                dataResponse[i].ConnorIndicators.ShortSMA = shortSma[i];
                dataResponse[i].ConnorIndicators.Rsi = rsi[i];
            }
        }

        private static IEnumerable<StockResponse> ProcessDataResponse(IEnumerable<JObject> stocks, string ticker)
        {
            var orderResults = stocks.OrderBy(x => DateTime.Parse(x["date"].ToString()));

            int number = 0;
            var results = orderResults.Select(x => x.MapDataResponse(ticker, ++number));

            return results;
        }
    }
}