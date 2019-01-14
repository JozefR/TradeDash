namespace TradeDash.DTO
{
    public class StockResponse : Stock, IResponse
    {    
        public Strategy Strategy { get; set; }
    }

    public interface IResponse
    {

    }
}