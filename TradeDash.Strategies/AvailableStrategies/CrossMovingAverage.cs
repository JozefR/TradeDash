using System;
using System.Collections.Generic;
using System.Linq;
using TradeDash.DTO;

namespace TradeDash.Strategies.AvailableStrategies
{
    public class CrossMovingAverage : StrategyBase, IStrategy
    {
        public IEnumerable<StockResponse> Execute(List<StockResponse> stockData)
        {
            List<StockResponse> result;

            result = OrderData(stockData);
            result = Calculate(result);

            return result;
        }

        private static List<StockResponse> Calculate(List<StockResponse> orderedData)
        {
            var calculateIndicatorsDataResponse = orderedData.ToArray();
            double[] stockClosePrices = calculateIndicatorsDataResponse.Select(x => x.Close).ToArray();

            double[] longSma = Indicators.SMA.Calculate(stockClosePrices, 50);
           
            for (int i = 0; i < calculateIndicatorsDataResponse.Length; i++)
            {
                calculateIndicatorsDataResponse[i].Strategy = new CrossMA();
                
                CrossMA crossMa = (CrossMA) calculateIndicatorsDataResponse[i].Strategy;
                crossMa.LongSMA = Math.Round(longSma[i], 2);
            }

            return calculateIndicatorsDataResponse.ToList();
        }
    }
}