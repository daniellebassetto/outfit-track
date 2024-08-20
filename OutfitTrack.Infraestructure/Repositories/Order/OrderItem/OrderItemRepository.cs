using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;

namespace OutfitTrack.Infraestructure.Repository;

public class OrderItemRepository(OutfitTrackContext context) : BaseRepository<OrderItem, InputIdentifierOrderItem>(context), IOrderItemRepository { }