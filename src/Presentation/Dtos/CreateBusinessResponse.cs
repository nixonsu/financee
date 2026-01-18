namespace Presentation.Dtos;

public sealed record CreateBusinessResponse
{
    public required Guid BusinessId { get; init; }
}