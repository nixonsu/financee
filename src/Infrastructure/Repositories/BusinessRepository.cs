using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BusinessRepository(AppDbContext dbContext) : IBusinessRepository
{
    public async Task<Guid> CreateBusinessAsync(Guid userId, string name)
    {
        var business = new BusinessEntity
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Name = name
        };

        dbContext.Businesses.Add(business);
        await dbContext.SaveChangesAsync();

        return business.Id;
    }

    public Task<List<Business>> GetBusinessesByUserIdAsync(Guid userId)
    {
        return dbContext.Businesses.Where(b => b.UserId == userId)
            .Select(b => b.ToDomain())
            .ToListAsync();
    }
}