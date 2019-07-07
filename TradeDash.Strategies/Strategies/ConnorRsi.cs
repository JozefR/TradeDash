using System;
using System.Collections.Generic;
using System.Linq;
using TradeDash.DTO;

namespace TradeDash.Strategies.Strategies
{
    // TODO: How to handle asynchronous code. When to return which type or interface.
    public class ConnorRsi : StrategyBase
    {
        public override List<StockResponse> Calculate(List<StockResponse> stocks)
        {
            var orderedData = ValidateData(stocks).ToArray();

            double[] stockClosePrices = orderedData.Select(x => x.Close).ToArray();

            double[] longSma = Indicators.SMA.Calculate(stockClosePrices, 200);
            double[] shortSma = Indicators.SMA.Calculate(stockClosePrices, 5);
            double[] rsi = Indicators.RSI.Calculate(stockClosePrices, 10);

            for (int i = 0; i < orderedData.Length; i++)
            {
                orderedData[i].Strategy = new DTO.ConnorRsi();
                DTO.ConnorRsi connorStrategy = (DTO.ConnorRsi) orderedData[i].Strategy;

                connorStrategy.LongSMA = Math.Round(longSma[i], 2);
                connorStrategy.ShortSMA = Math.Round(shortSma[i], 2);
                connorStrategy.Rsi = Math.Round(rsi[i], 2);
            }

            return orderedData.ToList();
        }
    }
}