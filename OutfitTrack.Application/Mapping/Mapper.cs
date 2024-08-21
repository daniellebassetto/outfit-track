using AutoMapper;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Application.Mapping;

public class Mapper(IMapper mapperEntityOutput, IMapper mapperInputEntity) : BaseSetProperty<Mapper>
{
    public IMapper MapperEntityOutput { get; private set; } = mapperEntityOutput;
    public IMapper MapperInputEntity { get; private set; } = mapperInputEntity;
}