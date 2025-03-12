using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces;

namespace OutfitTrack.Infraestructure.Repositories;

public class UserRepository(OutfitTrackContext context) : BaseRepository<User, InputIdentifierUser>(context), IUserRepository { }