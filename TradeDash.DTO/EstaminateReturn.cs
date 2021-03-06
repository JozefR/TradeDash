using System.ComponentModel.DataAnnotations;

namespace TradeDash.DTO
{
    public class EstaminateReturn
    {
        public int Id { get; set; }
        
        public double AccountValue { get; set; }

        public double Premium { get; set; }

        public double Percentage { get; set; }

        [Required]
        public int StrategyId { get; set; }
    }
}