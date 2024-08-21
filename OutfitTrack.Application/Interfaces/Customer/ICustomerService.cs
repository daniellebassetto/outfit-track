using OutfitTrack.Arguments;

namespace OutfitTrack.Application.Interfaces;

public interface ICustomerService : IBaseService<InputCreateCustomer, InputUpdateCustomer, OutputCustomer, InputIdentifierCustomer> { }