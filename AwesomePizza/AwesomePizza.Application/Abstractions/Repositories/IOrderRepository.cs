using AwesomePizza.Models.Orders;

namespace AwesomePizza.Application.Abstractions.Repositories;

public interface IOrderRepository
{
    void AddOrder(Order order);
    Task<OrderSummary?> GetOrderSummary(OrderId orderId, CancellationToken cancellationToken);
}