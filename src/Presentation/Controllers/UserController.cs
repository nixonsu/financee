using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Dtos;

namespace Presentation.Controllers;

[Authorize]
[ApiController]
[Route("api/users")]
public class UserController(BusinessService businessService) : ControllerBase
{
    [HttpGet("{id:guid}/businesses")]
    public async Task<ActionResult<UserBusinessesResponse>> GetUserBusinesses(Guid id)
    {
        var businesses = await businessService.GetBusinessByUserIdAsync(id);
        var response = new UserBusinessesResponse
        {
            Businesses = businesses.Select(b => b.ToResponse()).ToList()
        };
        return Ok(response);
    }
}