using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FinancialHandV2.Api.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception is ValidationException validation)
        {
            var modelState = new ModelStateDictionary();
            foreach(var error in validation.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return ValidationProblem(modelStateDictionary: modelState);
        }

        return Problem();
    }
}