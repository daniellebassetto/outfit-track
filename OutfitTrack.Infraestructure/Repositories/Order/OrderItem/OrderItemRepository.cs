using Microsoft.EntityFrameworkCore;
using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces;

namespace OutfitTrack.Infraestructure.Repositories;

public class OrderItemRepository(OutfitTrackContext context) : BaseRepository<OrderItem, InputIdentifierOrderItem>(context), IOrderItemRepository 
{
    public IEnumerable<OrderItem> GetListByOrderId(long orderId)
    {
        return _context.Set<OrderItem>().AsNoTracking().Where(x => x.OrderId == orderId).ToList();
    }
}