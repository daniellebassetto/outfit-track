using OutfitTrack.Arguments;

namespace OutfitTrack.Domain.Interfaces.Service;

public interface IOrderService : IBaseService<InputCreateOrder, InputUpdateOrder, OutputOrder, InputIdentifierOrder> { }