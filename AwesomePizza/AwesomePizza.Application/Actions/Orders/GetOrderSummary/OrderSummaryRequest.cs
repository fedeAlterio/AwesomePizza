using AwesomePizza.Models.Orders;
using MediatR;

namespace AwesomePizza.Application.Actions.Orders.GetOrderSummary;
public class OrderSummaryRequest : IRequest<OrderSummaryResponse>
{
    public required OrderId OrderId { get; init; }
}
