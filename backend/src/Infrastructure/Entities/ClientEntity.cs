using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models;

namespace Infrastructure.Entities;

public sealed record ClientEntity
{
    public Guid Id { get; init; }
    
    public Guid BusinessId { get; init; }
    public BusinessEntity? Business { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string PhoneNumber { get; init; }
}

public static class ClientEntityExtensions
{
    public static Client ToDomain(this ClientEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Email = entity.Email,
        PhoneNumber = entity.PhoneNumber
    };
}