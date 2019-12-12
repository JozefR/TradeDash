using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TradeDash.BackEnd.Data;

namespace TradeDash.BackEnd.Configurations.Startup
{
    public static class ConfigureDbContextServices
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                }
                else
                {
                    options.UseSqlServer("Server=localhost,1433; Database=TradeDashDb2;User=SA; Password=Pwd12345!");
                }
            });

            return services;
        }
    }
}