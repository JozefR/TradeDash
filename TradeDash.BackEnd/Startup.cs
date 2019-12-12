using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TradeDash.BackEnd.Configurations.Startup;
using TradeDash.BackEnd.Services;
using TradeDash.BackgroundTasks;
using TradeDash.DataApiProviders;
using TradeDash.Strategies;
using TradeDash.Strategies.Interfaces;
using TradeDash.Strategies.Strategies;

namespace TradeDash.BackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBackgroundTasks();
            services.ConfigureAutomapper();
            services.AddSingleton<RandomStringProvider>();
            services.ConfigureSwagger();
            services.ConfigureDbContext(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddHttpClient<IApiClient, ApiClient>();
            services.AddScoped<IStrategyEngine, StrategyEngine>();
            services.AddScoped<IStrategyFactory, StrategyFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}