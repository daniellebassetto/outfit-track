using OutfitTrack.Arguments;

namespace OutfitTrack.Application.Interfaces;

public interface IOrderService : IBaseService<InputCreateOrder, InputUpdateOrder, OutputOrder, InputIdentifierOrder> { }