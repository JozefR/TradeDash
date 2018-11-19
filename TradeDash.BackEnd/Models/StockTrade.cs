using System;

namespace TradeDash.BackEnd.Models
{
    public class StockTrade
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Ticker { get; set; }
        public double StrikePrice { get; set; }
        public int Quantity { get; set; }
        public double CurrentPrice { get; set; }
        public double PL { get; set; }
    }
}