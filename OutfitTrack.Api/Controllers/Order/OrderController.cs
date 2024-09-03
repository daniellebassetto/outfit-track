using Microsoft.AspNetCore.Mvc;
using OutfitTrack.Arguments;
using OutfitTrack.Application.ApiManagement;
using OutfitTrack.Application.Interfaces;

namespace OutfitTrack.Api.Controllers;

[Route("api/[controller]")]
public class OrderController(IApiDataService apiDataService, IOrderService service) : BaseController<IOrderService, InputCreateOrder, InputUpdateOrder, OutputOrder, InputIdentifierOrder>(apiDataService, service) 
{
    [HttpPut("Close/{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<BaseResponseApi<bool>>> Close([FromRoute] long id)
    {
        try
        {
            var result = _service!.Close(id);
            return await ResponseAsync(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new BaseResponseApi<string> { ErrorMessage = "Item não encontrado." });
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
}