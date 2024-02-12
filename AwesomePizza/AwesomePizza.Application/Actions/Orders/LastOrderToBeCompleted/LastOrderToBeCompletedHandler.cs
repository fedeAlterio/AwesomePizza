using AwesomePizza.Application.Abstractions.Repositories;
using MediatR;

namespace AwesomePizza.Application.Actions.Orders.LastOrderToBeCompleted;
public class LastOrderToBeCompletedHandler(IOrderEventRepository orderEventRepository) : IRequestHandler<LastOrderToBeCompletedRequest, LastOrderToBeCompletedResponse>
{
    public async Task<LastOrderToBeCompletedResponse> Handle(LastOrderToBeCompletedRequest request, CancellationToken cancellationToken)
    {
        var lastOrder = await orderEventRepository.GetLastOrderToBeCompleted(cancellationToken);
        return lastOrder is null
            ? new LastOrderToBeCompletedNotFound()
            : new LastOrderToBeCompletedInfo
            {
                LastOrderEvent = lastOrder
            };
    }
}
