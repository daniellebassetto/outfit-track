using AutoMapper;
using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Domain.Mapping;

public class MapperInputEntity : Profile
{
    public MapperInputEntity()
    {
        #region Customer
        CreateMap<InputCreateCustomer, Customer>().ReverseMap();
        CreateMap<InputUpdateCustomer, Customer>().ReverseMap();
        #endregion

        #region Product
        CreateMap<InputCreateProduct, Product>().ReverseMap();
        CreateMap<InputUpdateProduct, Product>().ReverseMap();
        #endregion

        #region Order
        CreateMap<InputCreateOrder, Order>().ReverseMap();
        CreateMap<InputUpdateOrder, Order>().ReverseMap();
        CreateMap<InputCreateOrderItem, OrderItem>().ReverseMap();
        CreateMap<InputUpdateOrderItem, OrderItem>().ReverseMap();
        #endregion
    }
}