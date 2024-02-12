using AwesomePizza.Application.Actions.Orders.ChangeOrderState;
using AwesomePizza.Models.Orders;
using MediatR;

namespace AwesomePizza.Application.Actions.Orders.RejectOrder;
internal class RejectOrderHandler(ChangeOrderStateHandler changeOrderStateHandler) : IRequestHandler<RejectOrderRequest, ChangeOrderStateResponse>
{
    public async Task<ChangeOrderStateResponse> Handle(RejectOrderRequest request, CancellationToken cancellationToken)
    {
        return await changeOrderStateHandler.ChangeState(request.OrderId,
                                                         [OrderEventType.Created],
                                                         OrderEventType.Rejected,
                                                         cancellationToken);
    }
}
