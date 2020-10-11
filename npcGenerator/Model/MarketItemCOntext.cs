using Microsoft.EntityFrameworkCore;

namespace npcGenerator.Model
{
    class MarketItemContext : DbContext
    {
        public DbSet<MarketItem> MarketItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=miair\\SQLEXPRESS; Database=GoT; Trusted_Connection=True");
        }
    }
}
