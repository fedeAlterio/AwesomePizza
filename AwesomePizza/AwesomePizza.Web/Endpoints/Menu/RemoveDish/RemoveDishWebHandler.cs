using AwesomePizza.Application.Abstractions;
using AwesomePizza.Application.Actions.Menu.RemoveDish;
using AwesomePizza.Web.Dto.Errors;
using AwesomePizza.Web.Endpoints.Orders.Common;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AwesomePizza.Web.Endpoints.Menu.RemoveDish;
public class RemoveDishWebHandler(IRequestSender<RemoveDishRequest, RemoveDishResponse> requestSender) : IRequestHandler<RemoveDishWebRequest, IResult>
{
    public async Task<IResult> Handle(RemoveDishWebRequest webRequest, CancellationToken cancellationToken)
    {
        var request = new RemoveDishRequest
        {
            DishId = new(webRequest.DishId!.Value)
        };
        var response = await requestSender.Send(request, cancellationToken);
        return response.Match<IResult>(_ => TypedResults.Ok(), dishNotFound => dishNotFound.SomeDishesDontExistResponse());
    }
}
