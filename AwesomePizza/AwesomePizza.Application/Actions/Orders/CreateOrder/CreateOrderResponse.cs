using AwesomePizza.Models.Dishes;
using AwesomePizza.Models.Orders;
using OneOf;

namespace AwesomePizza.Application.Actions.Orders.CreateOrder;


[GenerateOneOf]
public partial class CreateOrderResponse : OneOfBase<CreateOrderSuccess, OneDishIsRequired, SomeDishesDontExist>;

public record CreateOrderSuccess(OrderId OrderId);
public record OneDishIsRequired;
public record SomeDishesDontExist(IReadOnlyCollection<DishId> NotExistentDishes);
