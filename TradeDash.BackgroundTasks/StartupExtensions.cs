using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TradeDash.BackgroundTasks
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddBackgroundTasks(this IServiceCollection services, IConfiguration configuration)
        {
            return null;
        }
    }
}