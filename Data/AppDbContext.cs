using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Product>(entity =>
      {
        entity.HasKey(p => p.Id);
        entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
        entity.Property(p => p.Price).HasColumnType("decimal(10,2)");
      });
    }
  }
}
