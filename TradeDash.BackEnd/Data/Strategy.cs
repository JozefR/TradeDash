using System.Collections.Generic;

namespace TradeDash.BackEnd.Data
{
    public class Strategy : TradeDash.DTO.StrategyBase
    {
        public MoneyManagement MoneyManagement { get; set; }
        
        public ICollection<EstaminateReturn> EstaminateReturns { get; set; }
        
        public ICollection<ReturnOnStrategy> ReturnOnStrategy { get; set; }

        public ICollection<StockTrade> StockTrades { get; set; }

        public ICollection<OptionTrade> OptionTrades { get; set; }
    }    

    public enum StrategyType
    {
        Default = 0,
        LongTermOptions,
        ShortTermOptions
    }
}