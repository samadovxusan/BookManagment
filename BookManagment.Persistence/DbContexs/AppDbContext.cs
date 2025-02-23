using BookManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagment.Persistence.DbContexs;

public  class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    
}