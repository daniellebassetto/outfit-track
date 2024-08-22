using Microsoft.EntityFrameworkCore;
using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces;

namespace OutfitTrack.Infraestructure.Repositories;

public class OrderItemRepository(OutfitTrackContext context) : BaseRepository<OrderItem, InputIdentifierOrderItem>(context), IOrderItemRepository { }