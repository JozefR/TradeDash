using System.ComponentModel.DataAnnotations;

namespace TradeDash.DTO
{
    public class Strategy
    {
        public int Id { get; set; }

        [Required]
        [StringLength(36)]
        public string Name { get; set; }

        public StrategyType StrategyType { get; set; }
    }    

    public enum StrategyType
    {
        Default = 0,
        LongTermOptions,
        ShortTermOptions,
        ConnorRsi
    }
}