using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces;
using OutfitTrack.Application.Interfaces;

namespace OutfitTrack.Application.Services;

public class OrderService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IProductRepository productRepository, IOrderItemRepository orderItemRepository) : BaseService<IOrderRepository, InputCreateOrder, InputUpdateOrder, Order, OutputOrder, InputIdentifierOrder>(unitOfWork), IOrderService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IOrderItemRepository _orderItemRepository = orderItemRepository;

    public override OutputOrder Create(InputCreateOrder inputCreate)
    {
        Customer? customer = _customerRepository.Get(x => x.Id == inputCreate.CustomerId) ?? throw new KeyNotFoundException("Não foi encontrado nenhum cliente correspondente a este Id.");

        foreach (var item in inputCreate.ListCreatedItem!)
        {
            Product? product = _productRepository.Get(x => x.Id == item.ProductId) ?? throw new KeyNotFoundException("Não foi encontrado nenhum produto correspondente a este Id.");
        }

        Order order = new(inputCreate.CustomerId, EnumStatusOrder.Pending, null, _repository!.GetNextNumber(), inputCreate.Observation, null, null);

        _repository.Create(order);
        _unitOfWork!.Commit();

        int count = 1;
        List<OrderItem> items = inputCreate.ListCreatedItem.Select(i => new OrderItem(count++, order.Id, i.ProductId, i.Variation, EnumStatusOrderItem.InProgress, null, null)).ToList();
        order.SetProperty(nameof(Order.ListOrderItem), items);

        foreach (var item in order.ListOrderItem!)
        {
            _orderItemRepository.Create(item);
        }
        _unitOfWork!.Commit();

        return FromEntityToOutput(order);
    }

    public override OutputOrder Update(long id, InputUpdateOrder inputUpdateOrder)
    {
        Order? order = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException("Condicional não encontrado.");

        if (order.Status == EnumStatusOrder.Closed)
            throw new InvalidOperationException("Condicional finalizado!");

        List<OrderItem> existingItems = order.ListOrderItem!;

        // Deleta itens do pedido que estão na lista de exclusão
        if (inputUpdateOrder.ListDeletedItem != null)
        {
            foreach (var idItem in inputUpdateOrder.ListDeletedItem)
            {
                var itemToDelete = existingItems.FirstOrDefault(x => x.Id == idItem);
                if (itemToDelete != null)
                {
                    _orderItemRepository.Delete(itemToDelete);
                    existingItems.Remove(itemToDelete);
                }
            }
        }

        // Atualiza itens do pedido
        if (inputUpdateOrder.ListUpdatedItem != null)
        {
            foreach (var updateItem in inputUpdateOrder.ListUpdatedItem)
            {
                var itemToUpdate = existingItems.FirstOrDefault(x => x.Id == updateItem.Id);
                if (itemToUpdate != null)
                {
                    itemToUpdate.SetProperty(nameof(OrderItem.Variation), updateItem.InputUpdate!.Variation);
                    itemToUpdate.SetProperty(nameof(OrderItem.Status), updateItem.InputUpdate.Status);
                    itemToUpdate.SetProperty(nameof(OrderItem.ChangeDate), DateTime.UtcNow);
                }
            }
        }

        // Adiciona novos itens ao pedido
        if (inputUpdateOrder.ListCreatedItem != null)
        {
            int nextItemNumber = existingItems.Count + 1;
            List<OrderItem> newItems = inputUpdateOrder.ListCreatedItem.Select(createItem =>
                new OrderItem(nextItemNumber++, order.Id, createItem.ProductId, createItem.Variation, EnumStatusOrderItem.InProgress, null, null)).ToList();

            foreach (var newItem in newItems)
            {
                _orderItemRepository.Create(newItem);
            }
        }

        order.SetProperty(nameof(Order.ListOrderItem), existingItems);
        UpdateOrderStatus(order, existingItems);

        _repository.Update(order);
        _unitOfWork!.Commit();

        return FromEntityToOutput(order);
    }

    private static void UpdateOrderStatus(Order order, List<OrderItem> existingItems)
    {
        if (existingItems.All(x => x.Status != EnumStatusOrderItem.InProgress))
            order.SetProperty(nameof(Order.Status), EnumStatusOrder.AwaitingClosure);
        else if (order.Status == EnumStatusOrder.AwaitingClosure)
            order.SetProperty(nameof(Order.Status), EnumStatusOrder.Pending);
    }

    public bool Close(long id)
    {
        Order? order = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException("Pedido não encontrado.");

        if (order.Status != EnumStatusOrder.AwaitingClosure)
            throw new KeyNotFoundException("Há itens do pedindo que estão com status 'Em andamento'");

        order.SetProperty(nameof(Order.Status), EnumStatusOrder.Closed);
        order.SetProperty(nameof(Order.ClosingDate), DateTime.UtcNow);

        _repository.Update(order);
        _unitOfWork!.Commit();
        return true;
    }
}