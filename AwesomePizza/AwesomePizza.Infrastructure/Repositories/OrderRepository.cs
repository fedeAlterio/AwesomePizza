using AwesomePizza.Application.Abstractions.Repositories;
using AwesomePizza.Infrastructure.Persistence;
using AwesomePizza.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizza.Infrastructure.Repositories;

internal class OrderRepository(AppDbContext db) : IOrderRepository
{
    readonly AppDbContext _db = db;

    public void AddOrder(Order order)
    {
        _db.Orders.Add(order);
    }

    readonly IEnumerable<OrderEventType> _completedStates =
    [
        OrderEventType.Completed,
        OrderEventType.Rejected,
    ];

    void AddOrderEvent(OrderEvent orderEvent)
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

    public async Task<OrderSummary?> GetOrderSummary(OrderId orderId, CancellationToken cancellationToken)
    {
        var query = from order in _db.Orders.Include(x => x.Dishes).ThenInclude(x => x.Dish)
                    where order.Id == orderId
                    join orderEvent in _db.OrderEvents on order.Id equals orderEvent.OrderId
                    orderby orderEvent.DateUtc descending
                    select new OrderSummary
                    {
                        LastOrderEvent = orderEvent,
                        Order = order
                    };

        return await query.FirstOrDefaultAsync(cancellationToken);
    }
}