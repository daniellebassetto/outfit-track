using OutfitTrack.Domain.ApiManagement;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;
using OutfitTrack.Domain.Interfaces.Service;

namespace OutfitTrack.Domain.Services;

public class BaseService<TBaseRepository, TInputCreate, TInputUpdate, TEntity, TOutput, TInputIdentifier>(TBaseRepository? repository) : IBaseService<TInputCreate, TInputUpdate, TOutput, TInputIdentifier>
    where TBaseRepository : IBaseRepository<TEntity, TInputIdentifier>
    where TEntity : BaseEntity<TEntity>, new()
{
    public Guid _guidApiDataRequest;
    protected TBaseRepository? _repository = repository;
    public void SetGuid(Guid guidApiDataRequest)
    {
        _guidApiDataRequest = guidApiDataRequest;
        GenericModule.SetGuidApiDataRequest(this, guidApiDataRequest);
    }

    #region Read
    public virtual List<TOutput>? GetAll()
    {
        var listEntity = _repository!.GetAll();

        if (listEntity is not null)
            return FromEntityToOutput(listEntity);
        else
            return default;
    }

    public virtual TOutput? Get(long id)
    {
        var entity = _repository!.Get(id);

        if (entity is not null)
            return FromEntityToOutput(entity);
        else
            return default;
    }

    public virtual TOutput? GetByIdentifier(TInputIdentifier inputIdentifier)
    {
        var entity = _repository!.GetByIdentifier(inputIdentifier);

        if (entity is not null)
            return FromEntityToOutput(entity);
        else
            return default;
    }
    #endregion

    #region Create
    public virtual long? Create(TInputCreate inputCreate)
    {
        return _repository!.Create(FromInputCreateToEntity(inputCreate) ?? new TEntity());
    }
    #endregion

    #region Update
    public virtual long? Update(long id, TInputUpdate inputUpdate)
    {
        var oldEntity = Get(id) ?? throw new KeyNotFoundException("Id inválido ou inexistente. Processo: Update");

        var entity = BaseService<TBaseRepository, TInputCreate, TInputUpdate, TEntity, TOutput, TInputIdentifier>.UpdateEntity(FromOutputToEntity(oldEntity), inputUpdate);
        return _repository!.Update(entity ?? new TEntity());
    }

    protected static TEntity? UpdateEntity(TEntity oldEntity, TInputUpdate inputUpdate)
    {
        foreach (var property in typeof(TInputUpdate).GetProperties())
        {
            var correspondingProperty = typeof(TEntity).GetProperty(property.Name);
            if (correspondingProperty != null)
            {
                var value = property.GetValue(inputUpdate, null);

                correspondingProperty?.SetValue(oldEntity, value, null);
            }
        }
        return oldEntity;
    }
    #endregion

    #region Delete
    public virtual bool Delete(long id)
    {
        var entity = Get(id) ?? throw new KeyNotFoundException("Id inválido ou inexistente. Processo: Delete");
        _repository!.Delete(FromOutputToEntity(entity));
        return true;
    }
    #endregion

    #region Mapper
    public TOutput? FromEntityToOutput(TEntity entity)
    {
        return ApiData.Mapper.MapperEntityOutput.Map<TEntity, TOutput>(entity);
    }

    public List<TOutput>? FromEntityToOutput(List<TEntity> listEntity)
    {
        return ApiData.Mapper.MapperEntityOutput.Map<List<TEntity>, List<TOutput>>(listEntity);
    }

    public TEntity FromOutputToEntity(TOutput output)
    {
        return ApiData.Mapper.MapperEntityOutput.Map<TOutput, TEntity>(output);
    }

    public TEntity FromInputCreateToEntity(TInputCreate inputCreate)
    {
        return ApiData.Mapper.MapperInputEntity.Map<TInputCreate, TEntity>(inputCreate);
    }

    public TOutputClass CustomMapper<TInputClass, TOutputClass>(TInputClass output)
    {
        return ApiData.Mapper.MapperEntityOutput.Map<TInputClass, TOutputClass>(output);
    }
    #endregion
}