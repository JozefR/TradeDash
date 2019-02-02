using System.Collections.Generic;

namespace TradeDash.BackEnd.Data
{
    public class Strategy : DTO.StrategyBase
    {
        public MoneyManagement MoneyManagement { get; set; }
        
        public ICollection<EstaminateReturn> EstaminateReturns { get; set; }
        
        public ICollection<ReturnOnStrategy> ReturnOnStrategy { get; set; }
    }
}