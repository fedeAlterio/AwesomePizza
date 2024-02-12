using AwesomePizza.Application.Abstractions;
using AwesomePizza.Application.Actions.Menu.GetMenu;
using AwesomePizza.Web.Dto.Mappers;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AwesomePizza.Web.Endpoints.Menu.GetMenu;
public class GetMenuWebHandler(IRequestSender<GetMenuRequest, GetMenuResponse> menuRequestSender) : IRequestHandler<GetMenuWebRequest, Ok<GetMenuWebResponse>>
{
    public async Task<Ok<GetMenuWebResponse>> Handle(GetMenuWebRequest webRequest, CancellationToken cancellationToken)
    {
        var menuRequest = new GetMenuRequest();
        var response = await menuRequestSender.Send(menuRequest, cancellationToken);
        return TypedResults.Ok(new GetMenuWebResponse
        {
            Dishes = response.Dishes.Select(x => x.ToDto())
        });
    }
}
