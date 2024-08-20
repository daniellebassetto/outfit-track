namespace OutfitTrack.Domain.Interfaces.Service;

public interface IBaseService<TInputCreate, TInputUpdate, TOutput, TInputIdentifier>
   where TInputCreate : class
   where TInputUpdate : class
   where TOutput : class
   where TInputIdentifier : class
{
    IEnumerable<TOutput>? GetAll();
    TOutput? Get(long id);
    TOutput? GetByIdentifier(TInputIdentifier inputIdentifier);
    TOutput? Create(TInputCreate entity);
    TOutput? Update(long id, TInputUpdate inputUpdate);
    bool Delete(long id);
}