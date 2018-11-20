using System.Collections.Generic;

namespace TradeDash.BackEnd.Models
{
    public class Strategy
    {
        public int Id { get; set; }

        public StrategyType StrategyType { get; set; }

        public int MoneyManagementId { get; set; }
        public MoneyManagement MoneyManagement { get; set; }

        public int EstaminateReturnId { get; set; }
        public EstaminateReturn EstaminateReturn { get; set; }

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