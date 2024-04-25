using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upr1.Others;
using Upr4.Model;

namespace Upr4.Database;
internal class DatabaseContext: DbContext
{
    public DbSet<DatabaseUser> Users { get; set; }
    public DbSet<DatabaseLog> Logs { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string databaseFile = "dbsettings.db";
        string databasePath = Path.Combine(solutionFolder, databaseFile);
        optionsBuilder.UseSqlite($"Data Source={databasePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<DatabaseLog>().Property(e => e.Id).ValueGeneratedOnAdd();

        var user = new DatabaseUser()
        {
            Id = 1,
            Name = "John Doe",
            Password = "1234",
            Role = UserRolesEnum.ADMIN,
            Expires = DateTime.Now.AddYears(10),
            FakNum = "121221",
            Mail = "ff@ff"
        };

        modelBuilder.Entity<DatabaseUser>().HasData(user);
    }
}
