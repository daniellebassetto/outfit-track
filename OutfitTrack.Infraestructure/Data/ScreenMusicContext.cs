using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Infraestructure;

public class OutfitTrackContext : IdentityDbContext<User, UserRole, long>
{
    public OutfitTrackContext() { }

    public OutfitTrackContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}