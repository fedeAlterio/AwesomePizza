using AwesomePizza.Application.Abstractions.Repositories;
using AwesomePizza.Infrastructure.Persistence;
using AwesomePizza.Models.Dishes;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizza.Infrastructure.Repositories;
internal class DishRepository : IDishRepository
{
    readonly AppDbContext _db;

    public DishRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Dish>> GetAllDishes(CancellationToken cancellationToken)
    {
        return await _db.Dishes.ToListAsync(cancellationToken);
    }

    public async Task<List<Dish>> FindById(IEnumerable<DishId> dishes, CancellationToken cancellationToken)
    {
        var distinctDishes = dishes.Distinct().ToList();
        return await _db.Dishes
                        .Where(x => distinctDishes.Contains(x.Id))
                        .ToListAsync(cancellationToken: cancellationToken);
    }

    public void CreateDish(Dish dish)
    {
        _db.Dishes.Add(dish);
    }

    public async Task<bool> DishWithNameExists(DishName name)
    {
        return await _db.Dishes.AnyAsync(x => x.Name == name);
    }

    public async Task<bool> RemoveDish(DishId dish, CancellationToken cancellationToken)
    {
        return await _db.Dishes.Where(x => x.Id == dish).ExecuteDeleteAsync(cancellationToken) > 0;
    }
}