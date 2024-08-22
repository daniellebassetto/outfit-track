using OutfitTrack.Domain.Entities;
using System.Linq.Expressions;

namespace OutfitTrack.Domain.Interfaces;

public interface IBaseRepository<TEntity, TInputIdentifier>
    where TEntity : BaseEntity<TEntity>
    where TInputIdentifier : class
{
    IEnumerable<TEntity>? GetAll();
    TEntity? Get(Expression<Func<TEntity, bool>> predicate);
    IEnumerable<TEntity>? GetList(Expression<Func<TEntity, bool>> predicate);
    TEntity? GetByIdentifier(TInputIdentifier inputIdentifier);
    TEntity? Create(TEntity entity);
    TEntity? Update(TEntity entity);
    bool Delete(TEntity entity);
}