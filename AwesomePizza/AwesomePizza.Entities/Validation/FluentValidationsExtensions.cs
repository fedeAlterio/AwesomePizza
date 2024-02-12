using AwesomePizza.Models.Exceptions;
using FluentValidation;

namespace AwesomePizza.Models.Validation;
public static class FluentValidationsExtensions
{
    public static IRuleBuilderOptions<T, string> NotWhiteSpaces<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Matches(@"\A\S+\z").WithMessage("Ensure there are not whitespaces");
    }

    public static IRuleBuilderOptions<T, string> LowerCaseOnly<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Matches(@"^[a-z0-9]+").WithMessage("Ensure it is in lower case");
    }

    public static IRuleBuilderOptions<T, string> IsTrimmed<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must(x =>
        {
            if (string.IsNullOrEmpty(x))
                return true;

            return !char.IsWhiteSpace(x[0]) && !char.IsWhiteSpace(x[^1]);
        }).WithMessage("Text should not start or end with a whitespace");
    }

    internal static void ValidateAndThrow<T>(this IValidator<T> @this, T instance)
    {
        try
        {
            DefaultValidatorExtensions.ValidateAndThrow(@this, instance);
        }
        catch (ValidationException e)
        {
            throw new ModelValidationException(e);

        }
    }
}
