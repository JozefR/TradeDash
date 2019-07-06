using System;
using System.Collections.Generic;
using System.Linq;
using TradeDash.DTO;
using TradeDash.Strategies.Interfaces;

namespace TradeDash.Strategies.Strategies
{
    // TODO: How to handle asynchronous code. When to return which type or interface.
    public class ConnorRsi : StrategyBase
    {
        public override List<StockResponse> Calculate(List<StockResponse> orderedData)
        {
            var calculateIndicatorsDataResponse = orderedData.ToArray();
            double[] stockClosePrices = calculateIndicatorsDataResponse.Select(x => x.Close).ToArray();

            double[] longSma = Indicators.SMA.Calculate(stockClosePrices, 200);
            double[] shortSma = Indicators.SMA.Calculate(stockClosePrices, 5);
            double[] rsi = Indicators.RSI.Calculate(stockClosePrices, 10);

            for (int i = 0; i < calculateIndicatorsDataResponse.Length; i++)
            {
                calculateIndicatorsDataResponse[i].Strategy = new DTO.ConnorRsi();
                DTO.ConnorRsi connorStrategy = (DTO.ConnorRsi) calculateIndicatorsDataResponse[i].Strategy;

                connorStrategy.LongSMA = Math.Round(longSma[i], 2);
                connorStrategy.ShortSMA = Math.Round(shortSma[i], 2);
                connorStrategy.Rsi = Math.Round(rsi[i], 2);
            }

            return calculateIndicatorsDataResponse.ToList();
        }
    }
}