namespace TradeDash.BackEnd.Models
{
    public class Strategy
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int MoneyManagementId { get; set; }
        public virtual MoneyManagement MoneyManagement { get; set; }
    }
}