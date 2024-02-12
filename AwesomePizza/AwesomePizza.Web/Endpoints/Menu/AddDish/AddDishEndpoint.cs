using AwesomePizza.Web.Endpoints.Abstractions;
using AwesomePizza.Web.Endpoints.Generics;

namespace AwesomePizza.Web.Endpoints.Menu.AddDish;
public class AddDishEndpoint : IEndpoint
{
    public void MapEndpoint(RouteGroupBuilder endpoints)
    {
        endpoints
            .MapPost("/AddDish", MediatorEndpoint.FromBody<AddDishWebRequest>)
            .Produces<AddDishWebResponse>()
            .ProducesErrorResponseBadRequest();
    }
}
