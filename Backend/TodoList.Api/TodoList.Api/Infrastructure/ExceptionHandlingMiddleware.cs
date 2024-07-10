using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;
using TodoList.Api.Services;

namespace TodoList.Api.Infrastructure;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, ProblemDetailsFactory problemDetailsFactory)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unhandled exception has occurred.");

            var details = ex switch
            {
                ITodoItemProblem problem => problemDetailsFactory.CreateProblemDetails(httpContext, problem.Status, problem.Title, null, problem.Detail),
                ValidationException validationException => problemDetailsFactory.CreateProblemDetails(httpContext, StatusCodes.Status400BadRequest, "Bad Request", null, validationException.ValidationResult.ErrorMessage),
                _ => problemDetailsFactory.CreateProblemDetails(httpContext, StatusCodes.Status500InternalServerError, "Internal Server Error", null, ex.Message)
            };

            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = details.Status!.Value;

            await httpContext.Response.WriteAsJsonAsync(details);
        }
    }
}