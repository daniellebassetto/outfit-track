namespace OutfitTrack.Domain.ApiManagement;

public class ApiDataService : IApiDataService
{
    public Guid CreateApiDataRequest()
    {
        return ApiData.CreateApiDataRequest();
    }

    public void RemoveApiDataRequest(Guid guidApiDataRequest)
    {
        ApiData.RemoveApiDataRequest(guidApiDataRequest);
    }
}