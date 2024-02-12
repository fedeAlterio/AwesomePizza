using FluentValidation;

namespace AwesomePizza.Web.Endpoints.Orders.CompleteOrder;
public class CompleteOrderWebRequestValidator : AbstractValidator<CompleteOrderWebRequest>
{
    public CompleteOrderWebRequestValidator()
    {
        RuleFor(x => x.OrderId)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}

