using TradeDash.DTO;
using StrategyBase = TradeDash.Strategies.Strategies.StrategyBase;

namespace TradeDash.Strategies.Interfaces
{
    public interface IStrategyFactory
    {
        StrategyBase Create(StrategyType strategyType);
    }
}