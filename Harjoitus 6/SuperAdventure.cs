global using Microsoft.EntityFrameworkCore;

namespace Harjoitus_6
{
    public class SuperAdventure : DbContext
    {
        // Konstruktori
        public SuperAdventure(DbContextOptions<SuperAdventure> options) : base(options) {}

        // Tämän avulla voidaan suorittaa esim. LINQ-kysely ja tallentaa tietoja
        public DbSet<Quest> Quests { get; set; }
    }
}
