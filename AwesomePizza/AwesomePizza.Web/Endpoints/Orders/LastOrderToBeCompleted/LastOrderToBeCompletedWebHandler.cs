using AwesomePizza.Application.Abstractions;
using AwesomePizza.Application.Actions.Orders.LastOrderToBeCompleted;
using AwesomePizza.Web.Dto.Mappers;
using MediatR;

namespace AwesomePizza.Web.Endpoints.Orders.LastOrderToBeCompleted;
public class LastOrderToBeCompletedWebHandler(IRequestSender<LastOrderToBeCompletedRequest, LastOrderToBeCompletedResponse> requestSender) : IRequestHandler<LastOrderToBeCompletedWebRequest, IResult>
{
    public async Task<IResult> Handle(LastOrderToBeCompletedWebRequest webRequest, CancellationToken cancellationToken)
    {
        var request = new LastOrderToBeCompletedRequest();
        var response = await requestSender.Send(request, cancellationToken);
        return TypedResults.Ok(response.Match(LastOrderFoundResponse, LastOrderNotFoundResponse));
    }

    LastOrderToBeCompletedWebResponse LastOrderNotFoundResponse(LastOrderToBeCompletedNotFound _) => 
        LastOrderToBeCompletedWebResponse.Empty;
    LastOrderToBeCompletedWebResponse LastOrderFoundResponse(LastOrderToBeCompletedInfo info) => new ()
    {
        OrderEvent = info.LastOrderEvent.ToDto()
    };
}
