using System.ComponentModel;

namespace AwesomePizza.Web.Dto;

public record OrderDto
{
    public required Guid OrderId { get; init; }
    public required List<Guid> DishIds { get; init; }
}