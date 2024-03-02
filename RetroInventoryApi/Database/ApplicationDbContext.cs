using Microsoft.EntityFrameworkCore;
using RetroInventoryApi.Domain;

namespace RetroInventoryApi.Database
{
    public class ApplicationDbContext : DbContext
    {
        // string DbUsername = Environment.GetEnvironmentVariable("RETROINVENTORY_DB_USERNAME");
        // string DbPassword = Environment.GetEnvironmentVariable("RETROINVENTORY_DB_PASSWORD");

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseNpgsql($"Host=localhost;Database=retroinventorydb;Username={DbUsername};Password={DbPassword}");
            optionsBuilder.UseInMemoryDatabase("RetroInventoryDb");
        }
    }
}
