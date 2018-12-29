using System;
using Newtonsoft.Json.Linq;
using TradeDash.DTO;

namespace TradeDash.BackEnd.Infrastructure
{
    public static class JsonExtensions
    {
        public static StockResponse MapDataResponse(this JObject jObject, string ticker, int number)
        {
            return new StockResponse
            {
                Number = number,
                Ticker = ticker,
                Date = DateTime.Parse(jObject["date"].ToString()),
                Open = Double.Parse(jObject["open"].ToString()),
                High = Double.Parse(jObject["high"].ToString()),
                Low = Double.Parse(jObject["low"].ToString()),
                Close = Double.Parse(jObject["close"].ToString()),
                Volume = Int64.Parse(jObject["volume"].ToString()),
                Change = Double.Parse(jObject["change"].ToString()),
                ChangePercent = Double.Parse(jObject["changePercent"].ToString()),
                Label = jObject["label"].ToString(),
                ChangeOverTime = Double.Parse(jObject["changeOverTime"].ToString())
            };
        }
    }
}