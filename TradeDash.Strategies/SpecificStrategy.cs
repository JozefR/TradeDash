using System;
using TradeDash.DTO;
using TradeDash.Strategies.AvailableStrategies;

namespace TradeDash.Strategies
{
    public class SpecificStrategy : ISpecificStrategy
    {
        public IStrategy GetStrategyType(StrategyType strategyType)
        {
            switch (strategyType)
            {
                case StrategyType.Default:
                    return null;
                case StrategyType.ConnorRsi:
                    return new ConnorRsiSwing();
                case StrategyType.CrossMA:
                    return new CrossMovingAverage();
                default:
                    throw new ApplicationException();
            }
        }
    }
}