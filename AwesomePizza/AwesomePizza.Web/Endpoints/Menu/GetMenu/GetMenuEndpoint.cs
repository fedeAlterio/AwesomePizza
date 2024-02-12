using AwesomePizza.Application.Abstractions;
using AwesomePizza.Web.Endpoints.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AwesomePizza.Web.Endpoints.Menu.GetMenu;
public class GetMenuEndpoint : IEndpoint
{
    public void MapEndpoint(RouteGroupBuilder endpoints)
    {
        endpoints
            .MapGet("/", (IRequestSender<GetMenuWebRequest, Ok<GetMenuWebResponse>> sender, CancellationToken cancellationToken) => sender.Send(new(), cancellationToken));
    }
}
