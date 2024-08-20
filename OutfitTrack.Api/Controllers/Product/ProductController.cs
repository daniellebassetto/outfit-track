using Microsoft.AspNetCore.Mvc;
using OutfitTrack.Arguments;
using OutfitTrack.Domain.ApiManagement;
using OutfitTrack.Domain.Interfaces.Service;

namespace OutfitTrack.Api.Controllers;

[Route("api/[controller]")]
public class ProductController(IApiDataService apiDataService, IProductService service) : BaseController<IProductService, InputCreateProduct, InputUpdateProduct, OutputProduct, InputIdentifierProduct>(apiDataService, service) { }