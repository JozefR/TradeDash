using System.Collections.Generic;
using TradeDash.DTO;
using TradeDash.Strategies.Interfaces;
using StrategyBase = TradeDash.Strategies.Strategies.StrategyBase;

namespace TradeDash.Strategies
{
    public class StrategyEngine : IStrategyEngine
    {
        private readonly IStrategyFactory _strategyFactory;

        public StrategyEngine(IStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        public IEnumerable<StockResponse> Execute(List<StockResponse> stockResponses, StrategyType strategyType)
        {
            StrategyBase strategy = _strategyFactory.Create(strategyType);

            var results = strategy.Calculate(stockResponses);

            return results;
        }
    }
}