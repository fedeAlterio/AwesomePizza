namespace AwesomePizza.Web.Endpoints.Abstractions;

public interface IEndpoint
{
    void MapEndpoint(RouteGroupBuilder endpoints);
}
