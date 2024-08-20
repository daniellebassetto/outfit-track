using Microsoft.EntityFrameworkCore;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Infraestructure.Maps;

namespace OutfitTrack.Infraestructure;

public class OutfitTrackContext : DbContext
{
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Product> Product { get; set; }

    public OutfitTrackContext() { }

    public OutfitTrackContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerMap());
        modelBuilder.ApplyConfiguration(new ProductMap());

        base.OnModelCreating(modelBuilder);
    }
}