using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Domain.Interfaces.Repository;

public interface IBaseRepository<TEntity, TInputIdentifier>
    where TEntity : BaseEntity<TEntity>
{
    List<TEntity>? GetAll();
    TEntity? Get(long id);
    TEntity? GetByIdentifier(TInputIdentifier inputIdentifier);
    long? Create(TEntity entity);
    long? Update(TEntity entity);
    bool Delete(TEntity entity);
}