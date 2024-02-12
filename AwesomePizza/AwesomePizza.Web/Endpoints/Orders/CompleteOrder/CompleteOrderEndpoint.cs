using AwesomePizza.Web.Endpoints.Abstractions;
using AwesomePizza.Web.Endpoints.Generics;

namespace AwesomePizza.Web.Endpoints.Orders.CompleteOrder;
public class CompleteOrderEndpoint : IEndpoint
{
    public void MapEndpoint(RouteGroupBuilder endpoints)
    {
        endpoints
            .MapPost(@"/CompleteOrder", MediatorEndpoint.FromBody<CompleteOrderWebRequest>)
            .WithName("CompleteOrder");
    }
}
