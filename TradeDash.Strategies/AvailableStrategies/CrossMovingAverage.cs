using System;
using System.Collections.Generic;
using System.Linq;
using TradeDash.DTO;

namespace TradeDash.Strategies.AvailableStrategies
{
    public class CrossMovingAverage : StrategyBase, IStrategy
    {
        public IEnumerable<StockResponse> Execute(List<StockResponse> stockData, Strategy strategy = null)
        {
            List<StockResponse> result;

            result = OrderData(stockData);
            result = Calculate(result, strategy);

            return result;
        }

        private static List<StockResponse> Calculate(List<StockResponse> orderedData, Strategy strategy)
        {
            var calculateIndicatorsDataResponse = orderedData.ToArray();
            double[] stockClosePrices = calculateIndicatorsDataResponse.Select(x => x.Close).ToArray();

            double[] longSma = Indicators.SMA.Calculate(stockClosePrices, 50);
           
            for (int i = 0; i < calculateIndicatorsDataResponse.Length; i++)
            {
                calculateIndicatorsDataResponse[i].Strategy = new CrossMA();
                CrossMA crossMa = (CrossMA) calculateIndicatorsDataResponse[i].Strategy;
                crossMa.LongSMA = Math.Round(longSma[i], 2);

                if (strategy == null) continue;

                crossMa.Id = strategy.Id;
                crossMa.Name = strategy.Name;
                crossMa.StrategyType = strategy.StrategyType;
            }

            return calculateIndicatorsDataResponse.ToList();
        }
    }
}