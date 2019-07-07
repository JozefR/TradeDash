using System.Collections.Generic;
using TradeDash.DTO;

namespace TradeDash.Strategies.Strategies
{
    public class UnknownStrategy : StrategyBase
    {
        public override List<StockResponse> Calculate(List<StockResponse> stocks)
        {
            return stocks;
        }
    }
}