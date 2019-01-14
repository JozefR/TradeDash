using System;
using Newtonsoft.Json.Linq;
using TradeDash.DTO;

namespace TradeDash.FrontEnd.Infrastructure
{
    public static class JsonExtensions
    {
        public static CrossMaResponse MapCrossMaDataResponse(this JObject jObject)
        {
            return new CrossMaResponse()
            {
                CrossMa = new CrossMA
                {
                    Id = Int32.Parse(jObject["strategy"]["id"].ToString()),
                    StrategyType = StrategyType.CrossMA,
                    Name = jObject["strategy"]["name"].ToString(),
                    LongSMA = Double.Parse(jObject["strategy"]["longSMA"].ToString())
                },
                Number = Int32.Parse(jObject["number"].ToString()),
                Ticker = jObject["ticker"].ToString(),
                History = jObject["history"].ToString(),
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

        public static ConnorRsiResponse MapConnorRsiDataResponse(this JObject jObject)
        {
            return new ConnorRsiResponse()
            {
                ConnorRsi = new ConnorRsi
                {
                    Id = Int32.Parse(jObject["strategy"]["id"].ToString()),
                    StrategyType = StrategyType.ConnorRsi,
                    Name = jObject["strategy"]["name"].ToString(),
                    LongSMA = Double.Parse(jObject["strategy"]["longSMA"].ToString()),
                    ShortSMA = Double.Parse(jObject["strategy"]["shortSMA"].ToString()),
                    Rsi = Double.Parse(jObject["strategy"]["rsi"].ToString())
                },
                Number = Int32.Parse(jObject["number"].ToString()),
                Ticker = jObject["ticker"].ToString(),
                History = jObject["history"].ToString(),
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