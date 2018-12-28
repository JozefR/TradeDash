using System;
using Newtonsoft.Json.Linq;
using TradeDash.DTO;

namespace TradeDash.BackEnd.Infrastructure
{
    public static class JsonExtensions
    {
        public static StockResponse MapDataResponse(
            this JObject jObject, string ticker, int number)
        {
            return new StockResponse
            {
                Number = number,
                Ticker = ticker,
                Date = DateTime.Parse(jObject["date"].ToString()),
                Open = double.Parse(jObject["open"].ToString()),
                High = double.Parse(jObject["high"].ToString()),
                Low = double.Parse(jObject["low"].ToString()),
                Close = double.Parse(jObject["close"].ToString()),
                Volume = long.Parse(jObject["volume"].ToString()),
                Change = double.Parse(jObject["change"].ToString()),
                ChangePercent = double.Parse(jObject["changePercent"].ToString()),
                Label = jObject["label"].ToString(),
                ChangeOverTime = double.Parse(jObject["changeOverTime"].ToString())
            };
        }
    }
}