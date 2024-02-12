using FluentValidation;

namespace AwesomePizza.Web.Endpoints.Orders.CreateOrder;
public class CreateOrderWebRequestValidator : AbstractValidator<CreateOrderWebRequest>
{
    public CreateOrderWebRequestValidator()
    {
        RuleFor(x => x.Dishes).NotEmpty();
    }
}

