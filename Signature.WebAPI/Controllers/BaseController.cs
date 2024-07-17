using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SignatureCommon.Models.JsonResponseModels;
using static SignatureCommon.Enums;

namespace Signature.WebAPI.Controllers;

public class BaseController : Controller
{
    private IMediator mediator;

    public BaseController(IMediator mediator)
    {
        this.mediator = mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }

    protected virtual IActionResult CreateJsonOk(string message = null, bool showToast = false)
    {
        return Json(new BaseJsonResponse { Result = ExecutionResult.OK, Message = message, ShowToast = showToast });
    }

    protected virtual IActionResult CreateJsonOk<T>(T record, string message = null, bool showToast = false) where T : class
    {
        return Json(new SingleJsonResponse<T> { Result = ExecutionResult.OK, Message = message, ShowToast = showToast, Item = record });
    }

    protected virtual IActionResult CreateJsonOk<T>(IEnumerable<T> records, string message = null, bool showToast = false) where T : class
    {
        return Json(new CollectionJsonResponse<T> { Result = ExecutionResult.OK, Message = message, ShowToast = showToast, Items = records });
    }

    protected virtual IActionResult CreateJsonKo(string message = null)
    {
        return Json(new BaseJsonResponse { Result = ExecutionResult.KO, Message = message });
    }

    protected virtual IActionResult CreateJsonNotValid(ModelStateDictionary keyValuePairs, bool showToast = false)
    {
        Dictionary<string, string> errors = new();

        foreach (var item in keyValuePairs)
        {
            if (item.Value.ValidationState == ModelValidationState.Invalid)
            {
                errors.Add(item.Key, string.Join("\n", item.Value.Errors.Select(x => x.ErrorMessage)));
            }
        }

        return Json(new ValidationJsonResponse { Result = ExecutionResult.NOTVALID, Message = "One or more validation errors occurred.", Errors = errors, ShowToast = showToast });
    }

    protected virtual IActionResult CreateJsonError(string message = null)
    {
        return Json(new BaseJsonResponse { Result = ExecutionResult.ERROR, Message = message });
    }

    protected virtual IActionResult CreateJsonException(Exception exception)
    {
        return Json(new ExceptionJsonResponse { Message = exception.Message, StackTrace = exception.StackTrace });
    }
}
