using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.AspNetCore.Mvc;
using TradeDash.BackEnd.Infrastructure;
using TradeDash.BackEnd.Services;

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
            
            var orderResults = stocks.OrderBy(x => DateTime.Parse(x["date"].ToString()));
            int number = 0;
            var results = orderResults.Select(x => x.MapDataResponse(ticker, ++number));
            
            return Ok(results);
        }
    }
}