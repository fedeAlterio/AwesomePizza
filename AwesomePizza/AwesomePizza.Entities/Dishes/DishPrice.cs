using AwesomePizza.Models.Validation;
using FluentValidation;

namespace AwesomePizza.Models.Dishes;

public readonly record struct DishPrice
{
    public const int MINIMUM_PRICE_INCLUSIVE = 0;
    public const int MAXIMUM_PRICE = 50;

    public DishPrice(int value)
    {
        Value = value;
        this.ValidatePropertyOrThrow(x => x.Value, x => x.GreaterThanOrEqualTo(MINIMUM_PRICE_INCLUSIVE)
                                                         .LessThan(MAXIMUM_PRICE));
    }

    public int Value { get; }
}