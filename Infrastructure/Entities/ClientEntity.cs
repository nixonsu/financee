namespace Infrastructure.Entities;

public sealed record ClientEntity
{
    public Guid Id { get; init; }
    public Guid BusinessId { get; init; } // Add this if you want to filter by business
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string PhoneNumber { get; init; }
}