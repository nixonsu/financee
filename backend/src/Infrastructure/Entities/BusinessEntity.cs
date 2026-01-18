using Domain.Models;

namespace Infrastructure.Entities;

public sealed record BusinessEntity
{
    public required Guid Id { get; init; }
    public required UserEntity? User { get; init; }
    public required Guid UserId { get; init; }
    public required string Name { get; init; }
    public ICollection<ClientEntity> Clients { get; init; } = new List<ClientEntity>();
}

public static class BusinessEntityExtensions
{
    public static Business ToDomain(this BusinessEntity entity) => new()
    {
        Id = entity.Id,
        UserId = entity.UserId,
        Name = entity.Name
    };
}