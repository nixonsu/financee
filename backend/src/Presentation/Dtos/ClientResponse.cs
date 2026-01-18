using Domain.Models;

namespace Presentation.Dtos;

public sealed record ClientResponse
{
    public Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string PhoneNumber { get; init; }
}

public static class ClientResponseExtensions
{
    public static ClientResponse ToResponse(this Client client) => new()
    {
        Id = client.Id,
        FirstName = client.FirstName,
        LastName = client.LastName,
        Email = client.Email,
        PhoneNumber = client.PhoneNumber
    };
}