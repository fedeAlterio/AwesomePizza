using AwesomePizza.Application.Actions.Orders.ChangeOrderState;
using AwesomePizza.Application.Actions.Orders.Common.CommonResponses;
using AwesomePizza.Web.Dto.Errors;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AwesomePizza.Web.Endpoints.Orders.Common;

public static class OrderResponseToWebResultMapper
{
    public static NotFound<ErrorResponse> ToNotFound(this OrderNotFound orderNotFound) =>
        Error.OrderNotFound(orderNotFound.OrderId)
             .ToErrorResponse()
             .ToNotFound();

    public static BadRequest<ErrorResponse> ToBadRequest(this OrderInWrongStateError orderInWrongState) =>
        Error.OrderInWrongState(orderInWrongState.OrderId, orderInWrongState.State)
             .ToErrorResponse()
             .ToBadRequest();

    public static IResult ToResult(this ChangeOrderStateResponse changeOrderStateResponse) =>
        changeOrderStateResponse.Match<IResult>(_ => TypedResults.Ok(), 
                                                notFound => notFound.ToNotFound(), 
                                                wrongState => wrongState.ToBadRequest());
}
