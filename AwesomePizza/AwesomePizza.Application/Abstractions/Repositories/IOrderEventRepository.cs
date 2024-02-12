using AwesomePizza.Models.Orders;

namespace AwesomePizza.Application.Abstractions.Repositories;

public interface IOrderEventRepository
{
    void AddOrderEvent(OrderEvent orderEvent);
    Task<OrderEvent?> GetLastOrderToBeCompleted(CancellationToken cancellationToken);
    Task<OrderEvent?> GetLastEventForOrder(OrderId orderId, CancellationToken cancellationToken);
}
