using System.ComponentModel.DataAnnotations;

namespace TradeDash.DTO
{
    public class StrategyBase
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
        CrossMA,
        ConnorRsi
    }
}