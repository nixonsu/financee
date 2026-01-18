using Domain.Models;

namespace Infrastructure.Entities;

public sealed record UserEntity
{
    public required Guid Id { get; init; }
    public required string Subject { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public ICollection<BusinessEntity> Businesses { get; init; } = new List<BusinessEntity>();
}

public static class UserExtensions
{
    public static User ToDomain(this UserEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Email = entity.Email
    };
}
