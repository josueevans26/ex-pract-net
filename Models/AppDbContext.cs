using Microsoft.EntityFrameworkCore;
using Ex1.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Encuestas> Encuestas { get; set; }
    
}