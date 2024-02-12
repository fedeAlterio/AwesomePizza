using FluentValidation;

namespace AwesomePizza.Web.Endpoints.Orders.AcceptOrder;
public class AcceptOrderWebRequestValidator : AbstractValidator<AcceptOrderWebRequest>
{
    public AcceptOrderWebRequestValidator()
    {
        RuleFor(x => x.OrderId).NotNull()
                               .NotEqual(Guid.Empty);
    }
}

