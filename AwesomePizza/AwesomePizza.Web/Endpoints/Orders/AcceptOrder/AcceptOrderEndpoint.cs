using AwesomePizza.Web.Endpoints.Abstractions;
using AwesomePizza.Web.Endpoints.Generics;

namespace AwesomePizza.Web.Endpoints.Orders.AcceptOrder;
public class AcceptOrderEndpoint : IEndpoint
{
    public void MapEndpoint(RouteGroupBuilder endpoints)
    {
        endpoints
            .MapPost(@"/AcceptOrder", MediatorEndpoint.FromBody<AcceptOrderWebRequest>)
            .ProducesOk()
            .ProducesErrorResponseBadRequest();
    }
}
