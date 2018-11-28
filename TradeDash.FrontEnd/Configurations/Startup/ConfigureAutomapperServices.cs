using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TradeDash.DTO;
using TradeDash.FrontEnd.ViewModels;

namespace TradeDash.FrontEnd.Configurations.Startup
{
    public static class ConfigureAutomapperServices
    {
        public static IMapper ConfigureAutomapper(this IServiceCollection serviceCollection)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StrategyReadingProfile>();
            });

            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();

            serviceCollection?.AddSingleton(mapper);

            return mapper;
        } 
    }

    public class StrategyReadingProfile : Profile
    {
        public StrategyReadingProfile()
        {
            CreateMap<Strategy, StrategyViewModel>();
        }
    }
}