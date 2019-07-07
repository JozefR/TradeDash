using System;
using System.Collections.Generic;
using System.Linq;
using TradeDash.DTO;

namespace TradeDash.Strategies.Strategies
{
    public abstract class StrategyBase
    {
        public abstract List<StockResponse> Calculate(List<StockResponse> stocks);

        /*
         This method will check and sort data by date.
         It provides ordered data for concrete strategy implementation.
         */
        protected static IEnumerable<StockResponse> ValidateData(List<StockResponse> stockResponses)
        {
            // number of closes prices can't be lesser then 200 becouse of SMA200.
            if (stockResponses is null || stockResponses.Count() < 200)
            {
                throw new Exception("Stock prices are lesser then 200 or null.");
            }

            // Data must be ordered for every strategy calculation!
            // Unordered data, results bad indicator calculations!
            return stockResponses.OrderBy(x => x.Date);
        }
    }
}