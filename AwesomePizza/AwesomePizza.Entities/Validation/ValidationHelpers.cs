using System.Linq.Expressions;
using FluentValidation;

namespace AwesomePizza.Models.Validation;

internal static class ValidationHelpers
{
    public static void ValidatePropertyOrThrow<TEntity, TProperty>(this TEntity @this, 
                                                                   Expression<Func<TEntity, TProperty>> propertyExpression, 
                                                                   Func<IRuleBuilder<TEntity, TProperty>, IRuleBuilder<TEntity, TProperty>> rule)
    {
        Create(propertyExpression, rule).ValidateAndThrow(@this);
    }

    public static void ValidatePropertiesOrThrow<TEntity>(this TEntity @this, Action<AbstractValidator<TEntity>> validatorAction)
    {
        var validator = new AnonymousValidator<TEntity>(validatorAction);
        validator.ValidateAndThrow(@this);
    }

    public static IValidator<TEntity> Create<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression,
                                                                 Func<IRuleBuilder<TEntity, TProperty>, IRuleBuilder<TEntity, TProperty>> rule)
    {
        return new PropertyValidator<TEntity, TProperty>(propertyExpression, rule);
    }

    class AnonymousValidator<TEntity> : AbstractValidator<TEntity>
    {
        public AnonymousValidator(Action<AbstractValidator<TEntity>> validatorAction)
        {
            validatorAction(this);
        }
    }

    class PropertyValidator<TEntity, TProperty> : AbstractValidator<TEntity>
    {
        public PropertyValidator(Expression<Func<TEntity, TProperty>> propertyExpression, Func<IRuleBuilder<TEntity, TProperty>, IRuleBuilder<TEntity, TProperty>> rule)
        {
            rule(RuleFor(propertyExpression));
        }
    }
}
