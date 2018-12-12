using System.Collections.Generic;
using System.Threading.Tasks;

namespace TradeDash.BackEnd.Services
{
    public interface IApiClient
    {
        Task<List<object>> GetStocksAsync();
    }
}