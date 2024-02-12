using AwesomePizza.Application.Abstractions.Repositories;
using AwesomePizza.Infrastructure.Persistence;
using AwesomePizza.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizza.Infrastructure.Repositories;

internal class OrderEventRepository(AppDbContext db) : IOrderEventRepository
{
    readonly AppDbContext _db = db;
    readonly IEnumerable<OrderEventType> _completedStates =
    [
        OrderEventType.Completed,
        OrderEventType.Rejected,
    ];

    public void AddOrderEvent(OrderEvent orderEvent)
    {
        _db.OrderEvents.Add(orderEvent);
    }

    public async Task<OrderEvent?> GetLastOrderToBeCompleted(CancellationToken cancellationToken)
    {
        var completedStates = _completedStates;
        var ordersCompletedOrRejected = _db.OrderEvents
                                           .Where(x => completedStates.Contains(x.Type))
                                           .Select(x => x.OrderId);

        var ordersQueue = from orderEvent in _db.OrderEvents
                          where !ordersCompletedOrRejected.Contains(orderEvent.OrderId)
                          orderby orderEvent.Type descending, orderEvent.DateUtc
                          select orderEvent;

        return await ordersQueue.FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task<OrderEvent?> GetLastEventForOrder(OrderId orderId, CancellationToken cancellationToken)
    {
        return await _db.OrderEvents
                        .Where(orderEvent => orderEvent.OrderId == orderId)
                        .OrderByDescending(orderEvent => orderEvent.DateUtc)
                        .FirstOrDefaultAsync(cancellationToken);
    }
}