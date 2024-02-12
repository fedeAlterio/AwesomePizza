using AwesomePizza.Application.Abstractions;
using AwesomePizza.Application.Actions.Orders.GetOrderSummary;
using AwesomePizza.Web.Dto.Mappers;
using AwesomePizza.Web.Endpoints.Orders.Common;
using MediatR;

namespace AwesomePizza.Web.Endpoints.Orders.GetOrderSummary;
public class OrderSummaryWebHandler(IRequestSender<OrderSummaryRequest, OrderSummaryResponse> requestSender) : IRequestHandler<OrderSummaryWebRequest, IResult>
{
    public async Task<IResult> Handle(OrderSummaryWebRequest webRequest, CancellationToken cancellationToken)
    {
        var request = new OrderSummaryRequest
        {
            OrderId = new(webRequest.OrderId!.Value)
        };

        var response = await requestSender.Send(request, cancellationToken);
        return response.Match<IResult>(summary => TypedResults.Ok(summary.ToDto()), notFound => notFound.ToNotFound());
    }
}
