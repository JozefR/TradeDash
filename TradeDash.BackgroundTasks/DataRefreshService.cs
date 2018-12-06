using System;
using System.Threading;
using System.Threading.Tasks;
using TradeDash.DataApiProviders;

namespace TradeDash.BackgroundTasks
{
    public class DataRefreshService : HostedService
    {
        private readonly RandomStringProvider _stringProvider;

        public DataRefreshService(RandomStringProvider stringProvider)
        {
            _stringProvider = stringProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken, CancellationTokenSource cts)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await _stringProvider.UpdateString(cancellationToken, cts);
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
        }
    }
}