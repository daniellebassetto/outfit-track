namespace OutfitTrack.Application.ApiManagement;

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