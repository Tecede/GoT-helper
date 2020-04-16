using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npcGenerator.Model
{
    public class CharacterContext : DbContext
    {
        public DbSet<Character> CharactersCont { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=miair\\SQLEXPRESS; Database=GoT; Trusted_Connection=True");
        }
    }
}
