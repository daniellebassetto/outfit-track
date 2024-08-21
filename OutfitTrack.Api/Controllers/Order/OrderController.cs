using Microsoft.AspNetCore.Mvc;
using OutfitTrack.Arguments;
using OutfitTrack.Application.ApiManagement;
using OutfitTrack.Application.Interfaces;

namespace OutfitTrack.Api.Controllers;

[Route("api/[controller]")]
public class OrderController(IApiDataService apiDataService, IOrderService service) : BaseController<IOrderService, InputCreateOrder, InputUpdateOrder, OutputOrder, InputIdentifierOrder>(apiDataService, service) { }