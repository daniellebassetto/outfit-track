using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;
using OutfitTrack.Domain.Interfaces.Service;

namespace OutfitTrack.Domain.Services;

public class OrderService(IUnitOfWork unitOfWork) : BaseService<IOrderRepository, InputCreateOrder, InputUpdateOrder, Order, OutputOrder, InputIdentifierOrder>(unitOfWork), IOrderService { }