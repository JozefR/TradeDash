namespace TradeDash.BackEnd.Models
{
    public class Strategy
    {
        public int Id { get; set; }

        public StrategyType StrategyType { get; set; }

        public int MoneyManagementId { get; set; }
        public virtual MoneyManagement MoneyManagement { get; set; }
    }

    public enum StrategyType
    {
        LongTermOptions = 0,
        ShortTermOptions
    }
}