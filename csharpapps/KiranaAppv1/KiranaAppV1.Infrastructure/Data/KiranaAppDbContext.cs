using KiranaAppV1.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KiranaAppV1.Infrastructure.Data;

public class KiranaAppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Product> Products { get; set;}

    public KiranaAppDbContext(DbContextOptions<KiranaAppDbContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().ToTable("Products");
    }
}