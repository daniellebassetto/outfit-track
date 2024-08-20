using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;
using OutfitTrack.Domain.Interfaces.Service;

namespace OutfitTrack.Domain.Services;

public class CustomerService(IUnitOfWork unitOfWork) : BaseService<ICustomerRepository, InputCreateCustomer, InputUpdateCustomer, Customer, OutputCustomer, InputIdentifierCustomer>(unitOfWork), ICustomerService { }