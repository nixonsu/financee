using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class BusinessService(IBusinessRepository businessRepository)
{
    public async Task<Guid> CreateBusinessAsync(Guid userId, string name)
    {
        var businessId = await businessRepository.CreateBusinessAsync(userId, name);
        return businessId;
    }

    public async Task<List<Business>> GetBusinessByUserIdAsync(Guid userId)
    {
        return await businessRepository.GetBusinessesByUserIdAsync(userId);
    }
}