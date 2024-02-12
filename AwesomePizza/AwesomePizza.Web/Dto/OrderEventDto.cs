namespace AwesomePizza.Web.Dto;

public record OrderEventDto
{
    public required Guid OrderEventId { get; init; }
    public required Guid OrderId { get; init; }
    public required DateTime DateUtc { get; init; }
    public required OrderEventTypeDto EventType { get; init; }
}