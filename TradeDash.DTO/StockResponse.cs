namespace TradeDash.DTO
{
    public class StockResponse : Stock
    {    
        public int Number { get; set; }
        public string Ticker { get; set; }
        public string History { get; set; }
        public Strategy Strategy { get; set; } = new Strategy();
    }
}