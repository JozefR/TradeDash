using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TradeDash.DTO;
using TradeDash.FrontEnd.Infrastructure;

namespace TradeDash.FrontEnd.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StrategyResponse>> GetStrategiesAsync()
        {
            var response = await _httpClient.GetAsync("/api/strategies");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<StrategyResponse>>();
        }

        public Task<StrategyResponse> GetStrategyAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task PutStrategyAsync(Strategy strategy)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteStrategyAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}