using System.Net;
using AwesomePizza.Models.Exceptions;

namespace AwesomePizza.Web.Middlewares;

public static class GlobalExceptionHandler 
{
    public static async Task Handle(HttpContext httpContext, Func<Task> next)
    {
        try
        {
            await next();
        }
        catch (ModelValidationException)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        catch
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
