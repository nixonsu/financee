using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class ClientService(IClientRepository clientRepository)
{
    public async Task<List<Client>> GetClients(Guid businessId)
    {
        return await clientRepository.GetClientsByBusinessId(businessId);
    }
}