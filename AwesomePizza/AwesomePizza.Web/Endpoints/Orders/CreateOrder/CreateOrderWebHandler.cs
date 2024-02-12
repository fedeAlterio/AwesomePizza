using AwesomePizza.Application.Abstractions;
using AwesomePizza.Application.Actions.Orders.CreateOrder;
using AwesomePizza.Models.Dishes;
using AwesomePizza.Web.Dto.Errors;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AwesomePizza.Web.Endpoints.Orders.CreateOrder;
public class CreateOrderWebHandler(IRequestSender<CreateOrderRequest, CreateOrderResponse> requestSender) : IRequestHandler<CreateOrderWebRequest, IResult>
{
    public async Task<IResult> Handle(CreateOrderWebRequest webRequest, CancellationToken cancellationToken)
    {
        var request = new CreateOrderRequest
        {
            Dishes = webRequest.Dishes.Select(x => new DishId(x)).ToList()
        };

        var response = await requestSender.Send(request, cancellationToken);
        return response.Match<IResult>(SuccessResponse, OneDishIsRequiredResponse, SomeDishesDontExistResponse);
    }

    BadRequest<ErrorResponse> SomeDishesDontExistResponse(SomeDishesDontExist someDishesDontExist) =>
        someDishesDontExist.NotExistentDishes
                           .Select(Error.DishNotFound)
                           .ToErrorResponse()
                           .ToBadRequest();

    BadRequest<ErrorResponse> OneDishIsRequiredResponse(OneDishIsRequired oneDishIsRequired) =>
        Error.AtLeastOneDishIsRequired()
             .ToErrorResponse()
             .ToBadRequest();

    Ok<CreateOrderWebResponse> SuccessResponse(CreateOrderSuccess orderSuccess) => TypedResults.Ok(new CreateOrderWebResponse
    {
        OrderId = orderSuccess.OrderId.Value,
    });
}
