using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TradeDash.BackEnd.Services
{
    public interface IApiClient
    {
        Task<List<JObject>> GetStocksAsync();
    }
}