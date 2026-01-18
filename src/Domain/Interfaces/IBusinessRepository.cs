using Domain.Models;

namespace Domain.Interfaces;

public interface IBusinessRepository
{
    Task<Guid> CreateBusinessAsync(Guid userId, string name);
    Task<List<Business>> GetBusinessesByUserIdAsync(Guid userId);
}