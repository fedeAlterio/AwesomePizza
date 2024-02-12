using AwesomePizza.Application.Events;
using AwesomePizza.Web.Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace AwesomePizza.Web.DependenciesInstallers;

public class SignalRNotificationHandler(IHubContext<NotificationHub> hubContext) : INotificationHandler<OrderStateChanged>
{
    public async Task Handle(OrderStateChanged notification, CancellationToken cancellationToken)
    {
        await hubContext.Clients.Group(NotificationHub.GroupForOrder(notification.OrderId.Value)).SendAsync("Order Changed", notification.OrderId, cancellationToken: cancellationToken);
    }
}
