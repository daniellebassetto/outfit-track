using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;
using OutfitTrack.Domain.Interfaces.Service;

namespace OutfitTrack.Domain.Services;

public class CustomerService(ICustomerRepository repository) : BaseService<ICustomerRepository, InputCreateCustomer, InputUpdateCustomer, Customer, OutputCustomer, InputIdentifierCustomer>(repository), ICustomerService { }