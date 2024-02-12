using AwesomePizza.Models.Validation;
using FluentValidation;

namespace AwesomePizza.Models.Dishes;

public record DishDescription
{
    public const int MINIMUM_LENGTH = 5;
    public const int MAXIMUM_LENGTH = 200;

    public DishDescription(string value)
    {
        Value = value;
        this.ValidatePropertyOrThrow(x => x.Value, x => x.NotNull()
                                                         .Length(MINIMUM_LENGTH, MAXIMUM_LENGTH));
    }

    public string Value { get; }
}