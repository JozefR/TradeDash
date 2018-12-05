using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using TradeDash.BackgroundTasks.Abstractions;

namespace TradeDash.BackgroundTasks
{
    public class DataRefreshService : HostedService 
    {
        protected override Task ExecuteAsync(CancellationToken cancellationToken, CancellationTokenSource cts)
        {
            throw new System.NotImplementedException();
        }
    }
}