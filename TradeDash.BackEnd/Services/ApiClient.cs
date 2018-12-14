using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TradeDash.Application.Infrastructure;
using TradeDash.Application.Settings;

namespace TradeDash.BackEnd.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<JObject>> GetStocksAsync(string ticker, string history)
        {
            string iexPath = String.Format(ProviderSettings.iex_provider_path, String.Concat(ticker), String.Concat(history));
            
            var response = await _httpClient.GetAsync(iexPath);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<JObject>>();
        }
    }
}