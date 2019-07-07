using System;
using System.Collections.Generic;
using System.Linq;
using TradeDash.DTO;
using TradeDash.Strategies.Interfaces;

namespace TradeDash.Strategies.Strategies
{
    public class CrossMovingAverage : StrategyBase
    {
        public override List<StockResponse> Calculate(List<StockResponse> stocks)
        {
            var calculateIndicatorsDataResponse = stocks.ToArray();
            double[] stockClosePrices = calculateIndicatorsDataResponse.Select(x => x.Close).ToArray();

            double[] longSma = Indicators.SMA.Calculate(stockClosePrices, 50);

            for (int i = 0; i < calculateIndicatorsDataResponse.Length; i++)
            {
                calculateIndicatorsDataResponse[i].Strategy = new CrossMA();
                CrossMA crossMa = (CrossMA) calculateIndicatorsDataResponse[i].Strategy;
                crossMa.LongSMA = Math.Round(longSma[i], 2);

                crossMa.Name = "CrossMA";
                crossMa.StrategyType = StrategyType.CrossMA;
            }

            return calculateIndicatorsDataResponse.ToList();
        }
    }
}