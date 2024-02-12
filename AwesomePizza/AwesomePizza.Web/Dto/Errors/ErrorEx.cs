using Microsoft.AspNetCore.Http.HttpResults;

namespace AwesomePizza.Web.Dto.Errors;

public static class ErrorEx
{
    public static ErrorResponse ToErrorResponse(this Error error) => new()
    {
        Errors = [error]
    };

    public static ErrorResponse ToErrorResponse(this IEnumerable<Error> errors) => new()
    {
        Errors = errors.ToList()
    };

    public static BadRequest<ErrorResponse> ToBadRequest(this ErrorResponse errorResponse) => TypedResults.BadRequest(errorResponse);
    public static NotFound<ErrorResponse> ToNotFound(this ErrorResponse errorResponse) => TypedResults.NotFound(errorResponse);
}