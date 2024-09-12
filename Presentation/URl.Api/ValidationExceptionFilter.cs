using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FluentValidation;

public class ValidationExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ValidationException validationException)
        {
            var errorMessage = $"{validationException.Message}";

            context.Result = new BadRequestObjectResult(new
            {
                Message = errorMessage
            });

            context.ExceptionHandled = true;
        }
    }
}