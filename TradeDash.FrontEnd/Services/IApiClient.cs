using System.Collections.Generic;
using System.Threading.Tasks;
using TradeDash.DTO;

namespace TradeDash.FrontEnd.Services
{
    public interface IApiClient
    {
        Task<List<StrategyResponse>> GetStrategiesAsync();
        Task<StrategyResponse> GetStrategyAsync(int id);
        Task PutStrategyAsync(StrategyResponse strategy);
        Task PostStrategyAsync(StrategyResponse strategy);
        Task DeleteStrategyAsync(int id);
        Task<List<StockResponse>> GetStocksAsync(string ticker, string history);
        Task<List<Strategy>> CalculateStrategyAsync(string ticker, string history, StrategyType strategyType);
    }
}
