using Microsoft.Extensions.DependencyInjection;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces;

namespace OutfitTrack.Infraestructure.Repositories;

public class UnitOfWork(OutfitTrackContext context, IServiceProvider serviceProvider) : IUnitOfWork
{
    private readonly OutfitTrackContext _context = context;
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly Dictionary<Type, object> _repositories = [];

    public TIBaseRepository GetRepository<TIBaseRepository, TEntity, TInputIdentifier>()
        where TIBaseRepository : IBaseRepository<TEntity, TInputIdentifier>
        where TEntity : BaseEntity<TEntity>
        where TInputIdentifier : class
    {
        var type = typeof(TIBaseRepository);

        if (_repositories.TryGetValue(type, out object? value))
            return (TIBaseRepository)value;

        var repository = _serviceProvider.GetService<TIBaseRepository>()
            ?? throw new InvalidOperationException($"No concrete implementation found for {type}");

        _repositories.Add(type, repository);
        return repository;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}