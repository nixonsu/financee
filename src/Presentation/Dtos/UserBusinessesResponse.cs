namespace Presentation.Dtos;

public sealed record UserBusinessesResponse
{
    public required List<BusinessResponse> Businesses { get; init; }
}