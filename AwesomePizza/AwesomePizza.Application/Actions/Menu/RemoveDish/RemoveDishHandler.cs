using AwesomePizza.Application.Abstractions.Repositories;
using AwesomePizza.Application.Actions.Orders.CreateOrder;
using MediatR;

namespace AwesomePizza.Application.Actions.Menu.RemoveDish;
public class RemoveDishHandler(IDishRepository dishRepository) : IRequestHandler<RemoveDishRequest, RemoveDishResponse>
{
    public async Task<RemoveDishResponse> Handle(RemoveDishRequest request, CancellationToken cancellationToken)
    {
        var dishExisted = await dishRepository.RemoveDish(request.DishId, cancellationToken);
        return dishExisted ? new Success() : new SomeDishesDontExist([request.DishId]);
    }
}
