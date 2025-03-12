using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User, InputIdentifierUser> { }