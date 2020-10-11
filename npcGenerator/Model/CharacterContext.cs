using Microsoft.EntityFrameworkCore;

namespace npcGenerator.Model
{
    public class CharacterContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=miair\\SQLEXPRESS; Database=GoT; Trusted_Connection=True");
        }
    }
}
