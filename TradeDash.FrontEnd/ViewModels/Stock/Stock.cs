namespace TradeDash.FrontEnd.ViewModels.Stock
{
    public class Stock
    {
        public int Number { get; set; }
        public string Ticker { get; set; }
        public string History { get; set; }
        public string Date { get; set; }
        public string ClosePrice { get; set; }
        public string ChangePercent { get; set; }
        public string Volume { get; set; }
    }
}