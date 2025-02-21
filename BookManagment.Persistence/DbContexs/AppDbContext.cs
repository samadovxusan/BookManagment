using Microsoft.EntityFrameworkCore;

namespace BookManagment.Persistence.DbContexs;

public sealed class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    
}