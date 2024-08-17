namespace OutfitTrack.Domain.ApiManagement;

public interface IApiDataService
{
    Guid CreateApiDataRequest();
    void RemoveApiDataRequest(Guid guidApiDataRequest);
}