using Microsoft.AspNetCore.Mvc;
using OutfitTrack.Arguments;
using OutfitTrack.Domain.ApiManagement;
using OutfitTrack.Domain.Interfaces.Service;

namespace OutfitTrack.Api.Controllers;

[Route("api/[controller]")]
public class CustomerController(IApiDataService apiDataService, ICustomerService service) : BaseController<ICustomerService, InputCreateCustomer, InputUpdateCustomer, OutputCustomer, InputIdentifierCustomer>(apiDataService, service) { }