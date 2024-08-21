using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Domain.Interfaces;

public interface ICustomerRepository : IBaseRepository<Customer, InputIdentifierCustomer> { }