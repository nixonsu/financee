using Domain.Models;

namespace Infrastructure.Entities;

public sealed record BusinessEntity
{
    public required Guid Id { get; init; }
    public required Guid UserId { get; init; }
    public required string Name { get; init; }
}

public static class BusinessEntityExtensions
{
    public static BusinessEntity ToEntity(this Business business) => new()
    {
        Id = business.Id,
        UserId = business.UserId,
        Name = business.Name
    };

    public static Business ToDomain(this BusinessEntity entity) => new()
    {
        Id = entity.Id,
        UserId = entity.UserId,
        Name = entity.Name
    };
}