using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.DataManagment;

public class ApplicationDbContext : DbContext
{
    public DbSet<Link> Links { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Конфигурация модели Link
        modelBuilder.Entity<Link>().HasKey(l => l.Id); // Указываем первичный ключ
        modelBuilder.Entity<Link>().Property(l => l.LongUrl).IsRequired();
        modelBuilder.Entity<Link>().Property(l => l.ShortUrl).IsRequired();
        modelBuilder.Entity<Link>().Property(l => l.CreatedDate).IsRequired();
        modelBuilder.Entity<Link>().Property(l => l.Count).IsRequired();
    }*/
}