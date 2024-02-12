using AwesomePizza.Application.Abstractions.Repositories;
using AwesomePizza.Models.Dishes;
using MediatR;

namespace AwesomePizza.Application.Actions.Menu.AddDish;
public class AddDishHandler(IDishRepository dishRepository) : IRequestHandler<AddDishRequest, AddDishResponse>
{
    public async Task<AddDishResponse> Handle(AddDishRequest request, CancellationToken cancellationToken)
    {
        if (await dishRepository.DishWithNameExists(request.DishName))
            return new DishWithSameNameAlreadyExists(request.DishName);

        var dish = new Dish(DishId.Create(), request.DishName, request.Description, request.Price);

        dishRepository.CreateDish(dish);
        return new AddDishSuccessResponse
        {
            DishId = dish.Id
        };
    }
}
