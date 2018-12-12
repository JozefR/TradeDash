using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TradeDash.Application.Infrastructure;

namespace TradeDash.BackEnd.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<object>> GetStocksAsync()
        {
            var response = await _httpClient.GetAsync("https://api.iextrading.com/1.0/stock/aapl/chart/1y");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<object>>();
        }
    }
}