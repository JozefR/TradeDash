using System.ComponentModel.DataAnnotations;

namespace TradeDash.DTO
{
    public class ReturnOnStrategy
    {
        public int Id { get; set; }

        public double AtTheEndProfit { get; set; }

        public double DrawDown { get; set; }

        public double ProfitLoss { get; set; }

        public double Total { get; set; }

        [Required]
        public int StrategyId { get; set; }
    }
}