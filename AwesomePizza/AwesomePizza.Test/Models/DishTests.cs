using AwesomePizza.Models.Dishes;
using AwesomePizza.Models.Exceptions;
using AwesomePizza.Test.TestHelpers;
using FluentAssertions;

namespace AwesomePizza.Test.Models;
public class DishTests
{

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("a")]
    public void ShouldThrowModelValidationException_IfInvalidName(string invalidName)
    {
        var action = () => new Dish(MockData.DishId(), new(invalidName), new("SSSSSS"), new(11));
        action.Should().Throw<ModelValidationException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("a")]
    public void ShouldThrowModelValidationException_IfInvalidDescription(string invalidDescription)
    {
        var action = () => new Dish(MockData.DishId(), new("Name"), new(invalidDescription), new(11));
        action.Should().Throw<ModelValidationException>();
    }


    [Theory]
    [InlineData(132112)]
    [InlineData(-11)]
    [InlineData(-1)]
    public void ShouldThrowModelValidationException_IfInvalidPrice(int invalidPrice)
    {
        var action = () => new Dish(MockData.DishId(), new("Name"), new("SSSSSS"), new(invalidPrice));
        action.Should().Throw<ModelValidationException>();
    }
}
