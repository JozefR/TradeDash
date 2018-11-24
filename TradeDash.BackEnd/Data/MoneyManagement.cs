using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace TradeDash.BackEnd.Data
{
    public class MoneyManagement
    {
        public int Id { get; set; }

        public decimal AccountValue { get; set; }

        public decimal ToBuyAll { get; set; }

        public decimal AmountAvIfAllBought { get; set; }

        public int? StrategyId { get; set; }
    }
    
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args) =>
            Program.CreateWebHostBuilder(args).Build().Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
}