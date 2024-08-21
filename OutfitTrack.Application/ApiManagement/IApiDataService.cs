namespace OutfitTrack.Application.ApiManagement;

public interface IApiDataService
{
    Guid CreateApiDataRequest();
    void RemoveApiDataRequest(Guid guidApiDataRequest);
}