using System.Collections.Generic;
using System.Threading.Tasks;
using TradeDash.DTO;

namespace TradeDash.FrontEnd.Services
{
    public interface IApiClient
    {
        Task<List<StrategyResponse>> GetStrategiesAsync();
        Task<StrategyResponse> GetStrategyAsync(int id);
        Task PutStrategyAsync(Strategy strategy);
        Task PostStrategyAsync(Strategy strategy);
        Task DeleteStrategyAsync(int id);
        Task<List<StockResponse>> GetStocksAsync(string ticker, string history);
    }
}
