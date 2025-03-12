namespace OutfitTrack.Application.Interfaces;

public interface IBaseService<TInputCreate, TInputUpdate, TOutput, TInputIdentifier>
   where TInputCreate : class
   where TInputUpdate : class
   where TOutput : class
   where TInputIdentifier : class
{
    IEnumerable<TOutput>? GetAll(int pageNumber, int pageSize);
    TOutput? Get(long id);
    TOutput? GetByIdentifier(TInputIdentifier inputIdentifier);
    TOutput? Create(TInputCreate entity);
    TOutput? Update(long id, TInputUpdate inputUpdate);
    bool Delete(long id);
}

#region AllParameters
public interface IBaseService_0 : IBaseService<object, object, object, object> { }
#endregion