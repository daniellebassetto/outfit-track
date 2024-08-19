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
    }
}