using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Dtos;

namespace Presentation.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientController(ClientService clientService) : ControllerBase
{
    [HttpGet("")]
    public async Task<ActionResult<List<ClientResponse>>> GetClients(Guid businessId)
    {
        var clients = await clientService.GetClients(businessId);
        return Ok(clients.Select(c => c.ToResponse()).ToList());
    }
}