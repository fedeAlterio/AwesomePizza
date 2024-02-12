using System.Transactions;
using AwesomePizza.Application.Actions.Abstractions;
using AwesomePizza.Application.Actions.Orders.ChangeOrderState;
using AwesomePizza.Models.Orders;
using MediatR;

namespace AwesomePizza.Application.Actions.Orders.RejectOrder;

[IsolationLevel(IsolationLevel.Serializable)]
public class RejectOrderRequest : IRequest<ChangeOrderStateResponse>, ICommand
{
    public required OrderId OrderId { get; init; }
}
