using OutfitTrack.Arguments;

namespace OutfitTrack.Domain.Interfaces.Service;

public interface ICustomerService : IBaseService<InputCreateCustomer, InputUpdateCustomer, OutputCustomer, InputIdentifierCustomer> { }