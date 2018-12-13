using System;

namespace TradeDash.DTO
{
    public class Stock
    {
        public DateTime Date { get; set; }
        
        public double Open { get; set; }
        
        public double High { get; set; }
        
        public double Low { get; set; }
        
        public double Close { get; set; }
        
        public long Volume { get; set; }
        
        public long UnadjustedVolume { get; set; }
        
        public double Change { get; set; }
        
        public double ChangePercent { get; set; }
        
        public string Label { get; set; }
        
        public double ChangeOverTime { get; set; }
    }
}