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
    }
}