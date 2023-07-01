using Microsoft.EntityFrameworkCore;

namespace UkiChat.Configuration;

public class AppDbContext : DbContext
{
    public DbSet<Entity.App> App { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(@"Data Source=./data.db");
    }
}