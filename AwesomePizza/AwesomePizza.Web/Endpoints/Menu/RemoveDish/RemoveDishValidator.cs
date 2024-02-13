using FluentValidation;

namespace AwesomePizza.Web.Endpoints.Menu.RemoveDish;
public class RemoveDishWebRequestValidator : AbstractValidator<RemoveDishWebRequest>
{
    public RemoveDishWebRequestValidator()
    {
        RuleFor(x => x.DishId).NotNull();
    }
}

