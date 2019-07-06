using System.Collections.Generic;
using System.Linq;
using TradeDash.DTO;
using TradeDash.Strategies.Interfaces;
using TradeDash.Strategies.Strategies;

namespace TradeDash.Strategies
{
    public class StrategyEngine : IStrategyEngine
    {
        private readonly IStrategyFactory _strategyFactory;

        public StrategyEngine(IStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        public IEnumerable<StockResponse> Execute(IEnumerable<StockResponse> stockResponses, StrategyType strategyType)
        {
            var strategy = _strategyFactory.Create(strategyType);

            var results = strategy.Calculate(stockResponses.ToList());

            return results;
        }
    }
}