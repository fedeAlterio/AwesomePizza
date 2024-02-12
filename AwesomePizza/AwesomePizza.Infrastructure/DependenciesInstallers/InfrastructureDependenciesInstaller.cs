using AwesomePizza.Application.Abstractions;
using AwesomePizza.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomePizza.Infrastructure.DependenciesInstallers;

public static class InfrastructureDependenciesInstaller
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddScoped<IDbContext>(x => x.GetRequiredService<AppDbContext>());
        services.AddDbContextPool<AppDbContext>(x => x.UseNpgsql(configuration.GetConnectionString("DefaultConnection") 
                                                                         ?? throw new InvalidOperationException("Connection to database not configured")));
    }
}