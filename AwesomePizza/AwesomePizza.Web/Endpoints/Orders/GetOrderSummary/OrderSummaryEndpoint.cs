using AwesomePizza.Application.Abstractions;
using AwesomePizza.Web.Endpoints.Abstractions;
using AwesomePizza.Web.Endpoints.Generics;

namespace AwesomePizza.Web.Endpoints.Orders.GetOrderSummary;
public class OrderSummaryEndpoint : IEndpoint
{
    public void MapEndpoint(RouteGroupBuilder endpoints)
    {
        endpoints
            .MapGet(@"/summary/{orderId:guid}", (Guid orderId, 
                                                      IRequestSender<OrderSummaryWebRequest, IResult> handler,
                                                      CancellationToken cancellationToken) =>
            {
                var request = new OrderSummaryWebRequest
                {
                    OrderId = orderId
                };

                return handler.Send(request, cancellationToken);
            })
            .Produces<OrderSummaryWebResponse>()
            .ProducesErrorResponseBadRequest();
    }
}
