using Microsoft.EntityFrameworkCore;

namespace TradeDash.BackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<MoneyManagement> MoneyManagements { get; set; }
        public DbSet<Strategy> Strategies { get; set; }
        public DbSet<EstaminateReturn> EstaminateReturns { get; set; }
        public DbSet<ReturnOnStrategy> ReturnOnStrategies { get; set; }
        public DbSet<StockTrade> StockTrades { get; set; }
        public DbSet<OptionTrade> OptionTrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoneyManagement>()
                .Property(x => x.AccountValue)
                .HasColumnType("decimal(9,6)");
            
            modelBuilder.Entity<MoneyManagement>()
                .Property(x => x.ToBuyAll)
                .HasColumnType("decimal(9,6)");
            
            modelBuilder.Entity<MoneyManagement>()
                .Property(x => x.AmountAvIfAllBought)
                .HasColumnType("decimal(9,6)");
        }
    }
}