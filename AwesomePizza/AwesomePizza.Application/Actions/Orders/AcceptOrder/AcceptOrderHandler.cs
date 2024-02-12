using AwesomePizza.Application.Actions.Orders.ChangeOrderState;
using AwesomePizza.Models.Orders;
using MediatR;

namespace AwesomePizza.Application.Actions.Orders.AcceptOrder;
internal class AcceptOrderHandler(ChangeOrderStateHandler orderStateChanger) : IRequestHandler<AcceptOrderRequest, ChangeOrderStateResponse>
{
    public async Task<ChangeOrderStateResponse> Handle(AcceptOrderRequest request, CancellationToken cancellationToken)
    {
        return await orderStateChanger.ChangeState(request.OrderId, 
                                                   [OrderEventType.Created],
                                                   OrderEventType.InProgress, 
                                                   cancellationToken);
    }
}
