using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;
using OutfitTrack.Domain.Interfaces.Service;

namespace OutfitTrack.Domain.Services;

public class OrderService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IProductRepository productRepository) : BaseService<IOrderRepository, InputCreateOrder, InputUpdateOrder, Order, OutputOrder, InputIdentifierOrder>(unitOfWork), IOrderService 
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IProductRepository _productRepository = productRepository;

    //public override OutputOrder? Create(InputCreateOrder inputCreate)
    //{
    //    Customer? customer = _customerRepository!.Get(x => x.Id == inputCreate.CustomerId) ?? throw new KeyNotFoundException("Não foi encontrado nenhum cliente correspondente a este Id.");
        
    //    foreach(var item in inputCreate.ListOrderItem!)
    //    {
    //        Product? product = _productRepository!.Get(x => x.Id == item.ProductId) ?? throw new KeyNotFoundException("Não foi encontrado nenhum produto correspondente a este Id.");
    //    }

    //    Order order = new Order()
    //    {
    //        CustomerId = inputCreate.CustomerId,
    //        Number = GetNextNumber(),

    //    };
    //}
}