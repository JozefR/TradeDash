using System.Collections.Generic;
using TradeDash.DTO;

namespace TradeDash.Strategies
{
    /*
     * This interface is used for creating specific strategy implementation.
     */
    public interface IStrategy
    {
        IEnumerable<StockResponse> Execute(List<StockResponse> stockData, Strategy strategy = null);
    }
}