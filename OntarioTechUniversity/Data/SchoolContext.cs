using OntarioTechUniversity.Models;
using Microsoft.EntityFrameworkCore;


namespace OntarioTechUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<SafetyDataSheet> SafetyDataSheets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasMany(b => b.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Location>()
                .HasMany(c => c.SafetyDataSheets)
                .WithOne();
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<SafetyDataSheet>().ToTable("SafetyDataSheet");
        }
    }
}
