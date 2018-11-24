using System.ComponentModel.DataAnnotations;

namespace TradeDash.BackEnd.Data
{
    public class ReturnOnStrategy
    {
        public int Id { get; set; }

        public double AtTheEndProfit { get; set; }

        public double DrawDown { get; set; }

        public double ProfitLoss { get; set; }

        public double Total { get; set; }

        public int? StrategyId { get; set; }
    }
}