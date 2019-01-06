namespace TradeDash.BackEnd.Data
{
    public class EstaminateReturn
    {
        public int Id { get; set; }
        
        public double AccountValue { get; set; }

        public double Premium { get; set; }

        public double Percentage { get; set; }

        public int? StrategyId { get; set; }
    }
}