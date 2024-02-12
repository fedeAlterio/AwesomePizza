using AwesomePizza.Web.Endpoints.Abstractions;
using AwesomePizza.Web.Endpoints.Menu;
using AwesomePizza.Web.Endpoints.Orders;

namespace AwesomePizza.Web.Endpoints;

public static class EndpointMapper
{
    public static void MapEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var root = endpoints.MapGroup("")
                            .WithOpenApi();
        
        var services = endpoints.ServiceProvider;

        root.MapMenuEndpoints(services)
            .MapOrdersEndpoints(services);
    }

    internal static RouteGroupBuilder MapEndpoint<TEndpoint>(this RouteGroupBuilder @this, IServiceProvider serviceProvider) where TEndpoint : IEndpoint
    {
        var endpoint = ActivatorUtilities.CreateInstance<TEndpoint>(serviceProvider);
        endpoint.MapEndpoint(@this);
        return @this;
    }
}
