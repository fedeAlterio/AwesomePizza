using AwesomePizza.Application.Abstractions;
using AwesomePizza.Application.Actions.Orders.ChangeOrderState;
using AwesomePizza.Application.Actions.Orders.CompleteOrder;
using AwesomePizza.Web.Endpoints.Orders.Common;
using MediatR;

namespace AwesomePizza.Web.Endpoints.Orders.CompleteOrder;
public class CompleteOrderWebHandler(IRequestSender<CompleteOrderRequest, ChangeOrderStateResponse> requestSender) : IRequestHandler<CompleteOrderWebRequest, IResult>
{
    public async Task<IResult> Handle(CompleteOrderWebRequest webRequest, CancellationToken cancellationToken)
    {
        var request = new CompleteOrderRequest
        {
            OrderId = new(webRequest.OrderId!.Value)
        };

        var response = await requestSender.Send(request, cancellationToken);
        return response.ToResult();
    }
}
