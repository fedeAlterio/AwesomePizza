using AwesomePizza.Application.Abstractions;
using AwesomePizza.Web.Endpoints.Abstractions;

namespace AwesomePizza.Web.Endpoints.Orders.LastOrderToBeCompleted;
public class LastOrderToBeCompletedEndpoint : IEndpoint
{
    public void MapEndpoint(RouteGroupBuilder endpoints)
    {
        endpoints
            .MapGet(@"/Current", (IRequestSender<LastOrderToBeCompletedWebRequest, IResult> sender, CancellationToken cancellationToken) => sender.Send(new(), cancellationToken))
            .Produces<LastOrderToBeCompletedWebResponse>();
    }
}
