using AwesomePizza.Application.Abstractions;
using AwesomePizza.Application.Actions.Menu.AddDish;
using AwesomePizza.Web.Dto.Errors;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AwesomePizza.Web.Endpoints.Menu.AddDish;
public class AddDishWebHandler(IRequestSender<AddDishRequest, AddDishResponse> addDishSender) : IRequestHandler<AddDishWebRequest, IResult>
{
    public async Task<IResult> Handle(AddDishWebRequest webRequest, CancellationToken cancellationToken)
    {
        var request = new AddDishRequest
        {
            Description = new(webRequest.Description),
            DishName = new(webRequest.Name),
            Price = new(webRequest.Price!.Value)
        };

        var response = await addDishSender.Send(request, cancellationToken);
        return response.Match(SuccessResponse, DishWithSameNameAlreadyExistsResponse);
    }

    IResult DishWithSameNameAlreadyExistsResponse(DishWithSameNameAlreadyExists dishWithSameNameAlreadyExists) =>
        Error.DuplicatedDish(dishWithSameNameAlreadyExists.DishName)
             .ToErrorResponse()
             .ToBadRequest();

    Ok<AddDishWebResponse> SuccessResponse(AddDishSuccessResponse response) => TypedResults.Ok(new AddDishWebResponse
    {
        DishId = response.DishId.Value
    });
}
