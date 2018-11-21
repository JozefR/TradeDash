namespace TradeDash.DTO
{
    public class MoneyManagement
    {
        public int Id { get; set; }

        public decimal AccountValue { get; set; }

        public decimal ToBuyAll { get; set; }

        public decimal AmountAvIfAllBought { get; set; }

        public int? StrategyId { get; set; }
        public Strategy Strategy { get; set; }
    }
}