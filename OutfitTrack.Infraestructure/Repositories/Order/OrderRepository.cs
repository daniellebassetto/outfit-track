using Microsoft.EntityFrameworkCore;
using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;

namespace OutfitTrack.Infraestructure.Repositories;

public class OrderRepository(OutfitTrackContext context) : BaseRepository<Order, InputIdentifierOrder>(context), IOrderRepository 
{
    public long GetNextNumber()
    {
        return (_context.Set<Order>().AsNoTracking().OrderBy(x => x.Number).Last().Number ?? 0) + 1;
    }
}