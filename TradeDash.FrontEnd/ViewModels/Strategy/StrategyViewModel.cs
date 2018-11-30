using System.ComponentModel.DataAnnotations;
using TradeDash.DTO;

namespace TradeDash.FrontEnd.ViewModels.Strategy
{
    public class StrategyViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public StrategyType StrategyType { get; set; }
    }
}