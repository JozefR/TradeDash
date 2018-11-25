using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TradeDash.FrontEnd.Infrastructure
{
    public static class HttpClientExtensions
    {
        private static readonly JsonSerializer _jsonSerializer = new JsonSerializer();

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent httpContent)
        {
            using (var stream = await httpContent.ReadAsStreamAsync())
            {
                var jsonReader = new JsonTextReader(new StreamReader(stream));

                return _jsonSerializer.Deserialize<T>(jsonReader);
            }
        }
    }
}