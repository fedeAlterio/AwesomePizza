using AwesomePizza.Application.Actions.Orders.ChangeOrderState;
using AwesomePizza.Models.Orders;
using MediatR;

namespace AwesomePizza.Application.Actions.Orders.CompleteOrder;
internal class CompleteOrderHandler(ChangeOrderStateHandler orderStateChanger) : IRequestHandler<CompleteOrderRequest, ChangeOrderStateResponse>
{
    public async Task<ChangeOrderStateResponse> Handle(CompleteOrderRequest request, CancellationToken cancellationToken)
    {
        return await orderStateChanger.ChangeState(request.OrderId,
                                                   [OrderEventType.InProgress],
                                                   OrderEventType.Completed,
                                                   cancellationToken);
    }
}
