namespace AwesomePizza.Web.Dto.Errors;

public class ErrorResponse
{
    public required IReadOnlyList<Error> Errors { get; init; }
}