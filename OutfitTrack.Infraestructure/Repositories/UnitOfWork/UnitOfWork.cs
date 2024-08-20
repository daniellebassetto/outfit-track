using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;

namespace OutfitTrack.Infraestructure.Repositories;

public class UnitOfWork(OutfitTrackContext context) : IUnitOfWork
{
    public OutfitTrackContext _context = context;
    private readonly Dictionary<Type, object> _repositories = [];

    public TIBaseRepository GetRepository<TIBaseRepository, TEntity, TInputIdentifier>()
    where TIBaseRepository : IBaseRepository<TEntity, TInputIdentifier>
    where TEntity : BaseEntity<TEntity>
    where TInputIdentifier : class
    {
        var type = typeof(TIBaseRepository);

        if (_repositories.ContainsKey(type))
            return (TIBaseRepository)_repositories[type];

        var implementationType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsClass && !t.IsAbstract && type.IsAssignableFrom(t)).FirstOrDefault() 
            ?? throw new InvalidOperationException($"No concrete implementation found for {type}");

        var repository = Activator.CreateInstance(implementationType, _context) 
            ?? throw new InvalidOperationException($"Cannot create an instance of {implementationType}");

        _repositories.Add(type, repository);

        return (TIBaseRepository)repository;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}