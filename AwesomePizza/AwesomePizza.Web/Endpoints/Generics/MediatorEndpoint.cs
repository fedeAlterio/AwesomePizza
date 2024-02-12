using AwesomePizza.Application.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AwesomePizza.Web.Endpoints.Generics;

public static class MediatorEndpoint
{
    public static async Task<IResult> FromBody<TRequest>(
        [FromBody] TRequest? request,
        IRequestSender<TRequest, IResult> handler,
        CancellationToken cancellationToken)
        where TRequest : IRequest<IResult>
    {
        if (request == null)
            return TypedResults.BadRequest();
        
        var response = await handler.Send(request, cancellationToken);
        return response;
    }

    //public static async Task<TResponse> FromEmptyRequest<TRequest, TResponse>(
    //    IRequestSender<TRequest, TResponse> handler,
    //    CancellationToken cancellationToken)
    //    where TRequest : IRequest<TResponse>, new()
    //{
    //    TRequest request = new();
    //    var response = await handler.Send(request, cancellationToken);
    //    return response;
    //}
}
