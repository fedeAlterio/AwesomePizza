using AwesomePizza.Application.Abstractions;
using AwesomePizza.Application.Actions.Orders.AcceptOrder;
using AwesomePizza.Application.Actions.Orders.ChangeOrderState;
using AwesomePizza.Web.Endpoints.Orders.Common;
using MediatR;

namespace AwesomePizza.Web.Endpoints.Orders.AcceptOrder;
public class AcceptOrderWebHandler(IRequestSender<AcceptOrderRequest, ChangeOrderStateResponse> requestSender) : IRequestHandler<AcceptOrderWebRequest, IResult>
{
    public async Task<IResult> Handle(AcceptOrderWebRequest webRequest, CancellationToken cancellationToken)
    {
        var request = new AcceptOrderRequest
        {
            OrderId = new(webRequest.OrderId!.Value)
        };

        var response = await requestSender.Send(request, cancellationToken);
        return response.ToResult();
    }
}
