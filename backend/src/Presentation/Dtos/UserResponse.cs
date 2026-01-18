using Domain.Models;

namespace Presentation.Dtos;

public sealed record UserResponse
{
    public required Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
}

public static class UserResponseExtensions
{
    public static UserResponse ToResponse(this User model) =>
        new()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email
        };
}