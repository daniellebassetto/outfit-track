using Microsoft.EntityFrameworkCore;
using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces;

namespace OutfitTrack.Infraestructure.Repositories;

public class OrderRepository(OutfitTrackContext context) : BaseRepository<Order, InputIdentifierOrder>(context), IOrderRepository
{
    public long GetNextNumber()
    {
        var listOrder = _context.Set<Order>().AsNoTracking().OrderBy(x => x.Number).ToList();
        return listOrder.Count > 0 ? (listOrder.Last().Number!.Value + 1) : 1;
    }
}