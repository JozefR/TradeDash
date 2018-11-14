using Microsoft.EntityFrameworkCore;

namespace TradeDash.BackEnd.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<MoneyManagement> MoneyManagements { get; set; }
    }
}