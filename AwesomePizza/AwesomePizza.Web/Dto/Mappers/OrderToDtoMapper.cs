using AwesomePizza.Models.Orders;

namespace AwesomePizza.Web.Dto.Mappers;

public static class OrderToDtoMapper
{
    public static OrderDto ToDto(this Order order) => new()
    {
        DishIds = order.Dishes
                       .SelectMany(x => Enumerable.Range(0, x.Quantity)
                                                  .Select(_ => x.Dish!.Id.Value))
                       .ToList(),
        OrderId = order.Id.Value
    };
}
