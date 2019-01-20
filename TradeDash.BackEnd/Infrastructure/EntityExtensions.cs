using TradeDash.DTO;
using Strategy = TradeDash.BackEnd.Data.Strategy;

namespace TradeDash.BackEnd.Infrastructure
{
    public static class EntityExtensions
    {
        public static StrategyResponse MapStrategyResponse(this Strategy strategy)
        {
            return new StrategyResponse
            {
                Id = strategy.Id,
                Name = strategy.Name,
                StrategyType = strategy.StrategyType
            };
        }

        public static DTO.Strategy MapStrategyToDTO(this Strategy strategy)
        {
            return new DTO.Strategy
            {
                Id = strategy.Id,
                Name = strategy.Name,
                StrategyType = strategy.StrategyType
            };
        }
    }
}