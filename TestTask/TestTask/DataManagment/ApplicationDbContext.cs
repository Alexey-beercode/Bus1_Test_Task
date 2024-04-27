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
}