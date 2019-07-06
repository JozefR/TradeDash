using System.Collections.Generic;
using TradeDash.DTO;

namespace TradeDash.Strategies.Interfaces
{
    public interface IStrategyEngine
    {
        IEnumerable<StockResponse> Execute(IEnumerable<StockResponse> stockResponses, StrategyType strategyType);
    }
}