using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeDash.DTO;

namespace TradeDash.Strategies
{
    // TODO: Need to refactor, how to handle asynchronous code and when to return which type or interface
    /*
    Create abstract strategy class from which all my specific strategies will
    inherite. This abstract strategy class will implement interface with:
    Execute strategy method for checking and calculating concrete strategy.
    Order stock data method because every strategy needs data correctly ordered.
    This class will also define public abstract calculate method for concrete strategy
    implementation.
    */
    public interface IStrategy
    {
        List<StockResponse> ExecuteAsync(List<StockResponse> stockData);
    }

    public abstract class Strategy
    {
        /*
        Private OrderkData() This method will check and sort data by date. 
        It provides correct data for concrete strategy implementation.  
        */
        protected virtual List<StockResponse> OrderData(List<StockResponse> stockResponses)
        {
            // If data == null return null
            // If data length < then 200 return null.
            if (stockResponses is null || stockResponses.Count() < 200)
            {
                return null;
            }

            // Create orderedData variable.
            // Sort data by date from oldest to newest.
            List<StockResponse> orderedData = stockResponses.OrderBy(x => x.Date).ToList();

            // return sorted data.
            return orderedData;
        }
        
        /*
         Puplic abstract calculate() method for concrete strategy implementation.
         Inherited class will implement this method.
        */
        protected abstract List<StockResponse> CalculateAsync(List<StockResponse> orderedData);
    }

    public class ConnorRsiSwing : Strategy, IStrategy
    {
        /*
         Public Execute() method with OrderData method and Calculate method. 
         This method will be called from outside.
        */
        public List<StockResponse> ExecuteAsync(List<StockResponse> stockData)
        {
            List<StockResponse> result = null;

            result = OrderData(stockData);
            result = CalculateAsync(result);

            return result;
        }

        protected override List<StockResponse> CalculateAsync(List<StockResponse> orderedData)
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