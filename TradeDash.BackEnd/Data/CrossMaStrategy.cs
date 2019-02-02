using System.Collections.Generic;

namespace TradeDash.BackEnd.Data
{
    public class CrossMaStrategy : Strategy
    {
        public ICollection<Stock> Stocks { get; set; }
    }
}