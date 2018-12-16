using System.Globalization;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TradeDash.DTO;
using TradeDash.FrontEnd.ViewModels.Stock;
using TradeDash.FrontEnd.ViewModels.Strategy;

namespace TradeDash.FrontEnd.Configurations.Startup
{
    public static class ConfigureAutomapperServices
    {
        public static IMapper ConfigureAutomapper(this IServiceCollection serviceCollection)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StrategyReadingProfile>();
                cfg.AddProfile<StockReadingProfile>();
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
    
    public class StockReadingProfile : Profile
    {
        public StockReadingProfile()
        {
            CreateMap<StockResponse, StockViewModel>()
                .ForMember(d => d.Number, m => m.MapFrom(s => s.Number))
                .ForMember(d => d.Ticker, m => m.MapFrom(s => s.Ticker))
                .ForMember(d => d.Date, m => m.MapFrom(s => s.Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Volume, m => m.MapFrom(s => s.Volume))
                .ForMember(d => d.ClosePrice, m => m.MapFrom(s => s.Close))
                .ForMember(d => d.ChangePercent, m => m.MapFrom(s => s.ChangePercent));
        }
    }
}