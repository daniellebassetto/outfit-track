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

    public override OutputOrder? Create(InputCreateOrder inputCreate)
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

        foreach(var item in order.ListOrderItem!)
        {
            _orderItemRepository.Create(item);
        }
        _unitOfWork!.Commit();

        return FromEntityToOutput(order);
    }

    public override OutputOrder? Update(long id, InputUpdateOrder inputUpdateOrder)
    {
        // Verifica se o pedido existe
        Order? order = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException("Condicional não encontrado.");

        if(order.Status == EnumStatusOrder.Closed)
            throw new InvalidOperationException("Condicional finalizado!.");

        // Recupera os itens existentes do pedido
        List<OrderItem> existingItem = _orderItemRepository.GetList(x => x.OrderId == id)?.ToList() ?? [];

        // Deleta itens do pedido que estão na lista de exclusão
        if (inputUpdateOrder.ListDeletedItem != null)
        {
            foreach (var itemId in inputUpdateOrder.ListDeletedItem)
            {
                var itemToDelete = existingItem.FirstOrDefault(x => x.Item == itemId);
                if (itemToDelete != null)
                    _orderItemRepository.Delete(itemToDelete);
            }
        }

        // Atualiza itens do pedido
        if (inputUpdateOrder.ListUpdatedItem != null)
        {
            foreach (var updateItem in inputUpdateOrder.ListUpdatedItem)
            {
                var itemToUpdate = existingItem.FirstOrDefault(x => x.Id == updateItem.Id);
                if (itemToUpdate != null)
                {
                    itemToUpdate.SetProperty(nameof(OrderItem.Variation), updateItem.InputUpdate!.Variation);
                    itemToUpdate.SetProperty(nameof(OrderItem.Status), updateItem.InputUpdate.Status);
                }
            }
        }

        // Adiciona novos itens ao pedido
        if (inputUpdateOrder.ListCreatedItem != null)
        {
            int nextItemNumber = existingItem.Count + 1;
            foreach (var createItem in inputUpdateOrder.ListCreatedItem)
            {
                // Adiciona o novo item ao pedido
                var product = _productRepository.Get(x => x.Id == createItem.ProductId) ?? throw new KeyNotFoundException("Produto não encontrado.");
                OrderItem newItem = new(nextItemNumber++, order.Id, createItem.ProductId, createItem.Variation, EnumStatusOrderItem.InProgress, product, order);
                _orderItemRepository.Create(newItem);
                existingItem.Add(newItem);
            }
        }

        // Verifica o status dos itens para mudar o status do pedido
        if (existingItem.All(x => x.Status != EnumStatusOrderItem.InProgress))
            order.SetProperty(nameof(Order.Status), EnumStatusOrder.AwaitingClosure);

        // Atualiza o pedido
        _repository.Update(order);
        _unitOfWork!.Commit();

        // Retorna o pedido atualizado
        return FromEntityToOutput(order);
    }

    public override bool Delete(long id)
    {
        Order? order = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException("Pedido não encontrado.");

        var items = _orderItemRepository.GetList(x => x.OrderId == id)?.ToList();
        foreach (var item in items!)
        {
            _orderItemRepository.Delete(item);
        }

        _repository.Delete(order);
        _unitOfWork!.Commit();
        return true;
    }

    public bool Close(long id)
    {
        Order? order = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException("Pedido não encontrado.");
        order.SetProperty(nameof(OrderItem.Status), EnumStatusOrder.Closed);

        _repository.Update(order);

        return true;
    }
}