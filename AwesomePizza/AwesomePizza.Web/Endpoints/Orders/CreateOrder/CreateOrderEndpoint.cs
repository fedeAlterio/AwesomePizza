using AwesomePizza.Web.Endpoints.Abstractions;
using AwesomePizza.Web.Endpoints.Generics;

namespace AwesomePizza.Web.Endpoints.Orders.CreateOrder;
public class CreateOrderEndpoint : IEndpoint
{
    public void MapEndpoint(RouteGroupBuilder endpoints)
    {
        endpoints
            .MapPost(@"/CreateOrder", MediatorEndpoint.FromBody<CreateOrderWebRequest>)
            .ProducesOk()
            .ProducesErrorResponseBadRequest();
    }
}
