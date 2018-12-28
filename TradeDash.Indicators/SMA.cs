namespace TradeDash.Indicators
{
    public class SMA
    {
        public string Name { get; }
        public string ShortName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SMA"/> class. 
        /// </summary>
        public SMA()
        {
            Name = "Simple Moving Average";
            ShortName = "SMA";
        }

        /// <summary>
        /// Calculates indicator.
        /// </summary>
        /// <param name="price">Price series.</param>
        /// <param name="period">Indicator period.</param>
        /// <returns>Calculated indicator series.</returns>
        public static double[] Calculate(double[] price, int period)
        {
            var sma = new double[price.Length];

            double sum = 0;

            for (var i = 0; i < period; i++)
            {
                sum += price[i];
                sma[i] = sum / (i + 1);
            }

            for (var i = period; i < price.Length; i++)
            {
                sum = 0;
                for (var j = i; j > i - period; j--)
                {
                    sum += price[j];
                }

                sma[i] = sum / period;
            }

            return sma;
        }
    }
}