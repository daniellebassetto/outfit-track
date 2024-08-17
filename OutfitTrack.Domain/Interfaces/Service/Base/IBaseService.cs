namespace OutfitTrack.Domain.Interfaces.Service;

public interface IBaseService<TInputCreate, TInputUpdate, TOutput, TInputIdentifier>
{
    List<TOutput>? GetAll();
    TOutput? Get(long id);
    TOutput? GetByIdentifier(TInputIdentifier inputIdentifier);
    long? Create(TInputCreate entity);
    long? Update(long id, TInputUpdate inputUpdate);
    bool Delete(long id);
}