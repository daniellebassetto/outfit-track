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
        // Verifica se o cliente informado existe
        Customer? customer = _customerRepository.Get(x => x.Id == inputCreate.CustomerId) ?? throw new KeyNotFoundException("Não foi encontrado nenhum cliente correspondente a este Id.");

        // Verifica se os produtos informados nos itens existem
        foreach (var item in inputCreate.ListOrderItem!)
        {
            Product? product = _productRepository.Get(x => x.Id == item.ProductId) ?? throw new KeyNotFoundException("Não foi encontrado nenhum produto correspondente a este Id.");
        }

        // Cria a entidade pedido
        Order order = new(inputCreate.CustomerId, EnumStatusOrder.Pending, null, _repository!.GetNextNumber(), null, null);

        // Salva o pedido no repositório para gerar o ID
        _repository.Create(order);
        _unitOfWork!.Commit();

        // Adiciona os itens ao pedido
        int count = 1;
        List<OrderItem> items = inputCreate.ListOrderItem.Select(i => new OrderItem(count++, order.Id, i.ProductId, i.Color, i.Size, EnumStatusOrderItem.InProgress, null, null)).ToList();
        order.SetProperty(nameof(Order.ListOrderItem), items);

        // Atualiza o pedido com os itens
        foreach(var item in order.ListOrderItem!)
        {
            _orderItemRepository.Create(item);
        }
        _unitOfWork!.Commit();

        // Retorna o pedido criado
        return FromEntityToOutput(order);
    }

    public override bool Delete(long id)
    {
        // Verifica se o pedido existe
        Order? order = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException("Pedido não encontrado.");

        // Remove os itens do pedido
        var items = _orderItemRepository.GetListByOrderId(id).ToList();
        foreach (var item in items)
        {
            _orderItemRepository.Delete(item);
        }

        // Remove o pedido
        _repository.Delete(order);
        _unitOfWork!.Commit();
        return true;
    }
}