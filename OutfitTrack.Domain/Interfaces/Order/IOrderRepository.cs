using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Domain.Interfaces;

public interface IOrderRepository : IBaseRepository<Order, InputIdentifierOrder>
{
    long GetNextNumber();
}