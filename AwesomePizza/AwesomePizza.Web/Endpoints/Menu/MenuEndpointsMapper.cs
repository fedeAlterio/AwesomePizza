using AwesomePizza.Web.Endpoints.Menu.AddDish;
using AwesomePizza.Web.Endpoints.Menu.GetMenu;

namespace AwesomePizza.Web.Endpoints.Menu;

public static class MenuEndpointsMapper
{
    public static RouteGroupBuilder MapMenuEndpoints(this RouteGroupBuilder endpoints, IServiceProvider services)
    {
        endpoints.MapGroup("menu")
                 .WithTags(["Menu"])
                 .MapEndpoint<GetMenuEndpoint>(services)
                 .MapEndpoint<AddDishEndpoint>(services);

        return endpoints;
    }
}
