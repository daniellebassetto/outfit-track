using AutoMapper;
using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Application.Mapping;

public class MapperInputEntity : Profile
{
    public MapperInputEntity()
    {
        #region Customer
        CreateMap<InputCreateCustomer, Customer>().ReverseMap();
        #endregion

        #region Product
        CreateMap<InputCreateProduct, Product>().ReverseMap();
        #endregion

        #region Order
        CreateMap<InputCreateOrder, Order>().ReverseMap();
        CreateMap<InputCreateOrderItem, OrderItem>().ReverseMap();
        #endregion

        #region User
        CreateMap<InputCreateUser, User>().ReverseMap();
        #endregion
    }
}