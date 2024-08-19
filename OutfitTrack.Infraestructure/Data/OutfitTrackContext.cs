using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Infraestructure.Maps;

namespace OutfitTrack.Infraestructure;

public class OutfitTrackContext : IdentityDbContext<User, UserRole, long>
{
    public DbSet<Customer> Customer { get; set; }

    public OutfitTrackContext() { }

    public OutfitTrackContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerMap());

        base.OnModelCreating(modelBuilder);
    }
}