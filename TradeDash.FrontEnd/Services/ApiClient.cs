using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Newtonsoft.Json.Linq;
using TradeDash.Application.Infrastructure;
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

        #region Strategies

        public async Task<List<StrategyResponse>> GetStrategiesAsync()
        {
            var response = await _httpClient.GetAsync("/api/strategies");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<StrategyResponse>>();
        }

        public async Task<StrategyResponse> GetStrategyAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/strategies/{id}");
            
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<StrategyResponse>();
        }

        public async Task PostStrategyAsync(StrategyResponse strategy)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/strategies/", strategy);
            
            response.EnsureSuccessStatusCode();
        }

        public async Task PutStrategyAsync(StrategyResponse strategy)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/strategies/{strategy.Id}", strategy);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteStrategyAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/strategies/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return;
            }
            
            response.EnsureSuccessStatusCode();
        }

        #endregion
        
        [HttpGet("{ticker}/{history}")]
        public async Task<List<StockResponse>> GetStocksAsync(string ticker, string history)
        {
            var response = await _httpClient.GetAsync($"/api/stocks/{ticker}/{history}");

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                return null;
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<StockResponse>>();
        }

        public async Task<IEnumerable<IResponse>> CalculateStrategyAsync(string ticker, string history, StrategyType strategyType)
        {
            var response = await _httpClient.GetAsync($"/api/stocks/Calculate/{ticker}/{history}/{strategyType}");
            
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                return null;
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            List<JObject> jsonResponse = await response.Content.ReadAsJsonAsync<List<JObject>>();

            switch (strategyType)
            {
                case StrategyType.Default:
                    return jsonResponse.Select(x => x.MapDataResponse());
                case StrategyType.CrossMA:
                    return jsonResponse.Select(x => x.MapCrossMaDataResponse());
                case StrategyType.ConnorRsi:
                    return jsonResponse.Select(x => x.MapConnorRsiDataResponse());
                default:
                    return null;
            }
        }
    }
}