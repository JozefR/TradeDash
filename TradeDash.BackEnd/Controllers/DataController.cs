using Microsoft.AspNetCore.Mvc;
using TradeDash.DataApiProviders;

namespace TradeDash.BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly RandomStringProvider _randomStringProvider;

        public DataController(RandomStringProvider randomStringProvider)
        {
            _randomStringProvider = randomStringProvider;
        }

        [HttpGet]
        public string Get()
        {
            return _randomStringProvider.RandomString;
        }
    }
}