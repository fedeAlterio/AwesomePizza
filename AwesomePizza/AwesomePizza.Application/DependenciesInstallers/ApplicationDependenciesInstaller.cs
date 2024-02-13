using AwesomePizza.Application.Abstractions;
using AwesomePizza.Application.Actions.Orders.ChangeOrderState;
using AwesomePizza.Application.Events.Helpers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomePizza.Application.DependenciesInstallers;
public static class ApplicationDependenciesInstaller
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRequestSender<,>), typeof(MediatRRequestSender<,>));
        services.AddTransient(typeof(IOptionalDependency<>), typeof(OptionalDependency<>));
        services.AddScoped<ChangeOrderStateHandler>();
        services.AddScoped<EventAggregator>();
    }

    class OptionalDependency<T>(IServiceProvider services) : IOptionalDependency<T>
    {
        public T? Value { get; } = services.GetService<T>();
    }
             
    class MediatRRequestSender<TRequest, TResponse>(ISender mediator) : IRequestSender<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public Task<TResponse> Send(TRequest request, CancellationToken cancellationToken = default)
            => mediator.Send(request, cancellationToken);
    }
}
