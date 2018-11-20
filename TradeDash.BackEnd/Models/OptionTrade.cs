using System;

namespace TradeDash.BackEnd.Models
{
    public class OptionTrade
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Ticker { get; set; }
        public string OptionType { get; set; }
        public double CurrentPrice { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Strike { get; set; }
        public double Premium { get; set; }
        public double Contracts { get; set; }
        public double Commissions { get; set; }
        public double Margin { get; set; }
        public double PremiumAfterCommissions { get; set; }
        public double NeededInReserve { get; set; }
        public double LossPremium { get; set; }
    }
}