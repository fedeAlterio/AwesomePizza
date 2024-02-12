using AwesomePizza.Application.PipelineBehaviors;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomePizza.Application.DependenciesInstallers;
public static class MediatRDependenciesInstaller
{
    public static MediatRServiceConfiguration AddApplicationMediatRBehaviors(this MediatRServiceConfiguration config)
    {
        return config.AddOpenBehavior(typeof(UnitOfWorkPipelineBehavior<,>));
    }
}
