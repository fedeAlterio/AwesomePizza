using AwesomePizza.Application.DependenciesInstallers;
using AwesomePizza.Web.PipelineBehaviors;
using MediatR.NotificationPublishers;

namespace AwesomePizza.Web.DependenciesInstallers;

public static class MediatRInstaller
{
    public static void AddMediatRDependencies(this IServiceCollection services)
    {
        services.AddMediatR(x =>
        {
            x.NotificationPublisher = new ForeachAwaitPublisher();
            x.RegisterServicesFromAssemblies(typeof(IAssemblyMarker).Assembly,
                                             typeof(Application.IAssemblyMarker).Assembly);
            x.AddApplicationMediatRBehaviors()
             .AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });
    }
}
