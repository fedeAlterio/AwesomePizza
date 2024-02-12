using AwesomePizza.Application.Abstractions;
using MediatR;

namespace AwesomePizza.Application.Events.Startup;
internal class ApplyMigrationsOnStartup(IDbContext appDbContext) : INotificationHandler<StartupEvent>
{
    public Task Handle(StartupEvent notification, CancellationToken cancellationToken) => appDbContext.ApplyMigrations(cancellationToken);
}
