using Microsoft.EntityFrameworkCore;
using Transliteration.Data.Configurations;
using Transliteration.Data.Models;

namespace Transliteration.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<NameEntry> NameEntries { get; set; }
        public DbSet<SearchLog> SearchLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NameEntry>()
                .HasIndex(n => n.NameOriginal);

            modelBuilder.Entity<NameEntry>()
                .HasIndex(n => n.NameTransliterated);

            modelBuilder.ApplyConfiguration(new NameEntryConfiguration());
        }
    }
}
