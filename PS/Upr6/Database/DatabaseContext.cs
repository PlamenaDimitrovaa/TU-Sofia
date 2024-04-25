using Microsoft.EntityFrameworkCore;
using System;
using Upr6.Helpers;
using Upr6.Model;

namespace Upr6.Database;
internal class DatabaseContext : DbContext
{
    public DbSet<DbUser>? Users { get; set; }
    public DbSet<DbLog>? Logs { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string databasePath = "dbsettings.db";
        optionsBuilder.UseSqlite($"Data Source={databasePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbUser>().Property(e => e.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<DbLog>().Property(e => e.Id).ValueGeneratedOnAdd();

        DbUser user = new DbUser()
        {
            Id = 1,
            Name = "John Doe",
            Password = "1234",
            Role = UserRolesEnum.ADMIN,
            CreatedAt = DateTime.Now,
        };

        modelBuilder.Entity<DbUser>().HasData(user);
    }
}
