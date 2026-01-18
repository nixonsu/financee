using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ClientRepository(AppDbContext context) : IClientRepository
{
    public async Task<List<Client>> GetClientsByBusinessId(Guid businessId)
    {
        var clientEntities = await context.Clients
            .Where(e => e.BusinessId == businessId)
            .ToListAsync();
        return clientEntities.Select(ce => ce.ToDomain()).ToList();
    }
}