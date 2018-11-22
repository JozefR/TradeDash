namespace TradeDash.DTO
{
    public class Strategy
    {
        public int Id { get; set; }

        public StrategyType StrategyType { get; set; }
    }    

    public enum StrategyType
    {
        Default = 0,
        LongTermOptions,
        ShortTermOptions
    }
}