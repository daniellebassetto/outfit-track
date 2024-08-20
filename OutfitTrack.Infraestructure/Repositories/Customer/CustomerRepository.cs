using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;

namespace OutfitTrack.Infraestructure.Repositories;

public class CustomerRepository(OutfitTrackContext context) : BaseRepository<Customer, InputIdentifierCustomer>(context), ICustomerRepository { }