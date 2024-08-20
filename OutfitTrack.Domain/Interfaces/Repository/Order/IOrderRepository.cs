using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Domain.Interfaces.Repository;

public interface IOrderRepository : IBaseRepository<Order, InputIdentifierOrder> { }