using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradeDash.BackEnd.Infrastructure;
using TradeDash.BackEnd.Services;

namespace TradeDash.BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly IApiClient _apiClient;

        public DataController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var stocks = await _apiClient.GetStocksAsync();

            var results = stocks.Select(x => x.MapDataResponse());

            return Ok(results);
        }
    }
}