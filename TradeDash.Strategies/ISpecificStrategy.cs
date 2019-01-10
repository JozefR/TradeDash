using TradeDash.DTO;

namespace TradeDash.Strategies
{
    public interface ISpecificStrategy
    {
        IStrategy GetStrategyType(StrategyType strategyType);
    }
}