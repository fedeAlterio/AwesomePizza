using AwesomePizza.Application.Actions.Orders.CreateOrder;
using AwesomePizza.Models.Dishes;
using MediatR;
using OneOf;

namespace AwesomePizza.Application.Actions.Menu.RemoveDish;

[GenerateOneOf]
public partial class RemoveDishResponse : OneOfBase<Success, SomeDishesDontExist>;

public record Success;