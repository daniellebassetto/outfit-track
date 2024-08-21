using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;
using OutfitTrack.Domain.Interfaces.Service;

namespace OutfitTrack.Domain.Services;

public class OrderService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IProductRepository productRepository, IOrderItemRepository orderItemRepository) : BaseService<IOrderRepository, InputCreateOrder, InputUpdateOrder, Order, OutputOrder, InputIdentifierOrder>(unitOfWork), IOrderService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IOrderItemRepository _orderItemRepository = orderItemRepository;

    public override OutputOrder? Create(InputCreateOrder inputCreate)
    {
        Customer? customer = _customerRepository!.Get(x => x.Id == inputCreate.CustomerId) ?? throw new KeyNotFoundException("Não foi encontrado nenhum cliente correspondente a este Id.");

        foreach (var item in inputCreate.ListOrderItem!)
        {
            Product? product = _productRepository!.Get(x => x.Id == item.ProductId) ?? throw new KeyNotFoundException("Não foi encontrado nenhum produto correspondente a este Id.");
        }

        Order order = new(inputCreate.CustomerId, EnumStatusOrder.Pending, null, _repository?.GetNextNumber(), null, null) { };

        _repository!.Create(order);
        _unitOfWork!.Commit();

        int count = 1;
        List<OrderItem> items = inputCreate.ListOrderItem!.Select(i => new OrderItem(count++, order.Id, i.ProductId, i.Color, i.Size, EnumStatusOrderItem.InProgress, null, null)).ToList();

        order.SetProperty(nameof(Order.ListOrderItem), items);

        foreach (var orderItem in items)
        {
            _orderItemRepository.Create(orderItem);
        }

        _unitOfWork.Commit();
        return FromEntityToOutput(order);
    }
}