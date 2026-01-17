using Domain.Models;

namespace Domain.Interfaces;

public interface IClientRepository
{
    Task<List<Client>> GetClientsByBusinessId(Guid businessId);
}