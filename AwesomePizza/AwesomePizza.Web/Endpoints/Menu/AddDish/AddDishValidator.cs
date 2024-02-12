using AwesomePizza.Models.Dishes;
using FluentValidation;

namespace AwesomePizza.Web.Endpoints.Menu.AddDish;
public class AddDishWebRequestValidator : AbstractValidator<AddDishWebRequest>
{
    public AddDishWebRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .NotNull()
            .MinimumLength(5)
            .MaximumLength(200);

        RuleFor(x => x.Price)
            .NotNull()
            .GreaterThanOrEqualTo(0);
    }
}

