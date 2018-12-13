using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TradeDash.BackEnd.Services;
using TradeDash.DTO;

namespace TradeDash.BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly IApiClient _apiClient;

        public DataController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet]
        public async Task<List<Stock>> Get()
        {
            var notSerializedData = await _apiClient.GetStocksAsync();
            var stockData = new List<Stock>();

            foreach (var data in notSerializedData)
            {
                var stock = new Stock
                {
                    Date = DateTime.Parse(data["date"].ToString()),
                    Open = double.Parse(data["open"].ToString()),
                    High = double.Parse(data["high"].ToString()),
                    Low = double.Parse(data["low"].ToString()),
                    Close = double.Parse(data["close"].ToString()),
                    Volume = long.Parse(data["volume"].ToString()),
                    Change = double.Parse(data["change"].ToString()),
                    ChangePercent = double.Parse(data["changePercent"].ToString()),
                    Label = data["label"].ToString(),
                    ChangeOverTime = double.Parse(data["changeOverTime"].ToString())
                };

                stockData.Add(stock);
            }

            return stockData;
        }
    }
}