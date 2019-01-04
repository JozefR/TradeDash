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
            var stocks = await _apiClient.GetStocksAsync(ticker, history);

            if (stocks == null)
            {
                return null;
            }

            var orderedDataResponse = MapAndOrderDataResponse(stocks, ticker);
            var results = CalculateIndicatorsForDataResponse(orderedDataResponse);
            
            return Ok(results);
        }

        private static IEnumerable<StockResponse> CalculateIndicatorsForDataResponse(IEnumerable<StockResponse> orderedDataResponse)
        {
            var calculateIndicatorsDataResponse = orderedDataResponse.ToArray();
            double[] stockClosePrices = calculateIndicatorsDataResponse.Select(x => x.Close).ToArray();
            
            double[] longSma = Indicators.SMA.Calculate(stockClosePrices, 200);
            double[] shortSma = Indicators.SMA.Calculate(stockClosePrices, 5);
            double[] rsi = Indicators.RSI.Calculate(stockClosePrices, 10);
            
            for (int i = 0; i < calculateIndicatorsDataResponse.Length; i++)
            {
                calculateIndicatorsDataResponse[i].ConnorIndicators.LongSMA = Math.Round(longSma[i], 2);
                calculateIndicatorsDataResponse[i].ConnorIndicators.ShortSMA = Math.Round(shortSma[i], 2);
                calculateIndicatorsDataResponse[i].ConnorIndicators.Rsi = Math.Round(rsi[i], 2);
            }

            return calculateIndicatorsDataResponse;
        }

        private static IEnumerable<StockResponse> MapAndOrderDataResponse(IEnumerable<JObject> stocks, string ticker)
        {
            int number = 0;
            
            var response = stocks.Select(x => x.MapDataResponse(ticker, ++number));
            var results = response.OrderBy(x => x.Date);
            
            return results;
        }
    }
}