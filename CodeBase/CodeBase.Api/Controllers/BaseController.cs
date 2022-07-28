namespace CodeBase.Api.Controllers;

public class BaseController : Microsoft.AspNetCore.Mvc.ControllerBase
{
    protected Microsoft.AspNetCore.Mvc.IActionResult HandleException(Exception ex)
    {
        var errorCode = 500;

        var errorMessage =
            new CodeBase.Core.Exceptions.ErrorMessage(ex.Message,
                                                      CodeBase.Core.Resources.ExceptionErrorMessage.DevMessage500);

        if (ex is CodeBase.Core.Exceptions.ValidationException)
        {
            errorCode = 400;
            errorMessage.UserMsg = CodeBase.Core.Resources.ExceptionErrorMessage.UserMessage400;
            errorMessage.Data = ex.Data;
        }
        else
        {
            errorCode = 500;
            errorMessage.UserMsg = CodeBase.Core.Resources.ExceptionErrorMessage.UserMessage500;
        }

        return StatusCode(errorCode, errorMessage);
    }
}