namespace OutfitTrack.Domain.ApiManagement;

public class BaseSetProperty<TClass>
    where TClass : BaseSetProperty<TClass>
{
    public TClass SetProperty<T>(string propertyName, T propertyValue)
    {
        GetType().GetProperty(propertyName)?.SetValue(this, propertyValue);
        return (this as TClass)!;
    }
}