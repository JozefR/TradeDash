using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TradeDash.DataApiProviders
{
    public class ExDataProvider : IExDataProvider
    {
        public async Task<JObject> ConnectClientToGetDataAsync()
        {
            string apiPath = "https://api.iextrading.com/1.0/stock/aapl/chart/1y";
            JObject apiData = null;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri(apiPath);
                HttpResponseMessage response = await client.GetAsync(apiPath);

                if (response.IsSuccessStatusCode)
                {
                    apiData = await response.Content.ReadAsAsync<JObject>();
                }
            }
            
            return apiData;
        }

        public JArray ConnectClientToGetData()
        {
            string apiPath = "https://api.iextrading.com/1.0/stock/aapl/chart/1y";
            JArray apiData = null;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept
                    .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri(apiPath);
                HttpResponseMessage response =  client.GetAsync(apiPath).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    apiData = response.Content.ReadAsAsync<JArray>().GetAwaiter().GetResult();
                }
            }
            return apiData;
        }
    }
}