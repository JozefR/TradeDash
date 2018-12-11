using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TradeDash.DataApiProviders
{
    public interface IExDataProvider
    {
        Task<JObject> ConnectClientToGetDataAsync();
        
        JArray ConnectClientToGetData();
    }
}