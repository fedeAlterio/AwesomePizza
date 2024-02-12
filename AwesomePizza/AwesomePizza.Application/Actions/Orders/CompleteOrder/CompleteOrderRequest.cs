using System.Transactions;
using AwesomePizza.Application.Actions.Abstractions;
using AwesomePizza.Application.Actions.Orders.ChangeOrderState;
using AwesomePizza.Models.Orders;
using MediatR;

namespace AwesomePizza.Application.Actions.Orders.CompleteOrder;

[IsolationLevel(IsolationLevel.Serializable)]
public class CompleteOrderRequest : IRequest<ChangeOrderStateResponse>, ICommand
{
    public required OrderId OrderId { get; init; }
}
