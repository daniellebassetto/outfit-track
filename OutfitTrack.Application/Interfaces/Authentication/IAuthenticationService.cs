using OutfitTrack.Arguments;

namespace OutfitTrack.Application.Interfaces;

public interface IAuthenticationService : IBaseService_0
{
    OutputAuthentication? Authenticate(InputAuthentication inputAuthentication);
}