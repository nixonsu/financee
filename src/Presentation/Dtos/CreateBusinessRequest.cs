namespace Presentation.Dtos;

public sealed record CreateBusinessRequest
{
    public required Guid UserId { get; init; }
    public required string Name { get; init; }
}