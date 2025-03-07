using Microsoft.AspNetCore.Mvc;
using OutfitTrack.Application.ApiManagement;
using OutfitTrack.Application.Interfaces;
using OutfitTrack.Arguments;

namespace OutfitTrack.Api.Controllers;

[Route("api/[controller]")]
public class ProductController(IApiDataService apiDataService, IProductService service) : BaseController<IProductService, InputCreateProduct, InputUpdateProduct, OutputProduct, InputIdentifierProduct>(apiDataService, service) { }