using System;
using TradeDash.DTO;
using TradeDash.Strategies.Interfaces;

namespace TradeDash.Strategies.Strategies
{
    public class StrategyFactory : IStrategyFactory
    {
        public StrategyBase Create(StrategyType strategyType)
        {
            switch (strategyType)
            {
                case StrategyType.Default:
                    return new UnknownStrategy();
                case StrategyType.ConnorRsi:
                    return new ConnorRsi();
                case StrategyType.CrossMA:
                    return new CrossMovingAverage();
                default:
                    return new UnknownStrategy();
            }
        }
    }
}