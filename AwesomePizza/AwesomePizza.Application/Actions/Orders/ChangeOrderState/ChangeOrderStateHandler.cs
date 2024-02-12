using AwesomePizza.Application.Abstractions.Repositories;
using AwesomePizza.Application.Actions.Orders.Common.CommonResponses;
using AwesomePizza.Application.Events;
using AwesomePizza.Models.Orders;
using MediatR;

namespace AwesomePizza.Application.Actions.Orders.ChangeOrderState;

public class ChangeOrderStateHandler(IOrderEventRepository orderEventRepository, IPublisher publisher)
{
    public async Task<ChangeOrderStateResponse> ChangeState(OrderId orderId, 
                                                            IEnumerable<OrderEventType> statesFromWhichIsAllowedToChange,
                                                            OrderEventType destinationState,
                                                            CancellationToken cancellationToken)
    {
        var lastEvent = await orderEventRepository.GetLastEventForOrder(orderId, cancellationToken);
        if (lastEvent is null)
            return new OrderNotFound(orderId);

        if (!statesFromWhichIsAllowedToChange.Contains(lastEvent.Type))
            return new OrderInWrongStateError(lastEvent.OrderId, lastEvent.Type);

        var completedEvent = lastEvent.ChangeState(destinationState);
        orderEventRepository.AddOrderEvent(completedEvent);
        await publisher.Publish(new OrderStateChanged(orderId), cancellationToken);
        return new ChangeOrderStateSuccesfully();
    }
}
