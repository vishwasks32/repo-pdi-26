using KiranaAppV1.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace KiranaAppV1.Infrastructure.Data;

public class KiranaAppDbContext: DbContext
{
    public KiranaAppDbContext(DbContextOptions<KiranaAppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().ToTable("Products");
    }
}