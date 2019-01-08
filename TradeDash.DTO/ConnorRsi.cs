namespace TradeDash.DTO
{
    public class ConnorRsi : Strategy
    {
        public double LongSMA { get; set; }
        
        public double ShortSMA { get; set; }
        
        public double Rsi { get; set; }
    }
}