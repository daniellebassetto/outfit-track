using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OutfitTrack.Domain.ApiManagement;
using OutfitTrack.Domain.Interfaces.Service;

namespace OutfitTrack.Api.Controllers;

[ApiController]
public class BaseController<TIService, TInputCreate, TInputUpdate, TOutput, TInputIdentifier> : Controller
    where TIService : IBaseService<TInputCreate, TInputUpdate, TOutput, TInputIdentifier>
    where TInputCreate : class
    where TInputUpdate : class
    where TOutput : class
    where TInputIdentifier : class
{
    protected readonly IApiDataService? _apiDataService;
    public Guid _guidApiDataRequest;
    public TIService? _service;

    public BaseController(IApiDataService apiDataService, TIService service)
    {
        _apiDataService = apiDataService;
        _service = service;
    }

    public BaseController(IApiDataService apiDataService)
    {
        _apiDataService = apiDataService;
    }

    #region Read
    [HttpGet]
    public virtual async Task<ActionResult<BaseResponseApi<IEnumerable<TOutput>>>> GetAll()
    {
        try
        {
            return await ResponseAsync(_service!.GetAll());
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpGet("{id:long}")]
    public virtual async Task<ActionResult<BaseResponseApi<TOutput>>> Get(long id)
    {
        try
        {
            return await ResponseAsync(_service!.Get(id));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("GetByIdentifier")]
    public virtual async Task<ActionResult<BaseResponseApi<TOutput>>> GetByIdentifier(TInputIdentifier inputIdentifier)
    {
        try
        {
            return await ResponseAsync(_service!.GetByIdentifier(inputIdentifier));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
    #endregion

    #region Create
    [HttpPost]
    public virtual async Task<ActionResult<BaseResponseApi<TOutput>>> Create(TInputCreate inputCreate)
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
    #endregion

    #region Update
    [HttpPut("{id:long}")]
    public virtual async Task<ActionResult<BaseResponseApi<TOutput>>> Update(long id, TInputUpdate inputUpdate)
    {
        try
        {
            return await ResponseAsync(_service!.Update(id, inputUpdate));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
    #endregion

    #region Delete
    [HttpDelete("{id}")]
    public virtual async Task<ActionResult<BaseResponseApi<bool>>> Delete(long id)
    {
        try
        {
            return await ResponseAsync(_service?.Delete(id));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
    #endregion

    [NonAction]
    public async Task<ActionResult> ResponseAsync<ResponseType>(ResponseType result, int statusCode = 0)
    {
        try
        {
            return await Task.FromResult(StatusCode(statusCode == 0 ? 200 : statusCode, new BaseResponseApi<ResponseType> { Result = result }));
        }
        catch (Exception ex)
        {
            return await Task.FromResult(BadRequest(new BaseResponseApi<string> { ErrorMessage = $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}" }));
        }
    }

    [NonAction]
    public async Task<ActionResult> ResponseExceptionAsync(Exception ex)
    {
        return await Task.FromResult(BadRequest(new BaseResponseApi<string> { ErrorMessage = ex.Message }));
    }

    [NonAction]
    public void SetData()
    {
        Guid guidApiDataRequest = ApiData.CreateApiDataRequest();
        SetGuid(guidApiDataRequest);
    }

    [NonAction]
    public void SetGuid(Guid guidApiDataRequest)
    {
        _guidApiDataRequest = guidApiDataRequest;
        GenericModule.SetGuidApiDataRequest(this, guidApiDataRequest);
    }

    [NonAction]
    public override async void OnActionExecuting(ActionExecutingContext context)
    {
        try
        {
            SetData();
        }
        catch (Exception ex)
        {
            context.Result = await ResponseExceptionAsync(ex);
        }
    }
}