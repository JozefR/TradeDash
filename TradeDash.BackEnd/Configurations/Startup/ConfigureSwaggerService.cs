using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace TradeDash.BackEnd.Configurations.Startup
{
    public static class ConfigureSwaggerService
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "TradeDash API", Version = "v1",
                        Contact = new Contact {Name = "Jozef Randjak", Email = "randjakjozef@gmail.com"}
                    });
                c.SwaggerDoc("v2",
                    new Info
                    {
                        Title = "TradeDash API", Version = "v2",
                        Contact = new Contact {Name = "Jozef Randjak", Email = "randjakjozef@gmail.com"}
                    });
            });

            return services;
        }

        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TradeDash API v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "TradeDash API v2");
            });

            return app;
        }
    }
}