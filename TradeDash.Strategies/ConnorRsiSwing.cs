using System;
using System.Collections.Generic;
using System.Linq;
using TradeDash.DTO;

namespace TradeDash.Strategies
{
    public class ConnorRsiSwing
    {
        public static IEnumerable<StockResponse> Calculate(IEnumerable<StockResponse> orderedDataResponse)
        {
            var calculateIndicatorsDataResponse = orderedDataResponse.ToArray();
            double[] stockClosePrices = calculateIndicatorsDataResponse.Select(x => x.Close).ToArray();
            
            double[] longSma = Indicators.SMA.Calculate(stockClosePrices, 200);
            double[] shortSma = Indicators.SMA.Calculate(stockClosePrices, 5);
            double[] rsi = Indicators.RSI.Calculate(stockClosePrices, 10);
            
            for (int i = 0; i < calculateIndicatorsDataResponse.Length; i++)
            {
                calculateIndicatorsDataResponse[i].Strategy = new ConnorRsi();
                ConnorRsi connorStrategy = (ConnorRsi)calculateIndicatorsDataResponse[i].Strategy;
                
                connorStrategy.LongSMA = Math.Round(longSma[i], 2);
                connorStrategy.ShortSMA = Math.Round(shortSma[i], 2);
                connorStrategy.Rsi = Math.Round(rsi[i], 2);
            }

            return calculateIndicatorsDataResponse;
        }
    }
}