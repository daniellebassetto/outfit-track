using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Domain.Interfaces;

public interface IOrderItemRepository : IBaseRepository<OrderItem, InputIdentifierOrderItem> 
{
    IEnumerable<OrderItem> GetListByOrderId(long orderId);
}