using Microsoft.AspNetCore.Mvc;
using TradeDash.DataApiProviders;

namespace TradeDash.BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly RandomStringProvider _randomStringProvider;
        private readonly IExDataProvider _exDataProvider;

        public DataController(
            RandomStringProvider randomStringProvider, 
            IExDataProvider exDataProvider)
        {
            _randomStringProvider = randomStringProvider;
            _exDataProvider = exDataProvider;
        }

        [HttpGet]
        public string Get()
        {
            var test = _exDataProvider.ConnectClientToGetDataAsync();
            var test2 = _exDataProvider.ConnectClientToGetData();

            return null;
        }
    }
}