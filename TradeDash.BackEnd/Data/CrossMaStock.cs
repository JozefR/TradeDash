namespace TradeDash.BackEnd.Data
{
    public class CrossMaStock : DTO.Stock
    {
        public int Id { get; set; }
        public double LongSma { get; set; }

        public int CrossMaStrategyId { get; set; }
        public CrossMaStrategy CrossMaStrategy { get; set; }
    }
}