using AwesomePizza.Application.Abstractions.Repositories;
using AwesomePizza.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomePizza.Infrastructure.DependenciesInstallers;
internal static class RepositoriesInstaller
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddDbRepositories();
    }

    static void AddDbRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDishRepository, DishRepository>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IOrderEventRepository, OrderEventRepository>();
    }
}
