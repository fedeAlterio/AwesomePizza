using AwesomePizza.Application.Abstractions;
using AwesomePizza.Web.Dto.Errors;
using FluentValidation;
using MediatR;

namespace AwesomePizza.Web.PipelineBehaviors;
public class ValidationPipelineBehavior<TRequest, TResponse>(IOptionalDependency<IValidator<TRequest>> validatorOptional) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull where TResponse : IResult
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (typeof(TResponse) != typeof(IResult) || validatorOptional.Value is null)
            return await next();

        var validationResult = await validatorOptional.Value.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var badRequest = validationResult.Errors
                                             .Select(x => Error.FieldValidation(x.ErrorMessage))
                                             .ToErrorResponse()
                                             .ToBadRequest();

            return (TResponse) (IResult) badRequest;
        }

        return await next();
    }
}
