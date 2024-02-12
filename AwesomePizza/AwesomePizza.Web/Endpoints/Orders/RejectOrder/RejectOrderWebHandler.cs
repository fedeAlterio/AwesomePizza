using AwesomePizza.Application.Abstractions;
using AwesomePizza.Application.Actions.Orders.ChangeOrderState;
using AwesomePizza.Application.Actions.Orders.RejectOrder;
using AwesomePizza.Web.Endpoints.Orders.Common;
using MediatR;

namespace AwesomePizza.Web.Endpoints.Orders.RejectOrder;
public class RejectOrderWebHandler(IRequestSender<RejectOrderRequest, ChangeOrderStateResponse> requestSender) : IRequestHandler<RejectOrderWebRequest, IResult>
{
    public async Task<IResult> Handle(RejectOrderWebRequest webRequest, CancellationToken cancellationToken)
    {
        var request = new RejectOrderRequest
        {
            OrderId = new(webRequest.OrderId!.Value)
        };

        var response = await requestSender.Send(request, cancellationToken);
        return response.ToResult();
    }
}
