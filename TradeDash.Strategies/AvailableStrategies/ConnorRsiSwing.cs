using System;
using System.Collections.Generic;
using System.Linq;
using TradeDash.DTO;

namespace TradeDash.Strategies.AvailableStrategies
{
    // TODO: How to handle asynchronous code. When to return which type or interface.    
    public class ConnorRsiSwing : StrategyBase, IStrategy
    {
        public IEnumerable<StockResponse> Execute(List<StockResponse> stockData)
        {
            List<StockResponse> result = null;

            result = OrderData(stockData);
            result = Calculate(result);

            return result;
        }

        private static List<StockResponse> Calculate(List<StockResponse> orderedData)
        {
            var calculateIndicatorsDataResponse = orderedData.ToArray();
            double[] stockClosePrices = calculateIndicatorsDataResponse.Select(x => x.Close).ToArray();

            double[] longSma = Indicators.SMA.Calculate(stockClosePrices, 200);
            double[] shortSma = Indicators.SMA.Calculate(stockClosePrices, 5);
            double[] rsi = Indicators.RSI.Calculate(stockClosePrices, 10);

            for (int i = 0; i < calculateIndicatorsDataResponse.Length; i++)
            {
                calculateIndicatorsDataResponse[i].Strategy = new ConnorRsi();
                ConnorRsi connorStrategy = (ConnorRsi) calculateIndicatorsDataResponse[i].Strategy;

                connorStrategy.LongSMA = Math.Round(longSma[i], 2);
                connorStrategy.ShortSMA = Math.Round(shortSma[i], 2);
                connorStrategy.Rsi = Math.Round(rsi[i], 2);
            }

            return calculateIndicatorsDataResponse.ToList();
        }
    }
}