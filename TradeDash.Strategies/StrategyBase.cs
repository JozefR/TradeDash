using System.Collections.Generic;
using System.Linq;
using TradeDash.DTO;

namespace TradeDash.Strategies
{
    public abstract class StrategyBase
    {
        /*
         Private OrderkData() This method will check and sort data by date. 
         It provides ordered data for concrete strategy implementation.
         */
        protected static List<StockResponse> OrderData(List<StockResponse> stockResponses)
        {
            // If data == null return null
            // If data length < then 200 return null.
            if (stockResponses is null || stockResponses.Count() < 200)
            {
                return null;
            }

            // Create orderedData variable.
            // Sort data by date from oldest to newest.
            List<StockResponse> orderedData = stockResponses.OrderBy(x => x.Date).ToList();

            // return sorted data.
            return orderedData;
        }
    }
}