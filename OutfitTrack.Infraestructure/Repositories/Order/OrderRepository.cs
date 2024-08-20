using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;

namespace OutfitTrack.Infraestructure.Repositories;

public class OrderRepository(OutfitTrackContext context) : BaseRepository<Order, InputIdentifierOrder>(context), IOrderRepository { }