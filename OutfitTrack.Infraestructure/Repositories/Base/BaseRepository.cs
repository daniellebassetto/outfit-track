using Microsoft.EntityFrameworkCore;
using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

namespace OutfitTrack.Infraestructure.Repositories;

public class BaseRepository<TEntity, TInputIdentifier>(OutfitTrackContext context) : IBaseRepository<TEntity, TInputIdentifier>
    where TEntity : BaseEntity<TEntity>, new()
    where TInputIdentifier : class
{
    protected readonly OutfitTrackContext _context = context;

    #region Read
    public PaginatedResult<TEntity>? GetAll(int pageNumber, int pageSize)
    {
        if (pageNumber <= 0)
            pageNumber = 1;
        if (pageSize <= 0)
            pageSize = 10;

        IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking();
        query = BaseRepository<TEntity, TInputIdentifier>.IncludeVirtualProperties(query);

        var totalItems = query.Count(); 

        var items = query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

        return new PaginatedResult<TEntity>
        {
            Items = items,
            TotalItems = totalItems,
            CurrentPage = pageNumber,
            PageSize = pageSize
        };
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking().Where(predicate);
        query = BaseRepository<TEntity, TInputIdentifier>.IncludeVirtualProperties(query);
        return query.FirstOrDefault();
    }

    public IEnumerable<TEntity>? GetList(Expression<Func<TEntity, bool>> predicate)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking().Where(predicate);
        query = BaseRepository<TEntity, TInputIdentifier>.IncludeVirtualProperties(query);
        return query;
    }

    public TEntity? GetByIdentifier(TInputIdentifier inputIdentifier)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking();

        var parameter = Expression.Parameter(typeof(TEntity), "x");
        Expression? combinedExpression = null;

        foreach (var property in typeof(TInputIdentifier).GetProperties())
        {
            var propertyValue = property.GetValue(inputIdentifier);
            if (propertyValue == null)
                continue;

            var member = Expression.Property(parameter, property.Name);
            var constant = Expression.Constant(propertyValue, member.Type);
            var body = Expression.Equal(member, constant);

            combinedExpression = combinedExpression == null ? body : Expression.AndAlso(combinedExpression, body);
        }

        if (combinedExpression != null)
        {
            var lambda = Expression.Lambda<Func<TEntity, bool>>(combinedExpression, parameter);
            query = query.Where(lambda);
        }

        return query.FirstOrDefault();
    }
    #endregion

    #region Create
    public TEntity? Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity.SetCreateData());
        return entity;
    }
    #endregion

    #region Update
    public TEntity? Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity.SetUpdateData());
        return entity;
    }
    #endregion

    #region Delete
    public bool Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        return true;
    }
    #endregion

    #region InternalMethods
    protected static IQueryable<TEntity> IncludeVirtualProperties(IQueryable<TEntity> query)
    {
        var entityType = typeof(TEntity);
        var baseEntityType = typeof(BaseEntity<>).MakeGenericType(entityType);
        var properties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                   .Where(p => p.DeclaringType == entityType &&
                                               p.GetGetMethod()?.IsVirtual == true &&
                                               !baseEntityType.GetProperties().Any(bp => bp.Name == p.Name));

        foreach (var property in properties)
        {
            query = query.Include(property.Name);
        }

        return query;
    }
    #endregion
}