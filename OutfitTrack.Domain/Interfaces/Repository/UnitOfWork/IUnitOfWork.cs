using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Domain.Interfaces.Repository;

public interface IUnitOfWork : IDisposable
{
    TIBaseRepository GetRepository<TIBaseRepository, TEntity, TInputIdentifier>() 
        where TIBaseRepository : IBaseRepository<TEntity, TInputIdentifier> 
        where TEntity : BaseEntity<TEntity> 
        where TInputIdentifier : class;
    Task Commit();
}