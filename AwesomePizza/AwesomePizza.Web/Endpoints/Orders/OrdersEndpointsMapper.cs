using AwesomePizza.Web.Endpoints.Orders.AcceptOrder;
using AwesomePizza.Web.Endpoints.Orders.CompleteOrder;
using AwesomePizza.Web.Endpoints.Orders.CreateOrder;
using AwesomePizza.Web.Endpoints.Orders.GetOrderSummary;
using AwesomePizza.Web.Endpoints.Orders.LastOrderToBeCompleted;
using AwesomePizza.Web.Endpoints.Orders.RejectOrder;

namespace AwesomePizza.Web.Endpoints.Orders;

public static class OrdersEndpointsMapper
{
    public static RouteGroupBuilder MapOrdersEndpoints(this RouteGroupBuilder endpoints, IServiceProvider services)
    {
        endpoints.MapGroup("orders")
                 .WithTags(["Orders"])
                 .MapEndpoint<CreateOrderEndpoint>(services)
                 .MapEndpoint<LastOrderToBeCompletedEndpoint>(services)
                 .MapEndpoint<AcceptOrderEndpoint>(services)
                 .MapEndpoint<RejectOrderEndpoint>(services)
                 .MapEndpoint<CompleteOrderEndpoint>(services)
                 .MapEndpoint<OrderSummaryEndpoint>(services);

        return endpoints;
    }
}
