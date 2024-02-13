using AwesomePizza.Models.Dishes;

namespace AwesomePizza.Application.Abstractions.Repositories;

public interface IDishRepository
{
    Task<List<Dish>> GetAllDishes(CancellationToken cancellationToken);
    Task<List<Dish>> FindById(IEnumerable<DishId> dishes, CancellationToken cancellationToken);
    void CreateDish(Dish dish);
    Task<bool> DishWithNameExists(DishName name);
    Task<bool> RemoveDish(DishId dish, CancellationToken cancellationToken);
}