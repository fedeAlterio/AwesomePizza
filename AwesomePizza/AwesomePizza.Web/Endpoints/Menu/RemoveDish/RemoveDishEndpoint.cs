using AwesomePizza.Web.Endpoints.Abstractions;
using AwesomePizza.Web.Endpoints.Generics;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AwesomePizza.Web.Endpoints.Menu.RemoveDish;
public class RemoveDishEndpoint : IEndpoint
{
    public void MapEndpoint(RouteGroupBuilder endpoints)
    {
        endpoints
            .MapPost(@"/RemoveDish", MediatorEndpoint.FromBody<RemoveDishWebRequest>)
            .Produces<Ok>()
            .ProducesErrorResponseBadRequest();
    }
}
