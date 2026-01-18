using Domain.Models;

namespace Presentation.Dtos;

public sealed record BusinessResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}

public static class BusinessResponseExtensions
{
    public static BusinessResponse ToResponse(this Business business)
    {
        return new BusinessResponse
        {
            Id = business.Id,
            Name = business.Name
        };
    }
}