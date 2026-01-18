using System.Security.Claims;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Dtos;

namespace Presentation.Controllers;

[Authorize]
[ApiController]
[Route("api/users")]
public class UserController(UserService userService, BusinessService businessService) : ControllerBase
{
    [HttpGet("me")]
    public async Task<ActionResult<UserResponse>> GetOrCreateUser()
    {
        var subject = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(subject))
        {
            return Unauthorized();
        }

        var user = await userService.GetOrCreateUserAsync(subject);
        return Ok(user.ToResponse());
    }

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