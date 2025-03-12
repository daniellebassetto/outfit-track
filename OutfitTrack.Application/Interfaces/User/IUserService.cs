using OutfitTrack.Arguments;

namespace OutfitTrack.Application.Interfaces;

public interface IUserService : IBaseService<InputCreateUser, InputUpdateUser, OutputUser, InputIdentifierUser> 
{
    void UpdateTokenExpirationDate(long id);
    bool RedefinePassword(long id, InputRedefinePasswordUser inputRedefinePassword);
}