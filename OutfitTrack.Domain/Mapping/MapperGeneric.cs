using AutoMapper;

namespace OutfitTrack.Domain.Mapping;

public class MapperGeneric<TInput, TOutput> : Profile
{
    public MapperGeneric()
    {
        CreateMap<TInput, TOutput>().ReverseMap();
    }
}