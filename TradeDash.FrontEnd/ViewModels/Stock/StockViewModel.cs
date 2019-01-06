namespace TradeDash.FrontEnd.ViewModels.Stock
{
    public class StockViewModel
    {
        public int Number { get; set; }
        public string Ticker { get; set; }
        public string Date { get; set; }
        public string ClosePrice { get; set; }
        public string ChangePercent { get; set; }
        public string Volume { get; set; }
    }
}