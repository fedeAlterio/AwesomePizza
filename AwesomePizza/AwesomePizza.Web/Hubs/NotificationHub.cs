using AwesomePizza.Models.Orders;
using Microsoft.AspNetCore.SignalR;

namespace AwesomePizza.Web.Hubs;

public class NotificationHub : Hub
{
    public static string GroupForOrder(Guid orderId) => orderId.ToString();
    public async Task SubscribeOrdrStateChanged(Guid orderId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, GroupForOrder(orderId));
    }
}
