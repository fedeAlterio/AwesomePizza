using AwesomePizza.Web.Endpoints.Abstractions;
using AwesomePizza.Web.Endpoints.Generics;

namespace AwesomePizza.Web.Endpoints.Orders.RejectOrder;
public class RejectOrderEndpoint : IEndpoint
{
    public void MapEndpoint(RouteGroupBuilder endpoints)
    {
        endpoints
            .MapPost(@"/RejectOrder", MediatorEndpoint.FromBody<RejectOrderWebRequest>)
            .ProducesOk()
            .ProducesErrorResponseBadRequest();
    }
}
