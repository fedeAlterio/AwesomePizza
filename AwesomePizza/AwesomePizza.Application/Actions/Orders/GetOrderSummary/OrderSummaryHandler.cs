using AwesomePizza.Application.Abstractions.Repositories;
using AwesomePizza.Application.Actions.Orders.Common.CommonResponses;
using MediatR;

namespace AwesomePizza.Application.Actions.Orders.GetOrderSummary;
public class OrderSummaryHandler(IOrderRepository orderRepository) : IRequestHandler<OrderSummaryRequest, OrderSummaryResponse>
{
    public async Task<OrderSummaryResponse> Handle(OrderSummaryRequest request, CancellationToken cancellationToken)
    {
        var summary = await orderRepository.GetOrderSummary(request.OrderId, cancellationToken);
        return summary is null ? new OrderNotFound(request.OrderId)
                               : summary;
    }
}
