using AwesomePizza.Models.Validation;
using FluentValidation;

namespace AwesomePizza.Models.Dishes;

public record DishName
{
    public const int MINIMUM_LENGTH = 2;
    public const int MAXIMUM_LENGTH = 50;

    public DishName(string value)
    {
        Value = value;
        this.ValidatePropertyOrThrow(x => x.Value, x => x.NotNull()
                                                         .Length(MINIMUM_LENGTH, MAXIMUM_LENGTH));
    }

    public string Value { get; }
}