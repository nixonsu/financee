using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("clients")]
public class ClientController(ClientService clientService) : ControllerBase
{
    [HttpGet("")]
    public async Task<List<ClientResponse>> GetClients(Guid businessId)
    {
        var clients = await clientService.GetClients(businessId);
        
        return clients.Select(c => new ClientResponse
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email,
            PhoneNumber = c.PhoneNumber
        }).ToList();
    }
}