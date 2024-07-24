using Microsoft.EntityFrameworkCore;
namespace MushroomPocket
{
    public class MushroomDbContext : DbContext
    {
        public DbSet<MushroomCharacter> MushroomCharacters { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MushroomDb.db");

        }

    }
}