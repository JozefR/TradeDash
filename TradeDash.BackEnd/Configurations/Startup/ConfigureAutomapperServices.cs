using System.Globalization;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TradeDash.DTO;
using Stock = TradeDash.BackEnd.Data.Stock;

namespace TradeDash.BackEnd.Configurations.Startup
{
    public static class ConfigureAutomapperServices
    {
        public static IMapper ConfigureAutomapper(this IServiceCollection serviceCollection)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CrossMAProfile>();
            });

            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();

            serviceCollection?.AddSingleton(mapper);

            return mapper;
        }
    }

    public class CrossMAProfile : Profile
    {
        public CrossMAProfile()
        {
            CreateMap<StockResponse, Stock>()
                .ForMember(d => d.Id, m => m.Ignore())
                .ForMember(d => d.Date,m => m.MapFrom(s => s.Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Number, m => m.MapFrom(s => s.Number))
                .ForMember(d => d.Ticker, m => m.MapFrom(s => s.Ticker))
                .ForMember(d => d.History, m => m.MapFrom(s => s.History))
                .ForMember(d => d.Open, m => m.MapFrom(s => s.Open))
                .ForMember(d => d.High, m => m.MapFrom(s => s.High))
                .ForMember(d => d.Low, m => m.MapFrom(s => s.Low))
                .ForMember(d => d.Close, m => m.MapFrom(s => s.Close))
                .ForMember(d => d.Volume, m => m.MapFrom(s => s.Volume))
                .ForMember(d => d.UnadjustedVolume, m => m.Ignore())
                .ForMember(d => d.Change, m => m.MapFrom(s => s.Change))
                .ForMember(d => d.ChangePercent, m => m.MapFrom(s => s.ChangePercent))
                .ForMember(d => d.Label, m => m.MapFrom(x => x.Label))
                ;
        }
    }
}