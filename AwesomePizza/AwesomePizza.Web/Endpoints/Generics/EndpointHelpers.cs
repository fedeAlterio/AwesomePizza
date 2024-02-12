using System.Net;
using AwesomePizza.Web.Dto.Errors;

namespace AwesomePizza.Web.Endpoints.Generics;

public static class EndpointHelpers
{
    public static RouteHandlerBuilder ProducesErrorResponseBadRequest(this RouteHandlerBuilder routes) =>
        routes.Produces<ErrorResponse>(statusCode: (int) HttpStatusCode.BadRequest);

    public static RouteHandlerBuilder ProducesOk(this RouteHandlerBuilder routes) =>
        routes.Produces((int)HttpStatusCode.OK);
}
