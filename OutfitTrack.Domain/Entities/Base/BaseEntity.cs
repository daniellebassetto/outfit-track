using Newtonsoft.Json;
using OutfitTrack.Domain.ApiManagement;

namespace OutfitTrack.Domain.Entities;

public class BaseEntity<TEntity> : BaseSetProperty<TEntity>
    where TEntity : BaseEntity<TEntity>
{
    [JsonIgnore] public virtual long? Id { get; set; }
    [JsonIgnore] public virtual DateTime? CreationDate { get; set; }
    [JsonIgnore] public virtual DateTime? ChangeDate { get; set; }

    public TEntity SetCreateData()
    {
        CreationDate = DateTime.Now;

        return (this as TEntity)!;
    }

    public TEntity SetUpdateData()
    {
        ChangeDate = DateTime.Now;

        return (this as TEntity)!;
    }
}