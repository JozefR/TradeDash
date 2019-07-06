using System;
using TradeDash.DTO;
using TradeDash.Strategies.Interfaces;

namespace TradeDash.Strategies.Strategies
{
    public class StrategyFactory : IStrategyFactory
    {
        public StrategyBase Create(StrategyType strategyType)
        {
            // TODO: implement null object pattern, make sth with default which should not return null.
            switch (strategyType)
            {
                case StrategyType.Default:
                    return null;
                case StrategyType.ConnorRsi:
                    return new ConnorRsi();
                case StrategyType.CrossMA:
                    return new CrossMovingAverage();
                default:
                    throw new ApplicationException();
            }
        }
    }
}