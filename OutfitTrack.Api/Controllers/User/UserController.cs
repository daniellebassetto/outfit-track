using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutfitTrack.Application.ApiManagement;
using OutfitTrack.Application.Interfaces;
using OutfitTrack.Arguments;

namespace OutfitTrack.Api.Controllers;

[Route("api/[controller]")]
public class UserController(IApiDataService apiDataService, IUserService service) : BaseController<IUserService, InputCreateUser, InputUpdateUser, OutputUser, InputIdentifierUser>(apiDataService, service)
{
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status400BadRequest)]
    public override async Task<ActionResult<BaseResponseApi<OutputUser>>> Create([FromBody] InputCreateUser inputCreate)
    {
        try
        {
            return await ResponseAsync(_service!.Create(inputCreate), 201);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPut("RedefinePassword/{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResponseApi<bool>>> RedefinePassword([FromRoute] long id, [FromBody] InputRedefinePasswordUser inputRedefinePassword)
    {
        try
        {
            var result = _service!.RedefinePassword(id, inputRedefinePassword);
            return await ResponseAsync(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new BaseResponseApi<string> { ErrorMessage = "Id inválido ou inexistente." });
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    #region IgnoreApi
    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponseApi<IEnumerable<OutputUser>>>> GetAll()
    {
        return base.GetAll();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponseApi<OutputUser>>> GetByIdentifier([FromBody] InputIdentifierUser inputIdentifier)
    {
        return base.GetByIdentifier(inputIdentifier);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponseApi<OutputUser>>> Get([FromRoute] long id)
    {
        return base.Get(id);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponseApi<bool>>> Delete([FromRoute] long id)
    {
        return base.Delete(id);
    }
    #endregion
}