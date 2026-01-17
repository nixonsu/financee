using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ClientRepository(AppDbContext context) : IClientRepository
{
    public async Task<List<Client>> GetClientsByBusinessId(Guid businessId)
    {
        var entities = await context.Clients
            .Where(e => e.BusinessId == businessId)
            .ToListAsync();
        return entities.Select(e => new Client
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Email = e.Email,
            PhoneNumber = e.PhoneNumber
        }).ToList();
    }
}