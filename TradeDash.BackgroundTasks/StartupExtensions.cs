using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TradeDash.BackgroundTasks
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddBackgroundTasks(this IServiceCollection services)
        {
            services.AddSingleton<IHostedService, DataRefreshService>();

            return services;
        }
    }
}