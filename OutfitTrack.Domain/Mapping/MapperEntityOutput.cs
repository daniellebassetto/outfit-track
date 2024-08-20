using AutoMapper;
using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Domain.Mapping;

public class MapperEntityOutput : Profile
{
    public MapperEntityOutput()
    {
        #region Customer
        CreateMap<Customer, OutputCustomer>().ReverseMap();
        #endregion

        #region Product
        CreateMap<Product, OutputProduct>().ReverseMap();
        #endregion

        #region Order
        CreateMap<Order, OutputOrder>().ReverseMap();
        CreateMap<OrderItem, OutputOrderItem>().ReverseMap();
        #endregion
    }
}