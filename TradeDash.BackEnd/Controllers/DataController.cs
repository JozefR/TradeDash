using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<List<object>> Get()
        {
            var notSerializedData = await _apiClient.GetStocksAsync();
            
            return notSerializedData;
        }
    }
}